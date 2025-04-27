namespace LargeFileCopier
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
            checkBox1 = new CheckBox();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            label2 = new Label();
            richTextBox2 = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(85, 173);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(106, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "임시 파일 생성";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(206, 203);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(89, 23);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.ValueChanged += this.numericUpDown1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(85, 205);
            label1.Name = "label1";
            label1.Size = new Size(101, 15);
            label1.TabIndex = 2;
            label1.Text = "버퍼 사이즈 (MB)";
            label1.Click += this.label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(152, 240);
            button1.Name = "button1";
            button1.Size = new Size(75, 50);
            button1.TabIndex = 3;
            button1.Text = "복사";
            button1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(85, 30);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(210, 96);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(85, 144);
            label2.Name = "label2";
            label2.Size = new Size(119, 15);
            label2.TabIndex = 5;
            label2.Text = "파일을 드래그하세요";
            // 
            // richTextBox2
            // 
            richTextBox2.BackColor = SystemColors.WindowText;
            richTextBox2.ForeColor = SystemColors.Window;
            richTextBox2.Location = new Point(27, 305);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(329, 144);
            richTextBox2.TabIndex = 6;
            richTextBox2.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 461);
            Controls.Add(richTextBox2);
            Controls.Add(label2);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(checkBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox1;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private Button button1;
        private RichTextBox richTextBox1;
        private Label label2;
        private RichTextBox richTextBox2;
    }
}
