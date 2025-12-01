/**
 * @project WinForms Painter
 * @description Basit çizim uygulaması 
 * @author ozaiithejava
 */

namespace chapterOne
{
    public partial class Form1 : Form
    {
        private bool cizimModu = false;
        private bool silmeModu = false;
        private int fircaBoyutu = 8;
        private Color fircaRengi = Color.Black;

        private Bitmap canvas;
        private Graphics g;

        public Form1()
        {
            InitializeComponent();
            CanvasHazirla();
        }

        private void CanvasHazirla()
        {
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(canvas);
            g.Clear(Color.White);
            pictureBox1.Image = canvas;
        }

        private void DaireCiz(Color renk, Point konum)
        {
            using (SolidBrush firca = new SolidBrush(renk))
            {
                g.FillEllipse(firca,
                    konum.X - fircaBoyutu / 2,
                    konum.Y - fircaBoyutu / 2,
                    fircaBoyutu,
                    fircaBoyutu);
            }
            pictureBox1.Refresh();
        }

        // MOUSE EVENTLERİ
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                cizimModu = true;

            if (e.Button == MouseButtons.Right)
                silmeModu = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                cizimModu = false;

            if (e.Button == MouseButtons.Right)
                silmeModu = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (cizimModu)
                DaireCiz(fircaRengi, e.Location);
            else if (silmeModu)
                DaireCiz(Color.White, e.Location);
        }

        // RENK SEÇİMİ
        private void redRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (redRadio.Checked)
                fircaRengi = Color.Red;
        }

        private void blueRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (blueRadio.Checked)
                fircaRengi = Color.Blue;
        }

        private void greenRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (greenRadio.Checked)
                fircaRengi = Color.Green;
        }

        private void blackRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (blackRadio.Checked)
                fircaRengi = Color.Black;
        }

        // BOYUT SEÇİMİ
        private void smallRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (smallRadio.Checked)
                fircaBoyutu = 4;
        }

        private void mediumRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (mediumRadio.Checked)
                fircaBoyutu = 8;
        }

        private void largeRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (largeRadio.Checked)
                fircaBoyutu = 12;
        }

        // BUTONLAR
        private void clearButton_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Refresh();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Undo sistemi eklenebilir. (author: ozaii)");
        }
    }
}