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
        private void InitializeComponent( )
        {
            testCheckBox = new CheckBox( );
            bufferSizeInput = new NumericUpDown( );
            label1 = new Label( );
            button1 = new Button( );
            richTextBox1 = new RichTextBox( );
            label2 = new Label( );
            outputTextBox = new RichTextBox( );
            ( ( System.ComponentModel.ISupportInitialize ) bufferSizeInput ).BeginInit( );
            SuspendLayout( );
            // 
            // testCheckBox
            // 
            testCheckBox.AutoSize = true;
            testCheckBox.Location = new Point( 85, 173 );
            testCheckBox.Name = "testCheckBox";
            testCheckBox.Size = new Size( 147, 19 );
            testCheckBox.TabIndex = 0;
            testCheckBox.Text = "임시 파일 생성 (10GB)";
            testCheckBox.UseVisualStyleBackColor = true;
            testCheckBox.CheckedChanged +=  checkBox1_CheckedChanged ;
            // 
            // bufferSizeInput
            // 
            bufferSizeInput.Location = new Point( 206, 203 );
            bufferSizeInput.Maximum = new decimal( new int[] { 10240, 0, 0, 0 } );
            bufferSizeInput.Name = "bufferSizeInput";
            bufferSizeInput.Size = new Size( 89, 23 );
            bufferSizeInput.TabIndex = 1;
            bufferSizeInput.ValueChanged +=  numericUpDown1_ValueChanged ;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point( 85, 205 );
            label1.Name = "label1";
            label1.Size = new Size( 101, 15 );
            label1.TabIndex = 2;
            label1.Text = "버퍼 사이즈 (MB)";
            label1.Click +=  label1_Click ;
            // 
            // button1
            // 
            button1.Location = new Point( 152, 240 );
            button1.Name = "button1";
            button1.Size = new Size( 75, 50 );
            button1.TabIndex = 3;
            button1.Text = "복사";
            button1.UseVisualStyleBackColor = true;
            button1.Click +=  button1_Click ;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point( 85, 30 );
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size( 210, 96 );
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            richTextBox1.TextChanged +=  richTextBox1_TextChanged_1 ;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point( 85, 144 );
            label2.Name = "label2";
            label2.Size = new Size( 119, 15 );
            label2.TabIndex = 5;
            label2.Text = "파일을 드래그하세요";
            // 
            // outputTextBox
            // 
            outputTextBox.BackColor = SystemColors.WindowText;
            outputTextBox.ForeColor = SystemColors.Window;
            outputTextBox.Location = new Point( 27, 305 );
            outputTextBox.Name = "outputTextBox";
            outputTextBox.Size = new Size( 329, 144 );
            outputTextBox.TabIndex = 6;
            outputTextBox.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF( 7F, 15F );
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size( 384, 461 );
            Controls.Add( outputTextBox );
            Controls.Add( label2 );
            Controls.Add( richTextBox1 );
            Controls.Add( button1 );
            Controls.Add( label1 );
            Controls.Add( bufferSizeInput );
            Controls.Add( testCheckBox );
            Name = "Form1";
            Text = "Form1";
            Load +=  Form1_Load ;
            ( ( System.ComponentModel.ISupportInitialize ) bufferSizeInput ).EndInit( );
            ResumeLayout( false );
            PerformLayout( );
        }

        #endregion

        private CheckBox testCheckBox;
        private NumericUpDown bufferSizeInput;
        private Label label1;
        private Button button1;
        private RichTextBox richTextBox1;
        private Label label2;
        private RichTextBox outputTextBox;
    }
}
