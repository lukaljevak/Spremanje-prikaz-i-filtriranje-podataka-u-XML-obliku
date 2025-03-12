using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Spremanje__prikaz_i_filtriranje_podataka_u_XML_obliku
{
    public partial class PregledForm : Form
    {
        public PregledForm()
        {
            InitializeComponent();
            
        }
        private void UcitajPodatke()
        {
            if (File.Exists("studenti.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("studenti.xml");

                XmlNodeList studentNodes = xmlDoc.SelectNodes("/Studenti/Student");
                foreach (XmlNode studentNode in studentNodes)
                {
                    string ime = studentNode.SelectSingleNode("Ime").InnerText;
                    string prezime = studentNode.SelectSingleNode("Prezime").InnerText;
                    string email = studentNode.SelectSingleNode("Email").InnerText;
                    string razred = studentNode.SelectSingleNode("Razred").InnerText;

                    dataGridView1.Rows.Add(ime, prezime, email, razred);
                }
            
        }
            else
            {
                MessageBox.Show("XML dokument ne postoji!");
            }
        }

        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void btnFiltriraj_Click(object sender, EventArgs e)
        {
            FiltrirajForm filtrirajForm = new FiltrirajForm();
            if (filtrirajForm.ShowDialog() == DialogResult.OK)
            {

                FiltrirajPodatke(filtrirajForm.Ime, filtrirajForm.Prezime, filtrirajForm.Email, filtrirajForm.Razred);
            }
        }
        private void FiltrirajPodatke(string ime, string prezime, string email, string razred)
        {
            dataGridView1.Rows.Clear();

            if (File.Exists("studenti.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("studenti.xml");

                XmlNodeList studentNodes = xmlDoc.SelectNodes("/Studenti/Student");
                bool pronadeno = false;

                foreach (XmlNode studentNode in studentNodes)
                {
                    string imeNode = studentNode.SelectSingleNode("Ime").InnerText;
                    string prezimeNode = studentNode.SelectSingleNode("Prezime").InnerText;
                    string emailNode = studentNode.SelectSingleNode("Email").InnerText;
                    string razredNode = studentNode.SelectSingleNode("Razred").InnerText;

                    
                    if ((string.IsNullOrEmpty(ime) || imeNode.Contains(ime)) &&
                        (string.IsNullOrEmpty(prezime) || prezimeNode.Contains(prezime)) &&
                        (string.IsNullOrEmpty(email) || emailNode.Contains(email)) &&
                        (string.IsNullOrEmpty(razred) || razredNode.Contains(razred)))
                    {
                        dataGridView1.Rows.Add(imeNode, prezimeNode, emailNode, razredNode);
                        pronadeno = true;
                    }
                }

                if (!pronadeno)
                {
                    MessageBox.Show("Nema podataka koji odgovaraju kriterijima!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("XML dokument ne postoji!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
