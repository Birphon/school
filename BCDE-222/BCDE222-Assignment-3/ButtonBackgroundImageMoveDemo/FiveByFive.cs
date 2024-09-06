using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessMazeUI
{
    public partial class FiveByFive : Form
    {
        private readonly Image _background = ChessMazeUI.Properties.Resources.Blank;
        private readonly Image _king = ChessMazeUI.Properties.Resources.King;
        private readonly Image _knight = ChessMazeUI.Properties.Resources.Knight;
        private readonly Image _rook = ChessMazeUI.Properties.Resources.Rook;
        private readonly Image _bishop = ChessMazeUI.Properties.Resources.Bishop;

        private int _count = 0;
        private int _currentPosition = 0;

        private string _clickedText;

        public FiveByFive()
        {
            InitializeComponent();
            this.Text = "5x5 Game";
        }

        private int MoveCount()
        {
            _count++;
            MoveLbl.Text = $"Move count is: {_count}";
            return _count;
        }

        protected void DefaultButton()
        {
            Button btnNew = new()
            {
                Name = "btn",
                Height = 50,
                Width = 50,
                Text = "E",
                BackgroundImage = _background,
                BackgroundImageLayout = ImageLayout.Zoom,
                Visible = true,
                Location = new Point(10, 10)
            };

            Controls.Add(btnNew);
        }

        protected void ButtonGen(string name, string text, int row, int column)
        {
            Button btnNew = new();
            btnNew.Name = name + column.ToString() + "_" + row.ToString();
            btnNew.Height = 50;
            btnNew.Width = 50;
            btnNew.Font = new Font("Arial", 20);
            btnNew.Text = text;
            btnNew.Visible = true;
            int margin = 10;
            btnNew.Location = new Point(margin + btnNew.Height * row, margin + btnNew.Width * column);
            this.Controls.Add(btnNew);

            if (btnNew.Text == "#")
            {
                btnNew.BackgroundImage = _background;
            }
            else if (btnNew.Text == "$")
            {
                btnNew.BackgroundImage = _rook;
            }
            else if (btnNew.Text == "%")
            {
                btnNew.BackgroundImage = _bishop;
            }
            else if (btnNew.Text == "'")
            {
                btnNew.BackgroundImage = _knight;
            }
            else if (btnNew.Text == "@")
            {
                btnNew.BackgroundImage = _king;
            }
        }

        protected void SetClicks()
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

        private void Make5x5Level_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; ++i)
            {
                for (int j = 0; j < 5; ++j)
                {
                    ButtonGen("btn_", " ", i, j);
                }
            }
            Control c = Controls.Find("btn_2_3", true)[0];
            var b = c as Button;
            b.Text = "@";
        }

        private void AddParts_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < 6; ++i)
            {
                for (var j = 6; j < 7; ++j)
                {
                    ButtonGen("iptBtn_", ((char)(35 + i)).ToString(), i, j);
                }
            }

            SetClicks();
        }

        protected void WhoClicked(object sender, EventArgs e)
        {
            Button btnWho = sender as Button;

            Text = btnWho.Name;

            if (btnWho.Name.StartsWith("btn"))
            {
                btnWho.Text = _clickedText;
            }
            else if (btnWho.Name.StartsWith("iptBtn_"))
            {
                _clickedText = btnWho.Text;
            }
        }
    }
}
