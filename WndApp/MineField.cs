using System;
using System.Drawing;
using System.Windows.Forms;

namespace WndApp
{
    public enum ZorlukSeviyesi { Kolay=9, Normal=16, Zor =25 }

    public partial class MineField : Form
    {
        ZorlukSeviyesi Seviye;
        public MineField()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Seviye = ZorlukSeviyesi.Normal;
        }

        private void OyunBaslat(ZorlukSeviyesi seviye) {

            int boyut = 25;
            int sayac = (int)seviye;

            flowLayoutPanel1.Width = (boyut) * sayac;
            flowLayoutPanel1.Height = (boyut) * sayac;
            
            for (int i = 0; i < sayac; i++)
            {
                for (int j = 0; j < sayac; j++)
                {
                    Button btn = new Button();
                    btn.Click += Btn_Click;
                    btn.Width = boyut;
                    btn.Height = boyut;
                    btn.Margin = new Padding(0);
                    flowLayoutPanel1.Controls.Add(btn);
                
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            if (btn.Tag != null)
            {
                btn.BackColor = Color.Red;
                btn.Text = "*";
                MessageBox.Show("Hay aksi :(! Oyun bitti !!!");
            }
            else
            {
                btn.Enabled = false;
            }
        }

        private void baslatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OyunBaslat(Seviye);
            MayinYerlestir(Seviye);
        }

        private void kolayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Seviye = ZorlukSeviyesi.Kolay;
            Temizle();
            kolayToolStripMenuItem.Checked = true;
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Seviye = ZorlukSeviyesi.Normal;
            Temizle();
            normalToolStripMenuItem.Checked = true;
        }

        private void zorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Seviye = ZorlukSeviyesi.Zor;
            Temizle();
            zorToolStripMenuItem.Checked = true;
        }

        private void Temizle() {
            kolayToolStripMenuItem.Checked = false;
            normalToolStripMenuItem.Checked = false;
            zorToolStripMenuItem.Checked = false;
        }

        private void MayinYerlestir(ZorlukSeviyesi seviye) {
            int adet = (int)seviye;
            int mayınSayisi = adet * 2;
            int butonSayisi = adet * adet;

            int sayac = 0;
            
            while(sayac<mayınSayisi)
            {
                Random rnd = new Random();
                int indis= rnd.Next(0,butonSayisi);

                Button btn = (Button)flowLayoutPanel1.Controls[indis];

                if (btn.Tag == null) 
                {
                    btn.Tag = "*";
                    sayac++;
                }

            }
           

        }
    }
}
