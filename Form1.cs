namespace LargeFileCopier
{
    public partial class Form1 : Form
    {
        private string targetFilePath;

        public Form1( )
        {
            InitializeComponent( );
        }

        private void Form1_Load( object sender, EventArgs e )
        {
            richTextBox1.AllowDrop = true;
            richTextBox1.DragEnter += new DragEventHandler( richTextBox1_DragEnter );
            richTextBox1.DragEnter += new DragEventHandler( richTextBox1_DragDrop );

        }

        private void richTextBox1_TextChanged( object sender, EventArgs e )
        {

        }

        private void label1_Click( object sender, EventArgs e )
        {

        }

        private void label3_Click( object sender, EventArgs e )
        {

        }

        private void numericUpDown1_ValueChanged( object sender, EventArgs e )
        {

        }

        private void button1_Click( object sender, EventArgs e )
        {
            if(targetFilePath == null)
            {
                outputTextBox.Text = "대상 파일이 확인되지 않습니다.";
                return;
            }

            if(bufferSizeInput.Value < 1)
            {
                outputTextBox.Text = "버퍼 사이즈가 올바르지 않습니다.";
                return;
            }


        }

        private void checkBox1_CheckedChanged( object sender, EventArgs e )
        {

        }

        private void richTextBox1_TextChanged_1( object sender, EventArgs e )
        {

        }

        private void richTextBox1_DragEnter( object sender, DragEventArgs e )
        {
            if ( e.Data.GetDataPresent( DataFormats.FileDrop ) )
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void richTextBox1_DragDrop( object sender, DragEventArgs e )
        {
            string[] files = ( string[] ) e.Data.GetData( DataFormats.FileDrop );
            if ( files.Length == 1 )
            {
                targetFilePath = files[0];
                richTextBox1.Text = targetFilePath;
            }
        }
    }
}
