using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biblioteka
{
    public partial class Form1 : Form
    {
        
        public static DataTable dt2 = new DataTable();
        public static DataSet dataSet = new DataSet();
        public static DataSet dataSet2 = new DataSet();
        public static DataTable dt = new DataTable();

        public Form1()
        {
            InitializeComponent();
            dt.Columns.Add("Imie");
            dt.Columns.Add("Nazwisko");
            dt.Columns.Add("ID");
            dt.Columns.Add("idk");
            dataGridView1.DataSource = dt;
            dt2.Columns.Add("Tytul");
            dt2.Columns.Add("Autor");
            dt2.Columns.Add("Stan");
            dt2.Columns.Add("ID");
            dt2.Columns.Add("idu");
            dataGridView2.DataSource = dt2;

            foreach(DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }      
            
        public class ksiazka {
            
            public string tytul;
            public string autor;
            public string stan;
            public string ID;
            public string idu;
        }
        
        public class uzytkownik
        {
            public string imie;
            public string nazwisko;
            public string ID;
            public string idk;           
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog(this);
            dataSet.ReadXml(openFileDialog.FileName);
            
            List<uzytkownik> empList = new List<uzytkownik>();            
            foreach(DataRow dr in dataSet.Tables[0].Rows)
            {
                uzytkownik empuzytkownik = new uzytkownik();
                empuzytkownik.imie = dr.Field<string>("Imie");                
                empuzytkownik.nazwisko = dr.Field<string>("Nazwisko");
                empuzytkownik.ID = dr.Field<string>("ID");                                
                empuzytkownik.idk = dr.Field<string>("idk");                            
                empList.Add(empuzytkownik);                
            } // from XML to list of users empList            
            foreach (var rekord in empList)
            {
                dt.Rows.Add(rekord.imie, rekord.nazwisko, rekord.ID, rekord.idk);
            }                              
            dataGridView1.DataSource =dt;
        }// wczytaj użytkowników 100%

        private void b_zapis_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog(this);
            dataSet.Tables.Clear();
            dataSet.Tables.Add(dt);
            dataSet.WriteXml(openFileDialog.FileName);
        }// zapisz użytkowników 100%

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog(this);
            dataSet2.Tables.Clear();
            dataSet2.Tables.Add(dt2);
            dataSet2.WriteXml(openFileDialog.FileName);
        }// zapisz książki 100%

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog(this);
            dataSet2.ReadXml(openFileDialog.FileName);
            
            List<ksiazka> empList = new List<ksiazka>();
            foreach (DataRow dr in dataSet2.Tables[0].Rows)
            {
                ksiazka empksiazka= new ksiazka();
                empksiazka.tytul = dr.Field<string>("Tytul");
                empksiazka.autor = dr.Field<string>("Autor");
                empksiazka.stan = dr.Field<string>("Stan");
                empksiazka.ID = dr.Field<string>("ID");
                empksiazka.idu = dr.Field<string>("idu");
                empList.Add(empksiazka);
            } // from XML to list of book empList
            foreach (var rekord in empList)
            {
                dt2.Rows.Add(rekord.tytul, rekord.autor, rekord.stan, rekord.ID,rekord.idu);
            }
            dataGridView2.DataSource = dt2;      

        }// wczytaj książki 100%

        private void button9_Click(object sender, EventArgs e)
        {
            if (dt.Rows[dataGridView1.CurrentCell.RowIndex][3].ToString() == "")
            {
                if (dt2.Rows[dataGridView2.CurrentCell.RowIndex][2].ToString() == "TRUE")
                {
                    dt.Rows[dataGridView1.CurrentCell.RowIndex].SetField("idk", dt2.Rows[dataGridView2.CurrentCell.RowIndex].Field<string>("ID"));
                    dt2.Rows[dataGridView2.CurrentCell.RowIndex].SetField("idu", dt.Rows[dataGridView1.CurrentCell.RowIndex].Field<string>("ID"));
                    dt2.Rows[dataGridView2.CurrentCell.RowIndex].SetField("Stan", "FALSE");
                }
                else
                {
                    MessageBox.Show("Książka jest wypożyczona", "Nie można wypożyczyć", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Użytkownik ma już wypożyczoną książkę", "Nie można wypożyczyć", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dataGridView1.DataSource= dt;
            dataGridView2.DataSource= dt2;


        }//wypożyczenia 100%

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            form2 = null;

        }//dodanie użytkownika

        private void button10_Click(object sender, EventArgs e)
        {
            if (dt2.Rows[dataGridView2.CurrentCell.RowIndex][2].ToString() == "FALSE")
            {
                dt2.Rows[dataGridView2.CurrentCell.RowIndex][2] = "TRUE";
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][2].ToString() == dt2.Rows[dataGridView2.CurrentCell.RowIndex][4].ToString()){
                       dt.Rows[i][3] = "";
                    }
                }
                dt2.Rows[dataGridView2.CurrentCell.RowIndex][4] = "";

            }
            else
            {
                MessageBox.Show("Książka nie jest wypożyczona", "Nie można zwrócić", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }//zwrot książki 100%

        private void button5_Click(object sender, EventArgs e)
        {
            if (dt2.Rows[dataGridView2.CurrentCell.RowIndex][2] != null)
            {
                if (dt2.Rows[dataGridView2.CurrentCell.RowIndex][2].ToString() == "TRUE")
                {
                    dt2.Rows[dataGridView2.CurrentCell.RowIndex].Delete();
                }
                else
                {
                    MessageBox.Show("Książka jest wypożyczona", "Nie można usunąć książki", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }//usuwanie książki

        private void button2_Click(object sender, EventArgs e)
        {
            if(dt.Rows[dataGridView1.CurrentCell.RowIndex][3] != null)
            {
                if (dt.Rows[dataGridView1.CurrentCell.RowIndex][3].ToString() == "")
                {
                    dt.Rows[dataGridView1.CurrentCell.RowIndex].Delete();
                }
                else
                {
                    MessageBox.Show("Użytkownik posiada wypożyczoną książkę", "Nie można usunąć użytkownika", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        } //usuń użytkownika

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
            form3 = null;
        }//dodanie książki
    }
}
