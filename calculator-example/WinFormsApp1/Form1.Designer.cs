using System.Diagnostics.Tracing;

namespace WinFormsApp1;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

 
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code
    
    private void ApplyDarkTheme()
    {
        // Genel arka plan ve yazı rengi
        this.BackColor = Color.Black;
        this.ForeColor = Color.White;

        textBox1.BackColor = Color.FromArgb(30, 30, 30);
        textBox1.ForeColor = Color.Lime;
        textBox1.BorderStyle = BorderStyle.FixedSingle;

        panel1.BackColor = Color.Black;

        // Tüm butonlar için siyah/mor renk paleti uygula
        foreach (Control control in panel1.Controls)
        {
            if (control is Button btn)
            {
                btn.BackColor = Color.FromArgb(40, 0, 80); // Mor ton
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.Purple;
                btn.FlatAppearance.BorderSize = 1;
            }
        }
    }


    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        panel1 = new System.Windows.Forms.Panel();
        button20 = new System.Windows.Forms.Button();
        button19 = new System.Windows.Forms.Button();
        button18 = new System.Windows.Forms.Button();
        button14 = new System.Windows.Forms.Button();
        button15 = new System.Windows.Forms.Button();
        button16 = new System.Windows.Forms.Button();
        button17 = new System.Windows.Forms.Button();
        button13 = new System.Windows.Forms.Button();
        button12 = new System.Windows.Forms.Button();
        button11 = new System.Windows.Forms.Button();
        button10 = new System.Windows.Forms.Button();
        button7 = new System.Windows.Forms.Button();
        button8 = new System.Windows.Forms.Button();
        button9 = new System.Windows.Forms.Button();
        button4 = new System.Windows.Forms.Button();
        button5 = new System.Windows.Forms.Button();
        button6 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        button1 = new System.Windows.Forms.Button();
        textBox1 = new System.Windows.Forms.TextBox();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.Controls.Add(button20);
        panel1.Controls.Add(button19);
        panel1.Controls.Add(button18);
        panel1.Controls.Add(button14);
        panel1.Controls.Add(button15);
        panel1.Controls.Add(button16);
        panel1.Controls.Add(button17);
        panel1.Controls.Add(button13);
        panel1.Controls.Add(button12);
        panel1.Controls.Add(button11);
        panel1.Controls.Add(button10);
        panel1.Controls.Add(button7);
        panel1.Controls.Add(button8);
        panel1.Controls.Add(button9);
        panel1.Controls.Add(button4);
        panel1.Controls.Add(button5);
        panel1.Controls.Add(button6);
        panel1.Controls.Add(button3);
        panel1.Controls.Add(button2);
        panel1.Controls.Add(button1);
        panel1.Controls.Add(textBox1);
        panel1.Location = new System.Drawing.Point(12, 12);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(776, 426);
        panel1.TabIndex = 0;
        // 
        // button20
        // 
        button20.Location = new System.Drawing.Point(569, 343);
        button20.Name = "button20";
        button20.Size = new System.Drawing.Size(119, 80);
        button20.TabIndex = 20;
        button20.Text = "off";
        button20.UseVisualStyleBackColor = true;
        button20.Click += button20_Click;
        // 
        // button19
        // 
        button19.Location = new System.Drawing.Point(569, 173);
        button19.Name = "button19";
        button19.Size = new System.Drawing.Size(119, 80);
        button19.TabIndex = 19;
        button19.Text = "C/A";
        button19.UseVisualStyleBackColor = true;
        button19.Click += button19_Click;
        // 
        // button18
        // 
        button18.Location = new System.Drawing.Point(569, 87);
        button18.Name = "button18";
        button18.Size = new System.Drawing.Size(119, 80);
        button18.TabIndex = 18;
        button18.Text = "C";
        button18.UseVisualStyleBackColor = true;
        // 
        // button14
        // 
        button14.Location = new System.Drawing.Point(450, 343);
        button14.Name = "button14";
        button14.Size = new System.Drawing.Size(92, 80);
        button14.TabIndex = 17;
        button14.Text = "%";
        button14.UseVisualStyleBackColor = true;
        // 
        // button15
        // 
        button15.Location = new System.Drawing.Point(450, 259);
        button15.Name = "button15";
        button15.Size = new System.Drawing.Size(92, 80);
        button15.TabIndex = 16;
        button15.Text = "-";
        button15.UseVisualStyleBackColor = true;
        // 
        // button16
        // 
        button16.Location = new System.Drawing.Point(450, 173);
        button16.Name = "button16";
        button16.Size = new System.Drawing.Size(92, 80);
        button16.TabIndex = 15;
        button16.Text = "*";
        button16.UseVisualStyleBackColor = true;
        // 
        // button17
        // 
        button17.Location = new System.Drawing.Point(450, 87);
        button17.Name = "button17";
        button17.Size = new System.Drawing.Size(92, 80);
        button17.TabIndex = 14;
        button17.Text = "/";
        button17.UseVisualStyleBackColor = true;
        button17.Click += button17_Click;
        // 
        // button13
        // 
        button13.Location = new System.Drawing.Point(339, 343);
        button13.Name = "button13";
        button13.Size = new System.Drawing.Size(92, 80);
        button13.TabIndex = 13;
        button13.Text = "=";
        button13.UseVisualStyleBackColor = true;
        // 
        // button12
        // 
        button12.Location = new System.Drawing.Point(339, 87);
        button12.Name = "button12";
        button12.Size = new System.Drawing.Size(92, 252);
        button12.TabIndex = 12;
        button12.Text = "+";
        button12.UseVisualStyleBackColor = true;
        // 
        // button11
        // 
        button11.Location = new System.Drawing.Point(143, 343);
        button11.Name = "button11";
        button11.Size = new System.Drawing.Size(190, 80);
        button11.TabIndex = 11;
        button11.Text = "00";
        button11.UseVisualStyleBackColor = true;
        // 
        // button10
        // 
        button10.Location = new System.Drawing.Point(45, 343);
        button10.Name = "button10";
        button10.Size = new System.Drawing.Size(92, 80);
        button10.TabIndex = 10;
        button10.Text = "0";
        button10.UseVisualStyleBackColor = true;
        // 
        // button7
        // 
        button7.Location = new System.Drawing.Point(241, 259);
        button7.Name = "button7";
        button7.Size = new System.Drawing.Size(92, 80);
        button7.TabIndex = 9;
        button7.Text = "9";
        button7.UseVisualStyleBackColor = true;
        // 
        // button8
        // 
        button8.Location = new System.Drawing.Point(241, 173);
        button8.Name = "button8";
        button8.Size = new System.Drawing.Size(92, 80);
        button8.TabIndex = 8;
        button8.Text = "8";
        button8.UseVisualStyleBackColor = true;
        // 
        // button9
        // 
        button9.Location = new System.Drawing.Point(241, 87);
        button9.Name = "button9";
        button9.Size = new System.Drawing.Size(92, 80);
        button9.TabIndex = 7;
        button9.Text = "7";
        button9.UseVisualStyleBackColor = true;
        // 
        // button4
        // 
        button4.Location = new System.Drawing.Point(143, 259);
        button4.Name = "button4";
        button4.Size = new System.Drawing.Size(92, 80);
        button4.TabIndex = 6;
        button4.Text = "6";
        button4.UseVisualStyleBackColor = true;
        // 
        // button5
        // 
        button5.Location = new System.Drawing.Point(143, 173);
        button5.Name = "button5";
        button5.Size = new System.Drawing.Size(92, 80);
        button5.TabIndex = 5;
        button5.Text = "5";
        button5.UseVisualStyleBackColor = true;

        // 
        // button6
        // 
        button6.Location = new System.Drawing.Point(143, 87);
        button6.Name = "button6";
        button6.Size = new System.Drawing.Size(92, 80);
        button6.TabIndex = 4;
        button6.Text = "4";
        button6.UseVisualStyleBackColor = true;
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(45, 259);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(92, 80);
        button3.TabIndex = 3;
        button3.Text = "3";
        button3.UseVisualStyleBackColor = true;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(45, 173);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(92, 80);
        button2.TabIndex = 2;
        button2.Text = "2";
        button2.UseVisualStyleBackColor = true;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(45, 87);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(92, 80);
        button1.TabIndex = 1;
        button1.Text = "1";
        button1.UseVisualStyleBackColor = true;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(50, 30);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(662, 27);
        textBox1.TabIndex = 0;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(797, 465);
        Controls.Add(panel1);
        Text = "Form1";
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ResumeLayout(false);
        
        ApplyDarkTheme();
    }

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.Button button6;
    private System.Windows.Forms.Button button7;
    private System.Windows.Forms.Button button8;
    private System.Windows.Forms.Button button9;
    private System.Windows.Forms.Button button10;
    private System.Windows.Forms.Button button11;
    private System.Windows.Forms.Button button12;
    private System.Windows.Forms.Button button13;
    private System.Windows.Forms.Button button14;
    private System.Windows.Forms.Button button15;
    private System.Windows.Forms.Button button16;
    private System.Windows.Forms.Button button17;
    private System.Windows.Forms.Button button18;
    private System.Windows.Forms.Button button19;
    private System.Windows.Forms.Button button20;

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button button1;

    #endregion
}