namespace TheChatClient
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
            this.button1 = new System.Windows.Forms.Button();
            this.enterText = new System.Windows.Forms.TextBox();
            this.ViewTextBox = new System.Windows.Forms.RichTextBox();
            this.buttonR = new System.Windows.Forms.Button();
            this.buttonS = new System.Windows.Forms.Button();
            this.buttonP = new System.Windows.Forms.Button();
            this.pictureR = new System.Windows.Forms.PictureBox();
            this.pictureP = new System.Windows.Forms.PictureBox();
            this.pictureS = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureS)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(639, 379);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 59);
            this.button1.TabIndex = 0;
            this.button1.Text = "Enter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // enterText
            // 
            this.enterText.Location = new System.Drawing.Point(12, 379);
            this.enterText.Multiline = true;
            this.enterText.Name = "enterText";
            this.enterText.Size = new System.Drawing.Size(621, 59);
            this.enterText.TabIndex = 1;
            // 
            // ViewTextBox
            // 
            this.ViewTextBox.Location = new System.Drawing.Point(12, 12);
            this.ViewTextBox.Name = "ViewTextBox";
            this.ViewTextBox.Size = new System.Drawing.Size(776, 361);
            this.ViewTextBox.TabIndex = 2;
            this.ViewTextBox.Text = "";
            // 
            // buttonR
            // 
            this.buttonR.Location = new System.Drawing.Point(278, 600);
            this.buttonR.Name = "buttonR";
            this.buttonR.Size = new System.Drawing.Size(36, 34);
            this.buttonR.TabIndex = 3;
            this.buttonR.Text = "R";
            this.buttonR.UseVisualStyleBackColor = true;
            this.buttonR.Click += new System.EventHandler(this.buttonR_Click);
            // 
            // buttonS
            // 
            this.buttonS.Location = new System.Drawing.Point(477, 600);
            this.buttonS.Name = "buttonS";
            this.buttonS.Size = new System.Drawing.Size(36, 34);
            this.buttonS.TabIndex = 4;
            this.buttonS.Text = "S";
            this.buttonS.UseVisualStyleBackColor = true;
            this.buttonS.Click += new System.EventHandler(this.buttonS_Click);
            // 
            // buttonP
            // 
            this.buttonP.Location = new System.Drawing.Point(381, 600);
            this.buttonP.Name = "buttonP";
            this.buttonP.Size = new System.Drawing.Size(36, 34);
            this.buttonP.TabIndex = 5;
            this.buttonP.Text = "P";
            this.buttonP.UseVisualStyleBackColor = true;
            this.buttonP.Click += new System.EventHandler(this.buttonP_Click);
            // 
            // pictureR
            // 
            this.pictureR.Image = ((System.Drawing.Image)(resources.GetObject("pictureR.Image")));
            this.pictureR.Location = new System.Drawing.Point(246, 467);
            this.pictureR.Name = "pictureR";
            this.pictureR.Size = new System.Drawing.Size(94, 127);
            this.pictureR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureR.TabIndex = 6;
            this.pictureR.TabStop = false;
            this.pictureR.Visible = false;
            // 
            // pictureP
            // 
            this.pictureP.Image = ((System.Drawing.Image)(resources.GetObject("pictureP.Image")));
            this.pictureP.Location = new System.Drawing.Point(346, 467);
            this.pictureP.Name = "pictureP";
            this.pictureP.Size = new System.Drawing.Size(94, 127);
            this.pictureP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureP.TabIndex = 7;
            this.pictureP.TabStop = false;
            this.pictureP.Visible = false;
            // 
            // pictureS
            // 
            this.pictureS.Image = ((System.Drawing.Image)(resources.GetObject("pictureS.Image")));
            this.pictureS.Location = new System.Drawing.Point(446, 467);
            this.pictureS.Name = "pictureS";
            this.pictureS.Size = new System.Drawing.Size(94, 127);
            this.pictureS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureS.TabIndex = 8;
            this.pictureS.TabStop = false;
            this.pictureS.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(583, 588);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 58);
            this.button2.TabIndex = 9;
            this.button2.Text = "Reset Game";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 659);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureS);
            this.Controls.Add(this.pictureP);
            this.Controls.Add(this.pictureR);
            this.Controls.Add(this.buttonP);
            this.Controls.Add(this.buttonS);
            this.Controls.Add(this.buttonR);
            this.Controls.Add(this.ViewTextBox);
            this.Controls.Add(this.enterText);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Chat Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox enterText;
        private System.Windows.Forms.RichTextBox ViewTextBox;
        private System.Windows.Forms.Button buttonR;
        private System.Windows.Forms.Button buttonS;
        private System.Windows.Forms.Button buttonP;
        private System.Windows.Forms.PictureBox pictureR;
        private System.Windows.Forms.PictureBox pictureP;
        private System.Windows.Forms.PictureBox pictureS;
        private System.Windows.Forms.Button button2;
    }
}

