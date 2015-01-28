namespace ITI.bacASable
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._richTextBox = new System.Windows.Forms.RichTextBox();
            this._panelNum = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._pictureBox2 = new System.Windows.Forms.PictureBox();
            this._groupBox3 = new System.Windows.Forms.GroupBox();
            this._pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this._butStepByStep = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this._butContinue = new System.Windows.Forms.Button();
            this._butStop = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this._butStartAll = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox2)).BeginInit();
            this._groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(608, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // _fileToolStripMenuItem
            // 
            this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.quitToolStripMenuItem});
            this._fileToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
            this._fileToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this._fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadToolStripMenuItem.Image = global::ITI.Properties.Resources.ouvrir;
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveToolStripMenuItem.Image = global::ITI.Properties.Resources.enregistrer;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitToolStripMenuItem.Image = global::ITI.Properties.Resources.fermer;
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(8, 23);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(596, 384);
            this.splitContainer1.SplitterDistance = 245;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this._richTextBox);
            this.groupBox1.Controls.Add(this._panelNum);
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(-1, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 380);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit";
            // 
            // _richTextBox
            // 
            this._richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._richTextBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._richTextBox.Location = new System.Drawing.Point(39, 13);
            this._richTextBox.Name = "_richTextBox";
            this._richTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this._richTextBox.Size = new System.Drawing.Size(201, 363);
            this._richTextBox.TabIndex = 3;
            this._richTextBox.Text = "";
            // 
            // _panelNum
            // 
            this._panelNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._panelNum.Location = new System.Drawing.Point(4, 13);
            this._panelNum.Name = "_panelNum";
            this._panelNum.Size = new System.Drawing.Size(30, 363);
            this._panelNum.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this._groupBox3);
            this.splitContainer2.Panel2.Controls.Add(this.textBox2);
            this.splitContainer2.Size = new System.Drawing.Size(347, 384);
            this.splitContainer2.SplitterDistance = 157;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer2_SplitterMoved);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this._pictureBox2);
            this.groupBox2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 149);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Console";
            // 
            // _pictureBox2
            // 
            this._pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pictureBox2.Location = new System.Drawing.Point(1, 13);
            this._pictureBox2.Name = "_pictureBox2";
            this._pictureBox2.Size = new System.Drawing.Size(334, 136);
            this._pictureBox2.TabIndex = 0;
            this._pictureBox2.TabStop = false;
            // 
            // _groupBox3
            // 
            this._groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._groupBox3.Controls.Add(this._pictureBox1);
            this._groupBox3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._groupBox3.Location = new System.Drawing.Point(2, 3);
            this._groupBox3.Name = "_groupBox3";
            this._groupBox3.Size = new System.Drawing.Size(340, 219);
            this._groupBox3.TabIndex = 1;
            this._groupBox3.TabStop = false;
            this._groupBox3.Text = "Stack";
            // 
            // _pictureBox1
            // 
            this._pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pictureBox1.Location = new System.Drawing.Point(1, 21);
            this._pictureBox1.Name = "_pictureBox1";
            this._pictureBox1.Size = new System.Drawing.Size(335, 194);
            this._pictureBox1.TabIndex = 0;
            this._pictureBox1.TabStop = false;
            this._pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this._pictureBox1_Paint);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(3, -134);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(117, 96);
            this.textBox2.TabIndex = 0;
            // 
            // _butStepByStep
            // 
            this._butStepByStep.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this._butStepByStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._butStepByStep.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._butStepByStep.Image = global::ITI.Properties.Resources.skip_to_start_15px;
            this._butStepByStep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._butStepByStep.Location = new System.Drawing.Point(101, 1);
            this._butStepByStep.Name = "_butStepByStep";
            this._butStepByStep.Size = new System.Drawing.Size(117, 23);
            this._butStepByStep.TabIndex = 2;
            this._butStepByStep.Text = "Step by step";
            this._butStepByStep.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._butStepByStep.UseVisualStyleBackColor = true;
            this._butStepByStep.Click += new System.EventHandler(this.butStepByStep_Click);
            // 
            // _butContinue
            // 
            this._butContinue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this._butContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._butContinue.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._butContinue.Image = ((System.Drawing.Image)(resources.GetObject("_butContinue.Image")));
            this._butContinue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._butContinue.Location = new System.Drawing.Point(297, 0);
            this._butContinue.Name = "_butContinue";
            this._butContinue.Size = new System.Drawing.Size(83, 23);
            this._butContinue.TabIndex = 5;
            this._butContinue.Text = "Continue";
            this._butContinue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._butContinue.UseVisualStyleBackColor = true;
            this._butContinue.Visible = false;
            this._butContinue.Click += new System.EventHandler(this.butContinue_Click);
            // 
            // _butStop
            // 
            this._butStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this._butStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._butStop.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._butStop.Image = ((System.Drawing.Image)(resources.GetObject("_butStop.Image")));
            this._butStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._butStop.Location = new System.Drawing.Point(386, 0);
            this._butStop.Name = "_butStop";
            this._butStop.Size = new System.Drawing.Size(56, 23);
            this._butStop.TabIndex = 6;
            this._butStop.Text = "Stop";
            this._butStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._butStop.UseVisualStyleBackColor = true;
            this._butStop.Visible = false;
            this._butStop.Click += new System.EventHandler(this.butStop_Click);
            // 
            // _butStartAll
            // 
            this._butStartAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this._butStartAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._butStartAll.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._butStartAll.Image = global::ITI.Properties.Resources.skip_to_start_15px_1_;
            this._butStartAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._butStartAll.Location = new System.Drawing.Point(224, 0);
            this._butStartAll.Name = "_butStartAll";
            this._butStartAll.Size = new System.Drawing.Size(67, 23);
            this._butStartAll.TabIndex = 3;
            this._butStartAll.Text = "Start";
            this._butStartAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._butStartAll.UseVisualStyleBackColor = true;
            this._butStartAll.Click += new System.EventHandler(this.butStartAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 408);
            this.Controls.Add(this._butStop);
            this.Controls.Add(this._butContinue);
            this.Controls.Add(this._butStartAll);
            this.Controls.Add(this._butStepByStep);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Cil-Cowding";
            this.Load += new System.EventHandler(this.TextEditor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox2)).EndInit();
            this._groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox _groupBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button _butStepByStep;
        private System.Windows.Forms.PictureBox _pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button _butContinue;
        private System.Windows.Forms.Button _butStop;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox _pictureBox2;
        private System.Windows.Forms.RichTextBox _richTextBox;
        private System.Windows.Forms.Panel _panelNum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _butStartAll;
    }
}

