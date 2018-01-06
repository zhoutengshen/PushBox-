namespace UILayer
{
    partial class MapFactory
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.box_targetImg = new System.Windows.Forms.PictureBox();
            this.role_targetImg = new System.Windows.Forms.PictureBox();
            this.box_target = new System.Windows.Forms.RadioButton();
            this.role_target = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lable2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.boxImg = new System.Windows.Forms.PictureBox();
            this.targetImg = new System.Windows.Forms.PictureBox();
            this.wallImg = new System.Windows.Forms.PictureBox();
            this.roleImg = new System.Windows.Forms.PictureBox();
            this.roadImg = new System.Windows.Forms.PictureBox();
            this.myBox = new System.Windows.Forms.RadioButton();
            this.target = new System.Windows.Forms.RadioButton();
            this.wall = new System.Windows.Forms.RadioButton();
            this.role = new System.Windows.Forms.RadioButton();
            this.road = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.box_targetImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.role_targetImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wallImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadImg)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.SaddleBrown;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Sienna;
            this.splitContainer1.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapFactory_MouseDown);
            this.splitContainer1.Panel1.MouseLeave += new System.EventHandler(this.MapFactory_MouseLeave);
            this.splitContainer1.Panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapFactory_MouseMove);
            this.splitContainer1.Panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapFactory_MouseUp);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button4);
            this.splitContainer1.Panel2.Controls.Add(this.box_targetImg);
            this.splitContainer1.Panel2.Controls.Add(this.role_targetImg);
            this.splitContainer1.Panel2.Controls.Add(this.box_target);
            this.splitContainer1.Panel2.Controls.Add(this.role_target);
            this.splitContainer1.Panel2.Controls.Add(this.button3);
            this.splitContainer1.Panel2.Controls.Add(this.textBox2);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.lable2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.boxImg);
            this.splitContainer1.Panel2.Controls.Add(this.targetImg);
            this.splitContainer1.Panel2.Controls.Add(this.wallImg);
            this.splitContainer1.Panel2.Controls.Add(this.roleImg);
            this.splitContainer1.Panel2.Controls.Add(this.roadImg);
            this.splitContainer1.Panel2.Controls.Add(this.myBox);
            this.splitContainer1.Panel2.Controls.Add(this.target);
            this.splitContainer1.Panel2.Controls.Add(this.wall);
            this.splitContainer1.Panel2.Controls.Add(this.role);
            this.splitContainer1.Panel2.Controls.Add(this.road);
            this.splitContainer1.Size = new System.Drawing.Size(813, 494);
            this.splitContainer1.SplitterDistance = 551;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // box_targetImg
            // 
            this.box_targetImg.Image = global::UILayer.Properties.Resources.box;
            this.box_targetImg.Location = new System.Drawing.Point(161, 154);
            this.box_targetImg.Name = "box_targetImg";
            this.box_targetImg.Size = new System.Drawing.Size(66, 65);
            this.box_targetImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.box_targetImg.TabIndex = 20;
            this.box_targetImg.TabStop = false;
            this.box_targetImg.Tag = "箱子_目标";
            this.box_targetImg.Click += new System.EventHandler(this.roadImg_Click);
            // 
            // role_targetImg
            // 
            this.role_targetImg.Image = global::UILayer.Properties.Resources.role;
            this.role_targetImg.Location = new System.Drawing.Point(161, 34);
            this.role_targetImg.Name = "role_targetImg";
            this.role_targetImg.Size = new System.Drawing.Size(66, 65);
            this.role_targetImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.role_targetImg.TabIndex = 19;
            this.role_targetImg.TabStop = false;
            this.role_targetImg.Tag = "角色_目标";
            this.role_targetImg.Click += new System.EventHandler(this.roadImg_Click);
            // 
            // box_target
            // 
            this.box_target.AutoSize = true;
            this.box_target.Location = new System.Drawing.Point(161, 132);
            this.box_target.Name = "box_target";
            this.box_target.Size = new System.Drawing.Size(77, 16);
            this.box_target.TabIndex = 18;
            this.box_target.Tag = "箱子_目标";
            this.box_target.Text = "箱子_目标";
            this.box_target.UseVisualStyleBackColor = true;
            this.box_target.CheckedChanged += new System.EventHandler(this.wall_CheckedChanged);
            // 
            // role_target
            // 
            this.role_target.AutoSize = true;
            this.role_target.Location = new System.Drawing.Point(161, 12);
            this.role_target.Name = "role_target";
            this.role_target.Size = new System.Drawing.Size(77, 16);
            this.role_target.TabIndex = 17;
            this.role_target.Tag = "角色_目标";
            this.role_target.Text = "角色_目标";
            this.role_target.UseVisualStyleBackColor = true;
            this.role_target.CheckedChanged += new System.EventHandler(this.wall_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(100, 429);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "确认行列数";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(130, 381);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(41, 21);
            this.textBox2.TabIndex = 15;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(43, 382);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(47, 21);
            this.textBox1.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 429);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "生成地图";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lable2
            // 
            this.lable2.AutoSize = true;
            this.lable2.Location = new System.Drawing.Point(96, 390);
            this.lable2.Name = "lable2";
            this.lable2.Size = new System.Drawing.Size(29, 12);
            this.lable2.TabIndex = 11;
            this.lable2.Text = "行数";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "列数";
            // 
            // boxImg
            // 
            this.boxImg.Image = global::UILayer.Properties.Resources.box;
            this.boxImg.Location = new System.Drawing.Point(69, 304);
            this.boxImg.Name = "boxImg";
            this.boxImg.Size = new System.Drawing.Size(66, 65);
            this.boxImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.boxImg.TabIndex = 9;
            this.boxImg.TabStop = false;
            this.boxImg.Tag = "箱子";
            this.boxImg.Click += new System.EventHandler(this.roadImg_Click);
            // 
            // targetImg
            // 
            this.targetImg.Image = global::UILayer.Properties.Resources.target;
            this.targetImg.Location = new System.Drawing.Point(69, 233);
            this.targetImg.Name = "targetImg";
            this.targetImg.Size = new System.Drawing.Size(66, 65);
            this.targetImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.targetImg.TabIndex = 8;
            this.targetImg.TabStop = false;
            this.targetImg.Tag = "目标";
            this.targetImg.Click += new System.EventHandler(this.roadImg_Click);
            // 
            // wallImg
            // 
            this.wallImg.Image = global::UILayer.Properties.Resources.wall;
            this.wallImg.Location = new System.Drawing.Point(69, 154);
            this.wallImg.Name = "wallImg";
            this.wallImg.Size = new System.Drawing.Size(66, 65);
            this.wallImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.wallImg.TabIndex = 7;
            this.wallImg.TabStop = false;
            this.wallImg.Tag = "墙";
            this.wallImg.Click += new System.EventHandler(this.roadImg_Click);
            // 
            // roleImg
            // 
            this.roleImg.Image = global::UILayer.Properties.Resources.role;
            this.roleImg.Location = new System.Drawing.Point(69, 83);
            this.roleImg.Name = "roleImg";
            this.roleImg.Size = new System.Drawing.Size(66, 65);
            this.roleImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.roleImg.TabIndex = 6;
            this.roleImg.TabStop = false;
            this.roleImg.Tag = "角色";
            this.roleImg.Click += new System.EventHandler(this.roadImg_Click);
            // 
            // roadImg
            // 
            this.roadImg.Image = global::UILayer.Properties.Resources.road;
            this.roadImg.Location = new System.Drawing.Point(69, 12);
            this.roadImg.Name = "roadImg";
            this.roadImg.Size = new System.Drawing.Size(66, 65);
            this.roadImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.roadImg.TabIndex = 5;
            this.roadImg.TabStop = false;
            this.roadImg.Tag = "路";
            this.roadImg.Click += new System.EventHandler(this.roadImg_Click);
            // 
            // myBox
            // 
            this.myBox.AutoSize = true;
            this.myBox.Location = new System.Drawing.Point(19, 315);
            this.myBox.Name = "myBox";
            this.myBox.Size = new System.Drawing.Size(47, 16);
            this.myBox.TabIndex = 4;
            this.myBox.Tag = "箱子";
            this.myBox.Text = "箱子";
            this.myBox.UseVisualStyleBackColor = true;
            this.myBox.CheckedChanged += new System.EventHandler(this.wall_CheckedChanged);
            // 
            // target
            // 
            this.target.AutoSize = true;
            this.target.Location = new System.Drawing.Point(19, 233);
            this.target.Name = "target";
            this.target.Size = new System.Drawing.Size(47, 16);
            this.target.TabIndex = 3;
            this.target.Tag = "目标";
            this.target.Text = "目标";
            this.target.UseVisualStyleBackColor = true;
            this.target.CheckedChanged += new System.EventHandler(this.wall_CheckedChanged);
            // 
            // wall
            // 
            this.wall.AutoSize = true;
            this.wall.Checked = true;
            this.wall.Location = new System.Drawing.Point(19, 154);
            this.wall.Name = "wall";
            this.wall.Size = new System.Drawing.Size(35, 16);
            this.wall.TabIndex = 2;
            this.wall.TabStop = true;
            this.wall.Tag = "墙";
            this.wall.Text = "墙";
            this.wall.UseVisualStyleBackColor = true;
            this.wall.CheckedChanged += new System.EventHandler(this.wall_CheckedChanged);
            // 
            // role
            // 
            this.role.AutoSize = true;
            this.role.Location = new System.Drawing.Point(19, 83);
            this.role.Name = "role";
            this.role.Size = new System.Drawing.Size(47, 16);
            this.role.TabIndex = 1;
            this.role.Tag = "角色";
            this.role.Text = "角色";
            this.role.UseVisualStyleBackColor = true;
            this.role.CheckedChanged += new System.EventHandler(this.wall_CheckedChanged);
            // 
            // road
            // 
            this.road.AutoSize = true;
            this.road.Location = new System.Drawing.Point(19, 12);
            this.road.Name = "road";
            this.road.Size = new System.Drawing.Size(35, 16);
            this.road.TabIndex = 0;
            this.road.Tag = "路";
            this.road.Text = "路";
            this.road.UseVisualStyleBackColor = true;
            this.road.CheckedChanged += new System.EventHandler(this.wall_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(69, 468);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 21;
            this.button4.Text = "退出";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // MapFactory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 494);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MapFactory";
            this.Text = "MapFactory";
            this.Load += new System.EventHandler(this.MapFactory_Load);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.box_targetImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.role_targetImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wallImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lable2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox boxImg;
        private System.Windows.Forms.PictureBox targetImg;
        private System.Windows.Forms.PictureBox wallImg;
        private System.Windows.Forms.PictureBox roleImg;
        private System.Windows.Forms.PictureBox roadImg;
        private System.Windows.Forms.RadioButton myBox;
        private System.Windows.Forms.RadioButton target;
        private System.Windows.Forms.RadioButton wall;
        private System.Windows.Forms.RadioButton role;
        private System.Windows.Forms.RadioButton road;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox role_targetImg;
        private System.Windows.Forms.RadioButton box_target;
        private System.Windows.Forms.RadioButton role_target;
        private System.Windows.Forms.PictureBox box_targetImg;
        private System.Windows.Forms.Button button4;
    }
}