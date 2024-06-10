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

namespace School_Note_Project
{
    public partial class FrmClub : Form
    {
        public FrmClub()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LRMEISB\SQLEXPRESS;Initial Catalog=SchoolProject;Integrated Security=True");
        void list()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Clubs", con);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        private void FrmClub_Load(object sender, EventArgs e)
        {
            list();
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            list();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cm = new SqlCommand("insert into tbl_clubs (clubname) values (@p1)", con);
            cm.Parameters.AddWithValue("@p1", TxtClubName.Text);
            cm.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Club added to list", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.LightBlue;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtClubid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtClubName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("Delete From Tbl_Clubs WHERE CLUBSID=@P1", con);
            com.Parameters.AddWithValue("@p1", TxtClubid.Text);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Succesfully deleted");
            list();
        }
    }
}
