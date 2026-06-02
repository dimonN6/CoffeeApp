namespace CoffeeApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btnCheck;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            btnCheck = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.AllowDrop = true;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(30, 30);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.AllowDrop = true;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(180, 30);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(150, 150);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.AllowDrop = true;
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.Location = new Point(30, 180);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(150, 150);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.AllowDrop = true;
            pictureBox4.BorderStyle = BorderStyle.FixedSingle;
            pictureBox4.Location = new Point(180, 180);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(150, 150);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 3;
            pictureBox4.TabStop = false;
            // 
            // btnCheck
            // 
            btnCheck.BackColor = Color.LightBlue;
            btnCheck.FlatStyle = FlatStyle.Flat;
            btnCheck.Location = new Point(126, 336);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(100, 35);
            btnCheck.TabIndex = 4;
            btnCheck.Text = "Проверить";
            btnCheck.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            ClientSize = new Size(400, 480);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox4);
            Controls.Add(btnCheck);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimumSize = new Size(400, 480);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Собери пазл (1-2-3-4)";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
        }
    }
}