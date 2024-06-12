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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string a = "";
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
    }
}
