using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace School_Note_Project
{
    public partial class FrmExamNotes : Form
    {
        public FrmExamNotes()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.Tbl_NotesTableAdapter ds = new DataSet1TableAdapters.Tbl_NotesTableAdapter();
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NoteList(int.Parse(TxtStudentid.Text));
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LRMEISB\SQLEXPRESS;Initial Catalog=SchoolProject;Integrated Security=True");
        private void FrmExamNotes_Load(object sender, EventArgs e)
        {
            
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Tbl_Lessons", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "LSSNNAME";
            comboBox1.ValueMember = "LSSNNID";
            comboBox1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtStudentid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtExam1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtExam2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtExam3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtProject.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtAverage.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            int exam1, exam2, exam3, project;
            double average;
            string status;
            exam1 = Convert.ToInt16(TxtExam1.Text);
            exam2 = Convert.ToInt16(TxtExam2.Text);
            exam3 = Convert.ToInt16(TxtExam3.Text);
            project = Convert.ToInt16(TxtProject.Text);
            average = (exam1 + exam2 + exam3 + project) / 4;
            TxtAverage.Text = average.ToString();
            if(average > 50)
            {
                TxtStatus.Text = "True";
            }
            else
            {
                TxtStatus.Text = "False";
            }
        } 
    }
}
