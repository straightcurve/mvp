using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PaintClone
{
    public partial class Form1 : Form
    {
        private enum ToolType
        {
            Pen,
            Eraser
        }

        private readonly Dictionary<ToolType, ITool> tools = new Dictionary<ToolType, ITool>();
        private readonly Graphics context;

        private ToolType selectedTool;
        private ToolType SelectedTool { 
            get => selectedTool; 
            set {
                selectedTool = value;
                grp_Thickness.Visible = selectedTool == ToolType.Pen;
            } 
        }

        Color first = Color.Black;
        Color second = Color.White;

        Point start;
        Point end;
        
        public Form1()
        {
            InitializeComponent();

            context = pic_DrawArea.CreateGraphics();
            context.Clear(Color.White);

            rad_Thickness1.Checked = true;

            tools.Add(ToolType.Pen, new PenTool(context, first));
            tools.Add(ToolType.Eraser, new EraserTool(context, second));
        }

        ~Form1()
        {
            context.Dispose();
        }

        private void pic_DrawArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.None || e.Button == MouseButtons.Middle)
                return;

            if (!tools.ContainsKey(SelectedTool))
                return;

            end = new Point(e.X, e.Y);
            tools[SelectedTool]
                .SetColor(e.Button == MouseButtons.Left ? first : second)
                .Use(start, end);
            start = end;
        }

        private void pic_DrawArea_MouseDown(object sender, MouseEventArgs e)
        {
            start = new Point(e.X, e.Y);
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            context.Clear(Color.White);
        }

        private void btn_PenTool_Click(object sender, EventArgs e)
        {
            SelectedTool = ToolType.Pen;
        }

        private void btn_EraserTool_Click(object sender, EventArgs e)
        {
            SelectedTool = ToolType.Eraser;
        }

        private void pic_FirstColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            pic_FirstColor.BackColor = first = colorDialog1.Color;
        }

        private void pic_SecondColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            pic_SecondColor.BackColor = second = colorDialog1.Color;
        }

        private void rad_Thickness1_CheckedChanged(object sender, EventArgs e)
        {
            if (!tools.ContainsKey(ToolType.Pen))
                return;

            tools[ToolType.Pen].SetSize(2);
        }

        private void rad_Thickness2_CheckedChanged(object sender, EventArgs e)
        {
            if (!tools.ContainsKey(ToolType.Pen))
                return;

            tools[ToolType.Pen].SetSize(6);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (!tools.ContainsKey(ToolType.Pen))
                return;

            tools[ToolType.Pen].SetSize(10);
        }
    }

    public interface ITool
    {
        int Size { get; }

        ITool SetColor(Color color);
        ITool SetSize(int size);
        void Use(Point start, Point end);
    }

    public class PenTool : ITool
    {
        private readonly Pen pen;
        private readonly Graphics context;

        public int Size { get; private set; } = 2;

        public PenTool(Graphics context, Color initialColor)
        {
            this.context = context;
            pen = new Pen(initialColor, Size);
        }

        ~PenTool() {
            pen.Dispose();
        }

        public ITool SetColor(Color color) {
            pen.Color = color;
            return this;
        }

        public ITool SetSize(int size)
        {
            pen.Width = size;
            return this;
        }

        public void Use(Point start, Point end)
        {
            context.DrawLine(pen, start, end);
        }
    }

    public class EraserTool : ITool
    {
        private readonly SolidBrush eraser;
        private readonly Graphics context;

        public int Size { get; private set; } = 20;

        public EraserTool(Graphics context, Color initialColor)
        {
            this.context = context;
            eraser = new SolidBrush(initialColor);
        }

        ~EraserTool()
        {
            eraser.Dispose();
        }

        public void Use(Point start, Point end)
        {
            context.FillRectangle(eraser, start.X, start.Y, Size, Size);
        }

        public ITool SetColor(Color color)
        {
            return this;
        }

        public ITool SetSize(int size)
        {
            Size = size;
            return this;
        }
    }
}
