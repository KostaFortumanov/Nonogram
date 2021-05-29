using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Nonogram
{
    public class Rectangle
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public Color RealColor { get; set; }
        public bool Correct { get; set; }
        public bool IsHit { get; set; }
        public bool End { get; set; }

        private Color currentColor;
        bool once = true;

        public Rectangle(float x, float y, float width, float height, Color realColor, bool correct)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            RealColor = realColor;
            Correct = correct;
            IsHit = false;
            End = false;

            if (correct)
            {
                currentColor = Color.CornflowerBlue;
            } else
            {
                currentColor = Color.White;
            }
        }

        public void Draw(Graphics g)
        {
            if (!End)
            {
                if (IsHit)
                {
                    Brush brush = new SolidBrush(currentColor);
                    if (Correct)
                    {
                        g.FillRectangle(brush, X, Y, Width, Height);
                    } 
                    else
                    {   Font font = new Font("Ariel", Width-20);
                        g.DrawString("X", font, Brushes.Black, X, Y);
                    }
                    brush.Dispose();
                }
                Pen pen = new Pen(Color.Black, 1);
                g.DrawRectangle(pen, X, Y, Width, Height);
                pen.Dispose();
            } 
            else
            {
                Brush brush = new SolidBrush(currentColor);
                g.FillRectangle(brush, X, Y, Width, Height);
                brush.Dispose();
            }
        }

        public bool Hit(Point point)
        {
            if(IsHit)
            {
                return true;
            }

            if(X <= point.X && X + Width >= point.X && Y <= point.Y && Y + Height >= point.Y)
            {
                IsHit = true;
                return Correct;
            }

            return true;
        }

        public void ScaleColor()
        {
            int r = currentColor.R;
            int g = currentColor.G;
            int b = currentColor.B;

            if(r != RealColor.R)
            {
                if(r < RealColor.R)
                {
                    r += 10;
                } 
                else
                {
                    r -= 10;
                }
            }

            if (g != RealColor.G)
            {
                if (g < RealColor.G)
                {
                    g += 10;
                }
                else
                {
                    g -= 10;
                }
            }

            if (b != RealColor.B)
            {
                if (b < RealColor.B)
                {
                    b += 10;
                }
                else
                {
                    b -= 10;
                }
            }

            if(Math.Abs(r - RealColor.R) < 10)
            {
                r = RealColor.R;
            }

            if (Math.Abs(g - RealColor.G) < 10)
            {
                g = RealColor.G;
            }

            if (Math.Abs(b - RealColor.B) <= 10)
            {
                b = RealColor.B;
            }

            currentColor = Color.FromArgb(r, g, b);

            if (once) {


                X -= 75;
                Y -= 75;
                
                once = false;
            }
        }
    }
}
