using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using Interfaces;
using Brock_AssignmentTwo;


namespace LevelForm
{
    public partial class Form1 : Form
    {
        private readonly Image Bishop = LevelForm.Properties.Resources.Bishop;
        private readonly Image Empty = LevelForm.Properties.Resources.Blank;
        private readonly Image King = LevelForm.Properties.Resources.King;
        private readonly Image Knight = LevelForm.Properties.Resources.Knight;
        private readonly Image Queen = LevelForm.Properties.Resources.Queen;
        private readonly Image Rook = LevelForm.Properties.Resources.Rook;

        private Image _clickedImage;
        private Part currentPiece;
        private int counter = 0;

        public int _width;
        private Part[,] _level;
        private int _height;
        private string levelValidSatement;

        private int levelsMade = 0;
        private int xPlayerValue = 0;
        private int yPlayerValue = 0;
        private int goalX;
        private int goalY;
        private int totalNumOfGoals = 0;
        private int playerCount = 0;

        private string saved_level;
        private int saved_height;
        private int saved_width;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Level Designer";
        }

        protected void MakeButtons()
        {
            Button btnNew = new()
            {
                Name = "btn",
                Height = 50,
                Width = 50,
                Image = Empty,
                Visible = true,
                Location = new Point(10, 10)
            };

            Controls.Add(btnNew);
        }

        protected void MakeButtons2(string name, Image image, int row, int column)
        {
            Button btnNew = new();

            btnNew.Name = name + column.ToString() + "_" + row.ToString();            //@ location
            btnNew.Height = 50;                                                       //btn size
            btnNew.Width = 50;                                                        //btn size
            btnNew.Image = image;
            _level[column, row] = currentPiece;


            int marginWidth = 200;
            int marginHeight = 80;
            btnNew.Location = new Point(marginWidth + btnNew.Height * row,
                marginHeight + btnNew.Width * column);

            this.Controls.Add(btnNew);
        }

        protected void WhoClicked(object sender, EventArgs e)
        {
            Button btnWho = sender as Button;


            if (btnWho.Name.StartsWith("btn"))
            {
                btnWho.Image = _clickedImage;
            }
            else if (btnWho.Name.StartsWith("iptBtn_"))
            {
                _clickedImage = btnWho.Image;
            }
        }

        private void CreateLevel_Click(object sender, EventArgs e)
        {
            currentPiece = Part.Empty;
            _clickedImage = Empty;
            try
            {
                int _height = Convert.ToInt32(enterHeight.Text);
                int _width = Convert.ToInt32(enterWidth.Text);
                _level = new Part[_height, _width];
                if (_height < 8 && _width < 8 && _height > 1 && _width > 2)
                {
                    // Width
                    for (int x = 0; x < _width; ++x)
                    {
                        // Height
                        for (int y = 0; y < _height; ++y)
                        {

                            MakeButtons2("btn_", _clickedImage, x, y);
                            _level[y, x] = currentPiece;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please use a numbers between 1 and 8");
                }
                goalX = _width;
                goalY = _height;
                totalNumOfGoals++;
            }
            catch (FormatException)
            {
                MessageBox.Show("Please use a numbers between 1 and 8");
            }
        }

        private void AddBishop_Click(object sender, EventArgs e)
        {
            _clickedImage = Bishop;
            currentPiece = Part.Bishop;
        }

        private void AddBlank_Click(object sender, EventArgs e)
        {
            _clickedImage = Empty;
            currentPiece = Part.Empty;
        }

        private void AddKing_Click(object sender, EventArgs e)
        {
            _clickedImage = King;
            currentPiece = Part.King;
        }

        private void AddKnight_Click(object sender, EventArgs e)
        {
            _clickedImage = Knight;
            currentPiece = Part.Knight;
        }

        private void AddQueen_Click(object sender, EventArgs e)
        {
            _clickedImage = Queen;
            currentPiece = Part.Queen;
        }

        private void AddRook_Click(object sender, EventArgs e)
        {
            _clickedImage = Rook;
            currentPiece = Part.Rook;
        }

        private void SelectPiece_Click_1(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is Button)
                {
                    Button who = c as Button;
                    who.Click += WhoClicked;
                }
            }
        }

        private void SaveMe_Click(object sender, EventArgs e)
        {
            saved_height = GetLevelHeight();
            saved_width = GetLevelWidth();
            using var sw = new StreamWriter(@"C:\Temp\C#\BCDE222-AssignmentThree-JaredIreland\Saves\SavedLevel.txt");
            for (int x = 0; x < saved_width; x++)
            {
                for (int y = 0; y < saved_height; y++)
                {
                    sw.Write(_level[y, x] + " ");
                }
                sw.Write("\n");
            }
        }

        public int GetLevelHeight()                                                             //Feature 13 Get Level Height
        {
            _height = _level.GetLength(0);
            return _height;
        }

        public int GetLevelWidth()                                                              //Feature 12 Get Level Width
        {
            _width = _level.GetLength(1);
            return _width;
        }

        private void LoadMe_Click(object sender, EventArgs e)
        {
            string text = System.IO.File.ReadAllText(@"C:\Temp\C#\BCDE222-AssignmentThree-JaredIreland\Saves\SavedLevel.txt");
            string[] lvlLoader1 = text.Split(' ');
            int lvlIndex = 0;
            int lvlWidth = saved_width;
            int lvlHeight = saved_height;
            MakeButtons2("btn_", _clickedImage, lvlWidth, lvlHeight);
            for (int x = 0; x < lvlWidth; ++x)                                    //width
            {
                for (int y = 0; y < lvlHeight; ++y)                               //height
                {
                    Part lvlLoader2 = (Part)Enum.Parse(typeof(Part), lvlLoader1[lvlIndex], true);
                    _level[x, y] = lvlLoader2;
                    lvlIndex++;
                }
            }
        }
    }
}
