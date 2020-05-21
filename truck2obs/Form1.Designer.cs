namespace truck2obs
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.languageBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.customJobCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.customNoJobCheckBox = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 166);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 124);
            this.textBox1.TabIndex = 0;
            // 
            // languageBox1
            // 
            this.languageBox1.FormattingEnabled = true;
            this.languageBox1.Location = new System.Drawing.Point(8, 120);
            this.languageBox1.Name = "languageBox1";
            this.languageBox1.Size = new System.Drawing.Size(121, 21);
            this.languageBox1.TabIndex = 1;
            this.languageBox1.SelectedIndexChanged += new System.EventHandler(this.languageBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Language";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(846, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(308, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Window capture this area in OBS, or read c:\\tmp\\etsatsroute.txt";
            this.label2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(891, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(222, 130);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(154, 118);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(106, 23);
            this.colorButton.TabIndex = 5;
            this.colorButton.Text = "background color";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(-2, -3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(195, 81);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "debug info:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(279, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "foreground color";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(223, 190);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(528, 20);
            this.textBox2.TabIndex = 10;
            // 
            // customJobCheckBox
            // 
            this.customJobCheckBox.AutoSize = true;
            this.customJobCheckBox.Location = new System.Drawing.Point(223, 167);
            this.customJobCheckBox.Name = "customJobCheckBox";
            this.customJobCheckBox.Size = new System.Drawing.Size(97, 17);
            this.customJobCheckBox.TabIndex = 11;
            this.customJobCheckBox.Text = "custom job info";
            this.customJobCheckBox.UseVisualStyleBackColor = true;
            this.customJobCheckBox.CheckedChanged += new System.EventHandler(this.customJobTextBox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(416, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "@src = start city, @dest = destination city, @cargo = cargo, @dist = remaning dis" +
    "tance";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(348, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "... example: Transporting @cargo from @start to @dest. @dist remaining";
            // 
            // customNoJobCheckBox
            // 
            this.customNoJobCheckBox.AutoSize = true;
            this.customNoJobCheckBox.Location = new System.Drawing.Point(223, 241);
            this.customNoJobCheckBox.Name = "customNoJobCheckBox";
            this.customNoJobCheckBox.Size = new System.Drawing.Size(112, 17);
            this.customNoJobCheckBox.TabIndex = 14;
            this.customNoJobCheckBox.Text = "custom no-job info";
            this.customNoJobCheckBox.UseVisualStyleBackColor = true;
            this.customNoJobCheckBox.CheckedChanged += new System.EventHandler(this.customNoJobCheckBox_CheckedChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(223, 264);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(528, 20);
            this.textBox3.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(223, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "... example: Looking for a new job";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(199, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 33);
            this.label3.TabIndex = 7;
            this.label3.Text = "..";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(757, 190);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 21);
            this.button2.TabIndex = 17;
            this.button2.Text = "Apply";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(757, 264);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 20);
            this.button3.TabIndex = 18;
            this.button3.Text = "Apply";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.customNoJobCheckBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.customJobCheckBox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.languageBox1);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Truck2OBS v0.4";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox languageBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox customJobCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox customNoJobCheckBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

