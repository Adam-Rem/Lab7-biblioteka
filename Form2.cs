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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if(textBox2.Text != "")
                {
                    string imieu = textBox1.Text;
                    string nazwiskou = textBox2.Text;
                    Form1.uzytkownik uzytkownik = new Form1.uzytkownik();
                    uzytkownik.imie = textBox1.Text;
                    uzytkownik.nazwisko = textBox2.Text;
                    int check = 1;
                    for(int i = 0; i < Form1.dt.Rows.Count;i++)
                    {
                        check += Int32.Parse(Form1.dt.Rows[i][2].ToString())-i;
                        
                        
                    }
                    uzytkownik.ID = check.ToString();
                    Form1.dt.Rows.Add(uzytkownik.imie, uzytkownik.nazwisko, uzytkownik.ID);
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
        
        }//dodawanie użytkownika ID większe o 1 od największego

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
