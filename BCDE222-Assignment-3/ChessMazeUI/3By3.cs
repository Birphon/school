using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChessMazeUI
{
    public partial class Form1 : Form
    {
        private readonly Image _blank = ChessMazeUI.Properties.Resources.Blank;
        private readonly Image _king = ChessMazeUI.Properties.Resources.King;
        private readonly Image _knight = ChessMazeUI.Properties.Resources.Knight;
        private readonly Image _rook = ChessMazeUI.Properties.Resources.Rook;
        private readonly Image _bishop = ChessMazeUI.Properties.Resources.Bishop;
        private int _currentPosition = 0;
        private readonly Button[] _gridOfButtons;
        private int _count = 0;

        private bool finishButton = false;
        private string lblChange = "Rook";
        public Form1()
        {
            InitializeComponent();
            this.Text = "3x3 Game";
            MoveLbl.Text = "Move count is: 0";
            lblChange = "Rook";
            _gridOfButtons = new Button[] { button1, button4, button7, button2, button5, button8, button3, button6, button9 };            

            button1.BackgroundImage = _rook;
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            lblChange = "Rook";

            button2.BackgroundImage = _blank;
            button2.BackgroundImageLayout = ImageLayout.Zoom;
            lblChange = "Empty";

            button3.BackgroundImage = _knight;
            button3.BackgroundImageLayout = ImageLayout.Zoom;
            lblChange = "Knight";

            button4.BackgroundImage = _blank;
            button4.BackgroundImageLayout = ImageLayout.Zoom;
            lblChange = "Empty";

            button5.BackgroundImage = _blank;
            button5.BackgroundImageLayout = ImageLayout.Zoom;
            lblChange = "Empty";

            button6.BackgroundImage = _rook;
            button6.BackgroundImageLayout = ImageLayout.Zoom;
            lblChange = "Rook";

            button7.BackgroundImage = _bishop;
            button7.BackgroundImageLayout = ImageLayout.Zoom;
            lblChange = "Bishop";

            button8.BackgroundImage = _bishop;
            button8.BackgroundImageLayout = ImageLayout.Zoom;
            lblChange = "Bishop";

            button9.BackgroundImage = _king;
            button9.BackgroundImageLayout = ImageLayout.Zoom;
            lblChange = "King";
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
                BackgroundImage = _blank,
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
                btnNew.BackgroundImage = _blank;
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

        public void ButtonImage()
        {
            if (button1 != _gridOfButtons[_currentPosition])
            {
                button1.BackgroundImage = _rook;
            }
            if (button2 != _gridOfButtons[_currentPosition])
            {
                button1.BackgroundImage = _blank;
            }
            if (button3 != _gridOfButtons[_currentPosition])
            {
                button3.BackgroundImage = _knight;
            }
            if (button4 != _gridOfButtons[_currentPosition])
            {
                button4.BackgroundImage = _blank;
            }
            if (button5 != _gridOfButtons[_currentPosition])
            {
                button5.BackgroundImage = _blank;
            }
            if (button6 != _gridOfButtons[_currentPosition])
            {
                button6.BackgroundImage = _rook;
            }
            if (button7 != _gridOfButtons[_currentPosition])
            {
                button7.BackgroundImage = _bishop;
            }
            if (button8 != _gridOfButtons[_currentPosition])
            {
                button8.BackgroundImage = _bishop;
            }
            if (button9 != _gridOfButtons[_currentPosition])
            {
                button9.BackgroundImage = _king;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            MoveCount();
            Button button = (Button)sender;
            Text = $"Button {button.Name.Replace("button", "")} has been clicked.";
            CurrentPiece.Text = lblChange;

            _gridOfButtons[_currentPosition] = button;
            if (sender == button9)
            {
                finishButton = true;
                string message = "You Won!";
                string title = "Farming W's";
                MessageBox.Show(message, title);
            }
            ButtonImage();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            this.Hide();
            mm.Show();
        }
    }
}
