using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Tesseract_OCR
{
    public struct Rect
    {
        public Point startPos;
        public Point endPos;
    };
    public partial class CapView : Form
    {


        Rect rectangleText;
        Point currentPos;
        bool drawing;
        public CapView()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = Color.White;
            this.Opacity = 0.75;
            this.Cursor = Cursors.Cross;
            this.MouseDown += Canvas_MouseDown;
            this.MouseMove += Canvas_MouseMove;
            this.MouseUp += Canvas_MouseUp;
            this.Paint += Canvas_Paint;
            this.KeyDown += Canvas_KeyDown;
            this.DoubleBuffered = true;
        }

        private void CapView_Load(object sender, EventArgs e)
        {

        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
        }
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
                currentPos = rectangleText.startPos = e.Location;
            drawing = true;
            // this.label1.Text = e.Location.X + "," + e.Location.Y;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            currentPos = e.Location;
            if (drawing) this.Invalidate();
            this.label1.Text = e.Location.X + "," + e.Location.Y;
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {

                currentPos = rectangleText.endPos = e.Location;
                this.drawing = false;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();


        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {

                if (drawing) e.Graphics.DrawRectangle(Pens.Green, GetRectangle(this.rectangleText));
            
        }
        public Rectangle GetRectangle(Rect curRect)
        {
            return new Rectangle(
                Math.Min(curRect.startPos.X, currentPos.X),
                Math.Min(curRect.startPos.Y, currentPos.Y),
                Math.Abs(curRect.startPos.X - currentPos.X),
                Math.Abs(curRect.startPos.Y - currentPos.Y));
        }
      

        public Rectangle GetRectangleText()
        {
            return new Rectangle(
                Math.Min(rectangleText.startPos.X, rectangleText.endPos.X),
                Math.Min(rectangleText.startPos.Y, rectangleText.endPos.Y),
                Math.Abs(rectangleText.startPos.X - rectangleText.endPos.X),
                Math.Abs(rectangleText.startPos.Y - rectangleText.endPos.Y));
        }

        public Bitmap GetRectangleTextBitmap4x()
        {
        Rectangle rectangle = GetRectangleText();
            using (Image image = new Bitmap(rectangle.Width, rectangle.Height))
            {
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    graphics.CopyFromScreen(new Point(rectangle.X, rectangle.Y), Point.Empty, rectangle.Size);
                }
                Bitmap bitmap = new Bitmap(image, new Size((rectangle.Width * 4), (rectangle.Height * 4)));
                bitmap.Save(@"./test.jpg",ImageFormat.Jpeg);
                return bitmap;
            }
        }

        public Bitmap GetRectangleTextBitmap3x()
        {
            Rectangle rectangle = GetRectangleText();
            using (Image image = new Bitmap(rectangle.Width, rectangle.Height))
            {
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    graphics.CopyFromScreen(new Point(rectangle.X, rectangle.Y), Point.Empty, rectangle.Size);
                }
                Bitmap bitmap = new Bitmap(image, new Size((rectangle.Width * 3), (rectangle.Height * 3)));
                bitmap.Save(@"./test.jpg", ImageFormat.Jpeg);
                return bitmap;
            }
        }

        public Bitmap GetRectangleTextBitmap2_5x()
        {
            Rectangle rectangle = GetRectangleText();
            using (Image image = new Bitmap(rectangle.Width, rectangle.Height))
            {
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    graphics.CopyFromScreen(new Point(rectangle.X, rectangle.Y), Point.Empty, rectangle.Size);
                }
                Bitmap bitmap = new Bitmap(image, new Size((rectangle.Width * 10/3), (rectangle.Height * 10/3)));
                bitmap.Save(@"./test.jpg", ImageFormat.Jpeg);
                return bitmap;
            }
        }

        public Bitmap GetRectangleTextBitmap3_5x()
        {
            Rectangle rectangle = GetRectangleText();
            using (Image image = new Bitmap(rectangle.Width, rectangle.Height))
            {
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    graphics.CopyFromScreen(new Point(rectangle.X, rectangle.Y), Point.Empty, rectangle.Size);
                }
                Bitmap bitmap = new Bitmap(image, new Size((rectangle.Width * 7/2), (rectangle.Height * 7/2)));
                bitmap.Save(@"./test.jpg", ImageFormat.Jpeg);
                return bitmap;
            }
        }

        public Bitmap GetRectangleTextBitmap4_5x()
        {
            Rectangle rectangle = GetRectangleText();
            using (Image image = new Bitmap(rectangle.Width, rectangle.Height))
            {
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    graphics.CopyFromScreen(new Point(rectangle.X, rectangle.Y), Point.Empty, rectangle.Size);
                }
                Bitmap bitmap = new Bitmap(image, new Size((rectangle.Width * 15/4), (rectangle.Height * 15/4)));
                bitmap.Save(@"./test.jpg", ImageFormat.Jpeg);
                return bitmap;
            }
        }

        private Image SetBorder(Image srcImg, Color color, int width)
        {
            // Create a copy of the image and graphics context
            Image dstImg = srcImg.Clone() as Image;
            Graphics g = Graphics.FromImage(dstImg);

            // Create the pen
            Pen pBorder = new Pen(color, width)
            {
                Alignment = PenAlignment.Center
            };

            // Draw
            g.DrawRectangle(pBorder, 0, 0, dstImg.Width - 1, dstImg.Height - 1);

            // Clean up
            pBorder.Dispose();
            g.Save();
            g.Dispose();

            // Return
            return dstImg;
        }

        public void convertToBlackAndWhite(Bitmap input)
        {
            using (Graphics gr = Graphics.FromImage(input)) // SourceImage is a Bitmap object
            {
                var gray_matrix = new float[][] {
                new float[] { 0.299f, 0.299f, 0.299f, 0, 0 },
                new float[] { 0.587f, 0.587f, 0.587f, 0, 0 },
                new float[] { 0.114f, 0.114f, 0.114f, 0, 0 },
                new float[] { 0,      0,      0,      1, 0 },
                new float[] { 0,      0,      0,      0, 1 }
            };

                var ia = new System.Drawing.Imaging.ImageAttributes();
                ia.SetColorMatrix(new System.Drawing.Imaging.ColorMatrix(gray_matrix));
                ia.SetThreshold(0.8f); // Change this threshold as needed
                var rc = new Rectangle(0, 0, input.Width, input.Height);
                gr.DrawImage(input, rc, 0, 0, input.Width, input.Height, GraphicsUnit.Pixel, ia);
            }
        }
}
}
