using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biblioteka
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox2.Text != "")
                {
                    string tytulk = textBox1.Text;
                    string autork = textBox2.Text;
                    Form1.ksiazka newksiazka = new Form1.ksiazka();
                    newksiazka.tytul = textBox1.Text;
                    newksiazka.autor = textBox2.Text;
                    newksiazka.stan = "TRUE";
                    int check = 1;
                    for (int i = 0; i < Form1.dt2.Rows.Count; i++)
                    {
                        check += Int32.Parse(Form1.dt2.Rows[i][3].ToString()) - i;


                    }
                    newksiazka.ID = check.ToString();
                    Form1.dt2.Rows.Add(newksiazka.tytul,newksiazka.autor,newksiazka.stan,newksiazka.ID);
                }
                else
                {

                    MessageBox.Show("Użytkownik musi posiadać imię i nazwisko", "Nie można usunąć użytkownika", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

                MessageBox.Show("Użytkownik musi posiadać imię i nazwisko", "Nie można usunąć użytkownika", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
