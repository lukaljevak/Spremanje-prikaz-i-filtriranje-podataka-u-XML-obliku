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

namespace Spremanje__prikaz_i_filtriranje_podataka_u_XML_obliku
{
    public partial class FiltrirajForm : Form
    {
        public string Ime { get; private set; }
        public string Prezime { get; private set; }
        public string Email { get; private set; }
        public string Razred { get; private set; }
        public FiltrirajForm()
        {
            InitializeComponent();
        }

        private void btnFiltriraj_Click(object sender, EventArgs e)
        {
            Ime = txtIme.Text;
            Prezime = txtPrezime.Text;
            Email = txtEmail.Text;
            Razred = txtRazred.Text;

            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

            private void btnOdustani_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
    }
