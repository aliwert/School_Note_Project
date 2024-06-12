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

namespace School_Note_Project
{
    public partial class FrmStudent : Form
    {
        public FrmStudent()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();

        private void FrmStudent_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.StudentList();
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LRMEISB\SQLEXPRESS;Initial Catalog=SchoolProject;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Tbl_Clubs", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbClub.DisplayMember = "CLUBNAME";
            CmbClub.ValueMember = "CLUBSID";
            CmbClub.DataSource = dt;
            con.Close();
        }
        string a = "";
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked == true)
            {
                a = "Woman";
            }
            if (radioButton2.Checked == true)
            {
                a = "Man";
            }
            ds.AddStudent(TxtName.Text,TxtSurname.Text, byte.Parse(CmbClub.SelectedValue.ToString()), a);
            MessageBox.Show("Student addition has been completed");
        }

        private void CmbClub_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TxtStudentid.Text = CmbClub.SelectedValue.ToString();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ds.DeleteStudent(int.Parse(TxtStudentid.Text));
            MessageBox.Show("Deleted succesfully");
        }
        string gender= "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtStudentid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSurname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            CmbClub.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            gender = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            if(gender == "Woman")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;

            }
            if (gender == "Man")
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
        }
    }
}
