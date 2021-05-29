using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nonogram
{
    public partial class Form1 : Form
    {
        Timer timer;
        Game game;
        bool mouseDown;
        int mistakeCount;
        string[] levels;
        int levelIndex;
        bool solve;
        bool gameOver;
        List<Control> textBoxes;
        string[] initTextBoxes = { "3", "4", "5", "4", "5", "6", "3 2 1", "2 2 5", "4 2 6", "8 2 3", "8 2 1 1", "2 6 2 1", "4 6", "2 4", "1",
                                    "3", "5", "4 3", "7", "5", "3", "5", "1 8", "3 3 3", "7 3 2", "5 4 2", "8 2", "10", "2 3", "6"};
        int boardWidth;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.Width = 750;
            this.Height = 760;
            //StartGame("lvl1.txt");
            mouseDown = false;
            timer = new Timer();
            timer.Interval = 70;
            timer.Tick += new EventHandler(timer_tick);
            textBoxes = new List<Control>();
            solve = false;
            gameOver = false;
        }

        private void timer_tick(object sender, EventArgs e)
        {
            game.ChangeColor();
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            if(game != null)
                game.Draw(e.Graphics);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (game != null && !solve && !gameOver)
            {
                mouseDown = true;
                if (!game.Hit(e.Location))
                {
                    mouseDown = false;
                    AdjustHearths();
                }
                if (game.IsOver())
                {
                    timer.Start();
                    label1.Visible = true;
                    label1.Text = game.getName();
                }
                Invalidate();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                if(!game.Hit(e.Location))
                {
                    mouseDown = false;
                    AdjustHearths();
                }
                if(game.IsOver())
                {
                    timer.Start();
                    label1.Visible = true;
                    label1.Text = game.getName();
                }
                Invalidate();
            }
        }

        private void AdjustHearths()
        {
            if (!game.IsOver())
            {
                if (mistakeCount == 0)
                {
                    pictureBox1.Image = Properties.Resources.empty;
                }
                else if (mistakeCount == 1)
                {
                    pictureBox2.Image = Properties.Resources.empty;
                }
                else if (mistakeCount == 2)
                {
                    pictureBox3.Image = Properties.Resources.empty;
                }
                mistakeCount++;
            }

            if(mistakeCount == 3)
            {
                btnRestart.Visible = true;
                gameOver = true;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void StartGame(string lvl)
        {
            gameOver = false;
            btnRestart.Visible = false;
            label1.Visible = false;
            timer.Stop();
            game = new Game(lvl);
            mistakeCount = 0;
            if (!solve)
            {
                pictureBox1.Image = Properties.Resources.heart;
                pictureBox2.Image = Properties.Resources.heart;
                pictureBox3.Image = Properties.Resources.heart;
            }
        }

        private void btnEasyLvl_Click(object sender, EventArgs e)
        {
            levels = LevelPicker.getEasyLevels();
            levelIndex = 0;
            StartGame(levels[levelIndex]);
            TogglePlay();
            Invalidate();
        }

        private void btnMediumLvl_Click(object sender, EventArgs e)
        {
            levels = LevelPicker.getMediumLevels();
            levelIndex = 0;
            StartGame(levels[levelIndex]);
            TogglePlay();
            Invalidate();
        }

        private void btnHardLvl_Click(object sender, EventArgs e)
        {
            levels = LevelPicker.getHardLevels();
            levelIndex = 0;
            StartGame(levels[levelIndex]);
            TogglePlay();
            Invalidate();
        }

        private void TogglePlay()
        {
            btnEasyLvl.Visible = !btnEasyLvl.Visible;
            btnMediumLvl.Visible = !btnMediumLvl.Visible;
            btnHardLvl.Visible = !btnHardLvl.Visible;
            btnSolver.Visible = !btnSolver.Visible;
            btnNext.Visible = !btnNext.Visible;
            btnPrev.Visible = !btnPrev.Visible;
            btnBack.Visible = !btnBack.Visible;
            pbTitle.Visible = !pbTitle.Visible;
        }

        private void ToggleSolve()
        {
            gbSize.Visible = !gbSize.Visible;
            btnEasyLvl.Visible = !btnEasyLvl.Visible;
            btnMediumLvl.Visible = !btnMediumLvl.Visible;
            btnHardLvl.Visible = !btnHardLvl.Visible;
            btnSolver.Visible = !btnSolver.Visible;
            btnBack.Visible = !btnBack.Visible;
            btnSolve.Visible = !btnSolve.Visible;
            pbTitle.Visible = !pbTitle.Visible;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            timer.Stop();
            label1.Visible = false;
            game = null;
            if (solve)
            {
                ToggleSolve();
                solve = false;
                ClearTextBoxes();
            } 
            else
            {
                TogglePlay();
            }
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            btnPrev.Enabled = false;
            btnNext.Enabled = true;
            btnRestart.Visible = false;
            Invalidate();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            levelIndex--;
            if (levelIndex == 0) {
                btnPrev.Enabled = false;
            }
            btnNext.Enabled = true;
            btnRestart.Visible = false;
            gameOver = false;
            StartGame(levels[levelIndex]);
            Invalidate();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            levelIndex++;
            if (levelIndex == levels.Length-1)
            {
                btnNext.Enabled = false;
            }
            btnPrev.Enabled = true;
            StartGame(levels[levelIndex]);
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSolver_Click(object sender, EventArgs e)
        {
            solve = true;
            radioButton3.Checked = false;
            radioButton3.Checked = true;
            InitTextBoxes();
            ToggleSolve();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            CreateTextBoxes(5, 240, 80, 100);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            CreateTextBoxes(10, 215, 80, 50);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            CreateTextBoxes(15, 210, 80, 34);
        }

        private void CreateTextBoxes(int width, int point_x, int point_y, int increment)
        {
            boardWidth = width;
            ClearTextBoxes();
            if (width == 15)
            {
                StartGame("15X15");
            }
            else if (width == 10)
            {
                StartGame("10X10");
            }
            else
            {
                StartGame("5X5");
            }
            int x = point_x, y = point_y;
            for (int i = 0; i < boardWidth; i++)
            {
                RichTextBox rtb = new RichTextBox();
                rtb.Name = "tbc" + i;
                rtb.Width = 20;
                rtb.Height = 113;
                Point point = new Point(x, y);
                rtb.Location = point;
                textBoxes.Add(rtb);
                Controls.Add(rtb);
                x += increment;
            }

            x = point_y;
            y = point_x;
            for (int i = 0; i < boardWidth; i++)
            {
                RichTextBox rtb = new RichTextBox();
                rtb.Name = "tbr" + i;
                rtb.Width = 113;
                rtb.Height = 20;
                Point point = new Point(x, y);
                rtb.Location = point;
                textBoxes.Add(rtb);
                Controls.Add(rtb);
                y += increment;
            }
            Invalidate();
        }

        private void InitTextBoxes()
        {
            for(int i=0; i<textBoxes.Count; i++)
            {
                textBoxes[i].Text = initTextBoxes[i];
            }
        }

        private void ClearTextBoxes()
        {
            foreach(Control c in textBoxes)
            {
                Controls.Remove(c);
            }
            textBoxes = new List<Control>();
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            List<List<int>> rowRequirements = new List<List<int>>();
            List<List<int>> columnRequirements = new List<List<int>>();
            for(int i=0; i<boardWidth; i++)
            {
                string line = Regex.Replace(textBoxes[i].Text, @"\s+", " ");
                string[] numbers = line.Split(" ");
                List<int> temp = new List<int>();
                foreach (string num in numbers)
                {
                    if (int.TryParse(num, out int n))
                    {
                        temp.Add(n);
                    }
                }
                columnRequirements.Add(temp);
            }

            for (int i=boardWidth; i<textBoxes.Count; i++)
            {
                string line = Regex.Replace(textBoxes[i].Text, @"\s+", " ");
                string[] numbers = line.Split(" ");
                List<int> temp = new List<int>();
                foreach (string num in numbers)
                {
                    if (int.TryParse(num, out int n))
                    {
                        temp.Add(n);
                    }
                }
                rowRequirements.Add(temp);
            }

            Solver solver = new Solver(columnRequirements, rowRequirements, boardWidth, boardWidth);
            bool[,] board = solver.solve();

            if (board == null)
            {
                MessageBox.Show("No solution");
            }
            else
            {
                game.solution(board);
                Invalidate();
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            StartGame(levels[levelIndex]);
            Invalidate();
        }
    }
}
