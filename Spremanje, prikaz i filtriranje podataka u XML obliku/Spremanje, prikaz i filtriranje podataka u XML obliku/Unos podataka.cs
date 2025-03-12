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
    public partial class UnosForm : Form
    {
        private List<Student> studenti = new List<Student>();
        public UnosForm()
        {
            InitializeComponent();
        }

        private void btnUnos_Click(object sender, EventArgs e)
        {
            string ime = txtIme.Text;
            string prezime = txtPrezime.Text;
            string email = txtEmail.Text;
            string razred = txtRazred.Text;

            if (string.IsNullOrEmpty(ime) || string.IsNullOrEmpty(prezime) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(razred))
            {
                MessageBox.Show("Svi podaci su obavezni!");
                return;
            }

            Student student = new Student(ime, prezime, email, razred);
            studenti.Add(student);

            txtIme.Clear();
            txtPrezime.Clear();
            txtEmail.Clear();
            txtRazred.Clear();
        }

        private void btnZavrsi_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("Studenti");
            xmlDoc.AppendChild(root);

            foreach (Student student in studenti)
            {
                XmlElement studentNode = xmlDoc.CreateElement("Student");

                XmlElement imeNode = xmlDoc.CreateElement("Ime");
                imeNode.InnerText = student.Ime;
                studentNode.AppendChild(imeNode);

                XmlElement prezimeNode = xmlDoc.CreateElement("Prezime");
                prezimeNode.InnerText = student.Prezime;
                studentNode.AppendChild(prezimeNode);

                XmlElement emailNode = xmlDoc.CreateElement("Email");
                emailNode.InnerText = student.Email;
                studentNode.AppendChild(emailNode);

                XmlElement razredNode = xmlDoc.CreateElement("Razred");
                razredNode.InnerText = student.Razred;
                studentNode.AppendChild(razredNode);

                root.AppendChild(studentNode);
            }

            xmlDoc.Save("studenti.xml");
        }
    }
    }

public class Student
{
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public string Email { get; set; }
    public string Razred { get; set; }

    public Student(string ime, string prezime, string email, string razred)
    {
        Ime = ime;
        Prezime = prezime;
        Email = email;
        Razred = razred;
    }
}