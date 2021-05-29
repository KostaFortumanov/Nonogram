using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Nonogram
{
    public class Game
    {
        /// <summary>
        /// Листа од броевите за секој ред и колона
        /// </summary>
        List<string> nums;
        /// <summary>
        /// Листа од сите полиња
        /// </summary>
        List<Rectangle> rectangles;
        /// <summary>
        /// Широчина на едно поле
        /// </summary>
        float W;
        /// <summary>
        /// Висина на едно поле
        /// </summary>
        float H;
        /// <summary>
        /// Големина на таблата 5, 10 15
        /// </summary>
        int size;
        /// <summary>
        /// Дали класата ја користиме за играње или решавање
        /// </summary>
        bool solve;
        /// <summary>
        /// Име на сликата што ја добиваме на крај
        /// </summary>
        string name;

        public Game(string lvl)
        {
            rectangles = new List<Rectangle>();
            nums = new List<string>();
            if (lvl == "5X5" || lvl == "10X10" || lvl == "15X15")
            {
                solve = true;
                int.TryParse(lvl.Split("X")[0], out size);
                if (size == 5)
                {
                    W = 100;
                    H = 100;
                }
                else if (size == 10)
                {
                    W = 50;
                    H = 50;
                }
                else
                {
                    W = 34;
                    H = 34;
                }
                Solve();
            }
            else
            {
                string[] values = lvl.Split(",");
                name = values[0];
                float.TryParse(values[1].Split(" ")[0], out W);
                float.TryParse(values[1].Split(" ")[1], out H);
                int index;
                if (W == 34)
                {
                    index = 32;
                    size = 15;
                }
                else if (W == 50)
                {
                    index = 22;
                    size = 10;
                }
                else
                {
                    index = 12;
                    size = 5;
                }

                for (int i = 2; i < index; i++)
                {
                    nums.Add(values[i]);
                }

                for (int i = 200; i < 700; i += (int)W)
                {
                    for (int j = 200; j < 700; j += (int)H)
                    {
                        string[] parts = values[index].Split(" ");
                        int.TryParse(parts[0], out int R);
                        int.TryParse(parts[1], out int G);
                        int.TryParse(parts[2], out int B);
                        bool correct = parts[3].Equals("yes") ? true : false;
                        rectangles.Add(new Rectangle(i, j, W, H, Color.FromArgb(R, G, B), correct));
                        index++;
                    }
                }
            }
        }

        public void Solve()
        {
            for (int i = 200; i < 700; i += (int)W)
            {
                for (int j = 200; j < 700; j += (int)H)
                {
                    rectangles.Add(new Rectangle(i, j, W, H, Color.CornflowerBlue, true));
                }
            }
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Black);
            Font font = new Font("Ariel", 12, FontStyle.Bold);
            int width, height;

            if (!solve)
            {
                RemoveNums();
                width = 205;
                for (int i = 0; i < nums.Count / 2; i++)
                {
                    if (nums[i] != null)
                    {
                        string[] parts = nums[i].Split(" ");
                        height = 170;
                        for (int j = 0; j < parts.Length; j++)
                        {
                            g.DrawString(parts[j], font, brush, width, height);
                            height -= 25;
                        }
                    }
                    width += (int)W;
                }

                height = 205;
                for (int i = nums.Count / 2; i < nums.Count; i++)
                {
                    if (nums[i] != null)
                    {
                        string[] parts = nums[i].Split(" ");
                        width = 175;
                        for (int j = 0; j < parts.Length; j++)
                        {
                            g.DrawString(parts[j], font, brush, width, height);
                            width -= 25;
                        }
                    }
                    height += (int)H;
                }
            }

            foreach (Rectangle r in rectangles)
            {
                r.Draw(g);
            }

            if (!IsOver())
            {
                Pen pen = new Pen(Color.Black, 3);
                if (W == 34)
                {
                    g.DrawRectangle(pen, 200, 200, 510, 510);
                }
                else
                {
                    g.DrawRectangle(pen, 200, 200, 500, 500);
                }
                if (W == 50)
                {
                    g.DrawLine(pen, new Point(200, 450), new Point(700, 450));
                    g.DrawLine(pen, new Point(450, 200), new Point(450, 700));
                } 
                else if (W == 34)
                {
                    g.DrawLine(pen, new Point(200, 370), new Point(710, 370));
                    g.DrawLine(pen, new Point(370, 200), new Point(370, 710));
                    g.DrawLine(pen, new Point(200, 540), new Point(710, 540));
                    g.DrawLine(pen, new Point(540, 200), new Point(540, 710));
                }
                pen.Dispose();
            }
            brush.Dispose();
        }

        public bool Hit(Point point)
        {
            foreach (Rectangle r in rectangles)
            {
                if (!r.Hit(point))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsOver()
        {
            foreach (Rectangle r in rectangles)
            {
                if (r.Correct == true && r.IsHit == false)
                {
                    return false;
                }
            }

            foreach (Rectangle r in rectangles)
            {
                r.End = true;
            }
            return true;
        }

        public void ChangeColor()
        {
            foreach (Rectangle r in rectangles)
            {
                r.ScaleColor();
            }
        }

        public void RemoveNums()
        {
            for(int i=0; i<size; i++)
            {
                bool flag = true;
                for(int j=i*size; j<i*size+size; j++)
                {
                    if(rectangles[j].Correct && !rectangles[j].IsHit)
                    {
                        flag = false;
                        break;
                    }
                }

                if(flag)
                {
                    nums[i] = null;
                }
            }

            for (int i = 0; i < size; i++)
            {
                bool flag = true;
                for (int j = i; j < rectangles.Count; j+=size)
                {
                    if (rectangles[j].Correct && !rectangles[j].IsHit)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    nums[size + i] = null;
                }
            }
        }

        public void solution(bool[,] board)
        {
            foreach(Rectangle r in rectangles)
            {
                r.IsHit = false;
            }

            int index = 0;
            for(int i=0; i<size; i++)
            {
                for(int j=0; j<size; j++)
                {
                    if(board[j,i])
                    {
                        rectangles[index].IsHit = true;
                    }
                    index++;
                }
            }
        }

        public string getName()
        {
            return name;
        }
    }
}
