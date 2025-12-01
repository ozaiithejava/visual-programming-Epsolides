namespace chapterOne
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox colorGroupBox;
        private System.Windows.Forms.RadioButton redRadio;
        private System.Windows.Forms.RadioButton blueRadio;
        private System.Windows.Forms.RadioButton greenRadio;
        private System.Windows.Forms.RadioButton blackRadio;
        private System.Windows.Forms.GroupBox sizeGroupBox;
        private System.Windows.Forms.RadioButton smallRadio;
        private System.Windows.Forms.RadioButton mediumRadio;
        private System.Windows.Forms.RadioButton largeRadio;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button undoButton;

        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorGroupBox = new System.Windows.Forms.GroupBox();
            this.blackRadio = new System.Windows.Forms.RadioButton();
            this.greenRadio = new System.Windows.Forms.RadioButton();
            this.blueRadio = new System.Windows.Forms.RadioButton();
            this.redRadio = new System.Windows.Forms.RadioButton();
            this.sizeGroupBox = new System.Windows.Forms.GroupBox();
            this.largeRadio = new System.Windows.Forms.RadioButton();
            this.mediumRadio = new System.Windows.Forms.RadioButton();
            this.smallRadio = new System.Windows.Forms.RadioButton();
            this.clearButton = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.colorGroupBox.SuspendLayout();
            this.sizeGroupBox.SuspendLayout();
            this.SuspendLayout();
            
            // pictureBox1
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 600);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            
            // colorGroupBox
            this.colorGroupBox.Controls.Add(this.blackRadio);
            this.colorGroupBox.Controls.Add(this.greenRadio);
            this.colorGroupBox.Controls.Add(this.blueRadio);
            this.colorGroupBox.Controls.Add(this.redRadio);
            this.colorGroupBox.Location = new System.Drawing.Point(830, 12);
            this.colorGroupBox.Name = "colorGroupBox";
            this.colorGroupBox.Size = new System.Drawing.Size(150, 150);
            this.colorGroupBox.TabIndex = 1;
            this.colorGroupBox.TabStop = false;
            this.colorGroupBox.Text = "Renk";
            
            // redRadio
            this.redRadio.AutoSize = true;
            this.redRadio.Location = new System.Drawing.Point(15, 30);
            this.redRadio.Name = "redRadio";
            this.redRadio.Size = new System.Drawing.Size(68, 21);
            this.redRadio.TabIndex = 0;
            this.redRadio.Text = "Kırmızı";
            this.redRadio.CheckedChanged += new System.EventHandler(this.redRadio_CheckedChanged);
            
            // blueRadio
            this.blueRadio.AutoSize = true;
            this.blueRadio.Location = new System.Drawing.Point(15, 60);
            this.blueRadio.Name = "blueRadio";
            this.blueRadio.Size = new System.Drawing.Size(54, 21);
            this.blueRadio.TabIndex = 1;
            this.blueRadio.Text = "Mavi";
            this.blueRadio.CheckedChanged += new System.EventHandler(this.blueRadio_CheckedChanged);
            
            // greenRadio
            this.greenRadio.AutoSize = true;
            this.greenRadio.Location = new System.Drawing.Point(15, 90);
            this.greenRadio.Name = "greenRadio";
            this.greenRadio.Size = new System.Drawing.Size(56, 21);
            this.greenRadio.TabIndex = 2;
            this.greenRadio.Text = "Yeşil";
            this.greenRadio.CheckedChanged += new System.EventHandler(this.greenRadio_CheckedChanged);
            
            // blackRadio
            this.blackRadio.AutoSize = true;
            this.blackRadio.Checked = true;
            this.blackRadio.Location = new System.Drawing.Point(15, 120);
            this.blackRadio.Name = "blackRadio";
            this.blackRadio.Size = new System.Drawing.Size(54, 21);
            this.blackRadio.TabIndex = 3;
            this.blackRadio.TabStop = true;
            this.blackRadio.Text = "Siyah";
            this.blackRadio.CheckedChanged += new System.EventHandler(this.blackRadio_CheckedChanged);
            
            // sizeGroupBox
            this.sizeGroupBox.Controls.Add(this.largeRadio);
            this.sizeGroupBox.Controls.Add(this.mediumRadio);
            this.sizeGroupBox.Controls.Add(this.smallRadio);
            this.sizeGroupBox.Location = new System.Drawing.Point(830, 180);
            this.sizeGroupBox.Name = "sizeGroupBox";
            this.sizeGroupBox.Size = new System.Drawing.Size(150, 130);
            this.sizeGroupBox.TabIndex = 2;
            this.sizeGroupBox.TabStop = false;
            this.sizeGroupBox.Text = "Boyut";
            
            // smallRadio
            this.smallRadio.AutoSize = true;
            this.smallRadio.Location = new System.Drawing.Point(15, 30);
            this.smallRadio.Name = "smallRadio";
            this.smallRadio.Size = new System.Drawing.Size(63, 21);
            this.smallRadio.TabIndex = 0;
            this.smallRadio.Text = "Küçük";
            this.smallRadio.CheckedChanged += new System.EventHandler(this.smallRadio_CheckedChanged);
            
            // mediumRadio
            this.mediumRadio.AutoSize = true;
            this.mediumRadio.Checked = true;
            this.mediumRadio.Location = new System.Drawing.Point(15, 60);
            this.mediumRadio.Name = "mediumRadio";
            this.mediumRadio.Size = new System.Drawing.Size(52, 21);
            this.mediumRadio.TabIndex = 1;
            this.mediumRadio.TabStop = true;
            this.mediumRadio.Text = "Orta";
            this.mediumRadio.CheckedChanged += new System.EventHandler(this.mediumRadio_CheckedChanged);
            
            // largeRadio
            this.largeRadio.AutoSize = true;
            this.largeRadio.Location = new System.Drawing.Point(15, 90);
            this.largeRadio.Name = "largeRadio";
            this.largeRadio.Size = new System.Drawing.Size(62, 21);
            this.largeRadio.TabIndex = 2;
            this.largeRadio.Text = "Büyük";
            this.largeRadio.CheckedChanged += new System.EventHandler(this.largeRadio_CheckedChanged);
            
            // clearButton
            this.clearButton.Location = new System.Drawing.Point(830, 330);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(150, 40);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Temizle";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            
            // undoButton
            this.undoButton.Location = new System.Drawing.Point(830, 380);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(150, 40);
            this.undoButton.TabIndex = 4;
            this.undoButton.Text = "Geri Al";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            
            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 630);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.sizeGroupBox);
            this.Controls.Add(this.colorGroupBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "WinForms Painter - ozaii";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.colorGroupBox.ResumeLayout(false);
            this.colorGroupBox.PerformLayout();
            this.sizeGroupBox.ResumeLayout(false);
            this.sizeGroupBox.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}