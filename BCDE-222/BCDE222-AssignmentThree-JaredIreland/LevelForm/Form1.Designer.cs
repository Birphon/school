
namespace LevelForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Title = new System.Windows.Forms.Label();
            this.enterWidth = new System.Windows.Forms.TextBox();
            this.enterHeight = new System.Windows.Forms.TextBox();
            this.createLevel = new System.Windows.Forms.Button();
            this.AddBishop = new System.Windows.Forms.Button();
            this.AddBlank = new System.Windows.Forms.Button();
            this.AddKing = new System.Windows.Forms.Button();
            this.AddKnight = new System.Windows.Forms.Button();
            this.AddQueen = new System.Windows.Forms.Button();
            this.AddRook = new System.Windows.Forms.Button();
            this.SelectPiece = new System.Windows.Forms.Button();
            this.SaveMe = new System.Windows.Forms.Button();
            this.LoadMe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Title.Location = new System.Drawing.Point(12, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(190, 37);
            this.Title.TabIndex = 0;
            this.Title.Text = "Level Designer";
            // 
            // enterWidth
            // 
            this.enterWidth.Location = new System.Drawing.Point(672, 35);
            this.enterWidth.Name = "enterWidth";
            this.enterWidth.Size = new System.Drawing.Size(94, 23);
            this.enterWidth.TabIndex = 1;
            this.enterWidth.Text = "Enter Width";
            // 
            // enterHeight
            // 
            this.enterHeight.Location = new System.Drawing.Point(672, 64);
            this.enterHeight.Name = "enterHeight";
            this.enterHeight.Size = new System.Drawing.Size(94, 23);
            this.enterHeight.TabIndex = 2;
            this.enterHeight.Text = "Enter Height";
            // 
            // createLevel
            // 
            this.createLevel.Location = new System.Drawing.Point(672, 93);
            this.createLevel.Name = "createLevel";
            this.createLevel.Size = new System.Drawing.Size(94, 23);
            this.createLevel.TabIndex = 3;
            this.createLevel.Text = "Create Level";
            this.createLevel.UseVisualStyleBackColor = true;
            this.createLevel.Click += new System.EventHandler(this.CreateLevel_Click);
            // 
            // AddBishop
            // 
            this.AddBishop.Location = new System.Drawing.Point(672, 204);
            this.AddBishop.Name = "AddBishop";
            this.AddBishop.Size = new System.Drawing.Size(94, 23);
            this.AddBishop.TabIndex = 4;
            this.AddBishop.Text = "Add Bishop";
            this.AddBishop.UseVisualStyleBackColor = true;
            this.AddBishop.Click += new System.EventHandler(this.AddBishop_Click);
            // 
            // AddBlank
            // 
            this.AddBlank.Location = new System.Drawing.Point(672, 233);
            this.AddBlank.Name = "AddBlank";
            this.AddBlank.Size = new System.Drawing.Size(94, 23);
            this.AddBlank.TabIndex = 5;
            this.AddBlank.Text = "Add Blank";
            this.AddBlank.UseVisualStyleBackColor = true;
            this.AddBlank.Click += new System.EventHandler(this.AddBlank_Click);
            // 
            // AddKing
            // 
            this.AddKing.Location = new System.Drawing.Point(672, 262);
            this.AddKing.Name = "AddKing";
            this.AddKing.Size = new System.Drawing.Size(94, 23);
            this.AddKing.TabIndex = 6;
            this.AddKing.Text = "Add King";
            this.AddKing.UseVisualStyleBackColor = true;
            this.AddKing.Click += new System.EventHandler(this.AddKing_Click);
            // 
            // AddKnight
            // 
            this.AddKnight.Location = new System.Drawing.Point(672, 291);
            this.AddKnight.Name = "AddKnight";
            this.AddKnight.Size = new System.Drawing.Size(94, 23);
            this.AddKnight.TabIndex = 7;
            this.AddKnight.Text = "Add Knight";
            this.AddKnight.UseVisualStyleBackColor = true;
            this.AddKnight.Click += new System.EventHandler(this.AddKnight_Click);
            // 
            // AddQueen
            // 
            this.AddQueen.Location = new System.Drawing.Point(672, 320);
            this.AddQueen.Name = "AddQueen";
            this.AddQueen.Size = new System.Drawing.Size(94, 23);
            this.AddQueen.TabIndex = 8;
            this.AddQueen.Text = "Add Queen";
            this.AddQueen.UseVisualStyleBackColor = true;
            this.AddQueen.Click += new System.EventHandler(this.AddQueen_Click);
            // 
            // AddRook
            // 
            this.AddRook.Location = new System.Drawing.Point(672, 349);
            this.AddRook.Name = "AddRook";
            this.AddRook.Size = new System.Drawing.Size(94, 23);
            this.AddRook.TabIndex = 9;
            this.AddRook.Text = "Add Rook";
            this.AddRook.UseVisualStyleBackColor = true;
            this.AddRook.Click += new System.EventHandler(this.AddRook_Click);
            // 
            // SelectPiece
            // 
            this.SelectPiece.Location = new System.Drawing.Point(672, 160);
            this.SelectPiece.Name = "SelectPiece";
            this.SelectPiece.Size = new System.Drawing.Size(94, 27);
            this.SelectPiece.TabIndex = 10;
            this.SelectPiece.Text = "Select Piece";
            this.SelectPiece.UseVisualStyleBackColor = true;
            this.SelectPiece.Click += new System.EventHandler(this.SelectPiece_Click_1);
            // 
            // SaveMe
            // 
            this.SaveMe.Location = new System.Drawing.Point(672, 452);
            this.SaveMe.Name = "SaveMe";
            this.SaveMe.Size = new System.Drawing.Size(94, 23);
            this.SaveMe.TabIndex = 11;
            this.SaveMe.Text = "Save";
            this.SaveMe.UseVisualStyleBackColor = true;
            this.SaveMe.Click += new System.EventHandler(this.SaveMe_Click);
            // 
            // LoadMe
            // 
            this.LoadMe.Location = new System.Drawing.Point(672, 423);
            this.LoadMe.Name = "LoadMe";
            this.LoadMe.Size = new System.Drawing.Size(94, 23);
            this.LoadMe.TabIndex = 12;
            this.LoadMe.Text = "Load";
            this.LoadMe.UseVisualStyleBackColor = true;
            this.LoadMe.Click += new System.EventHandler(this.LoadMe_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 487);
            this.Controls.Add(this.LoadMe);
            this.Controls.Add(this.SaveMe);
            this.Controls.Add(this.SelectPiece);
            this.Controls.Add(this.AddRook);
            this.Controls.Add(this.AddQueen);
            this.Controls.Add(this.AddKnight);
            this.Controls.Add(this.AddKing);
            this.Controls.Add(this.AddBlank);
            this.Controls.Add(this.AddBishop);
            this.Controls.Add(this.createLevel);
            this.Controls.Add(this.enterHeight);
            this.Controls.Add(this.enterWidth);
            this.Controls.Add(this.Title);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.TextBox enterWidth;
        private System.Windows.Forms.TextBox enterHeight;
        private System.Windows.Forms.Button createLevel;
        private System.Windows.Forms.Button AddBishop;
        private System.Windows.Forms.Button AddBlank;
        private System.Windows.Forms.Button AddKing;
        private System.Windows.Forms.Button AddKnight;
        private System.Windows.Forms.Button AddQueen;
        private System.Windows.Forms.Button AddRook;
        private System.Windows.Forms.Button SelectPiece;
        private System.Windows.Forms.Button SaveMe;
        private System.Windows.Forms.Button LoadMe;
    }
}

