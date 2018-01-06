namespace UILayer
{
    partial class GameMenuForm
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
            this.btnNextPass = new System.Windows.Forms.Button();
            this.btnPrePass = new System.Windows.Forms.Button();
            this.btnChosePass = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNextPass
            // 
            this.btnNextPass.BackColor = System.Drawing.Color.Maroon;
            this.btnNextPass.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnNextPass.Location = new System.Drawing.Point(31, 54);
            this.btnNextPass.Name = "btnNextPass";
            this.btnNextPass.Size = new System.Drawing.Size(75, 23);
            this.btnNextPass.TabIndex = 0;
            this.btnNextPass.Text = "下一关";
            this.btnNextPass.UseVisualStyleBackColor = false;
            this.btnNextPass.Click += new System.EventHandler(this.btnNextPass_Click);
            // 
            // btnPrePass
            // 
            this.btnPrePass.BackColor = System.Drawing.Color.Maroon;
            this.btnPrePass.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnPrePass.Location = new System.Drawing.Point(31, 134);
            this.btnPrePass.Name = "btnPrePass";
            this.btnPrePass.Size = new System.Drawing.Size(75, 23);
            this.btnPrePass.TabIndex = 1;
            this.btnPrePass.Text = "前一关";
            this.btnPrePass.UseVisualStyleBackColor = false;
            this.btnPrePass.Click += new System.EventHandler(this.btnPrePass_Click);
            // 
            // btnChosePass
            // 
            this.btnChosePass.BackColor = System.Drawing.Color.Maroon;
            this.btnChosePass.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnChosePass.Location = new System.Drawing.Point(31, 282);
            this.btnChosePass.Name = "btnChosePass";
            this.btnChosePass.Size = new System.Drawing.Size(75, 23);
            this.btnChosePass.TabIndex = 2;
            this.btnChosePass.Text = "关卡选择";
            this.btnChosePass.UseVisualStyleBackColor = false;
            this.btnChosePass.Click += new System.EventHandler(this.btnChosePass_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Maroon;
            this.button3.ForeColor = System.Drawing.Color.Cornsilk;
            this.button3.Location = new System.Drawing.Point(31, 214);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 21);
            this.button3.TabIndex = 5;
            this.button3.Text = "后退";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Maroon;
            this.button4.ForeColor = System.Drawing.Color.Cornsilk;
            this.button4.Location = new System.Drawing.Point(31, 342);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "重新开始";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Maroon;
            this.button2.BackgroundImage = global::UILayer.Properties.Resources._1;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.ForeColor = System.Drawing.Color.Cornsilk;
            this.button2.Location = new System.Drawing.Point(2, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 23);
            this.button2.TabIndex = 8;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.BackgroundImage = global::UILayer.Properties.Resources._2;
            this.button1.ForeColor = System.Drawing.Color.Cornsilk;
            this.button1.Location = new System.Drawing.Point(33, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 23);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GameMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.ClientSize = new System.Drawing.Size(210, 436);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnChosePass);
            this.Controls.Add(this.btnPrePass);
            this.Controls.Add(this.btnNextPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameMenuForm";
            this.Opacity = 0.4D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "GameMenu";
            this.MouseLeave += new System.EventHandler(this.GameMenuForm_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNextPass;
        private System.Windows.Forms.Button btnPrePass;
        private System.Windows.Forms.Button btnChosePass;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}