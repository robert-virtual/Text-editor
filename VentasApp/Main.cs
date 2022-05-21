namespace VentasApp
{
    public partial class Main : Form
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        string currentFilename = "";
        public Main()
        {
            InitializeComponent();
            saveFileDialog.Filter = "Archivo de Texto|*.txt";
            saveFileDialog.Title = "Guardar Archivo de Texto";
            // open
            openFileDialog.Filter = "Archivo de Texto|*.txt";
            openFileDialog.Title = "Open Archivo de Texto";
        }
        void setCurrentFileName(string name)
        {
            currentFilename = name;
            this.Text = "Text Editor " + name;
        }
        private void guardarComo()
        {
            var fileName = "nuevoArchivo.txt";
            if (main_text.Text.Length > 0)
            {
                fileName = main_text.Lines[0].Split(" ").First();
            }
            saveFileDialog.FileName = fileName;
            var dialogRes = saveFileDialog.ShowDialog();
            if(dialogRes != DialogResult.Cancel)
            {
                File.WriteAllText(saveFileDialog.FileName,main_text.Text);
                setCurrentFileName(saveFileDialog.FileName);
                MessageBox.Show("Archivo Guardado", "Text Editor",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guardarComo();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = openFileDialog.ShowDialog();
            if (res != DialogResult.Cancel)
            {
                main_text.Text = File.ReadAllText(openFileDialog.FileName);
                setCurrentFileName(openFileDialog.FileName);

            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFilename == "")
            {

                guardarComo();
                return;
            }
            File.WriteAllText(currentFilename,main_text.Text);
            MessageBox.Show("Archivo Guardado", "Text Editor",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void main_text_TextChanged(object sender, EventArgs e)
        {

        }
    }
}