﻿namespace ElevatorTest
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
            pnLeftDoor = new Panel();
            pnRightDoor = new Panel();
            button1 = new Button();
            lblFloor = new Label();
            SuspendLayout();
            // 
            // pnLeftDoor
            // 
            pnLeftDoor.BackColor = Color.Gray;
            pnLeftDoor.Location = new Point(105, 98);
            pnLeftDoor.Name = "pnLeftDoor";
            pnLeftDoor.Size = new Size(115, 205);
            pnLeftDoor.TabIndex = 0;
            // 
            // pnRightDoor
            // 
            pnRightDoor.BackColor = Color.Gray;
            pnRightDoor.Location = new Point(226, 98);
            pnRightDoor.Name = "pnRightDoor";
            pnRightDoor.Size = new Size(115, 205);
            pnRightDoor.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(185, 328);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblFloor
            // 
            lblFloor.BackColor = Color.Black;
            lblFloor.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblFloor.ForeColor = Color.Red;
            lblFloor.Location = new Point(207, 78);
            lblFloor.Name = "lblFloor";
            lblFloor.Size = new Size(30, 15);
            lblFloor.TabIndex = 3;
            lblFloor.Text = "1";
            lblFloor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 386);
            Controls.Add(lblFloor);
            Controls.Add(button1);
            Controls.Add(pnRightDoor);
            Controls.Add(pnLeftDoor);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel pnLeftDoor;
        private Panel pnRightDoor;
        private Button button1;
        private Label lblFloor;
    }
}
