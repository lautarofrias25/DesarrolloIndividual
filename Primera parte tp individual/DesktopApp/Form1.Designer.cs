namespace DesktopApp
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
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 78);
            button1.Name = "button1";
            button1.Size = new Size(149, 29);
            button1.TabIndex = 0;
            button1.Text = "Concatenar Strings";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 166);
            button2.Name = "button2";
            button2.Size = new Size(149, 51);
            button2.TabIndex = 1;
            button2.Text = "Eliminar espacios de strings";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(283, 168);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(346, 27);
            textBox1.TabIndex = 2;
            textBox1.Visible = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(283, 78);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(346, 27);
            textBox2.TabIndex = 3;
            textBox2.Visible = false;
            // 
            // button3
            // 
            button3.Location = new Point(480, 230);
            button3.Name = "button3";
            button3.Size = new Size(149, 29);
            button3.TabIndex = 4;
            button3.UseVisualStyleBackColor = true;
            button3.Visible = false;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(63, 29);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 5;
            label1.Text = "Menu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(283, 46);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 6;
            label2.Text = "label2";
            label2.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(283, 136);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 7;
            label3.Text = "label3";
            label3.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(283, 234);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 347);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}