using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace School_Note_Project
{
    public partial class FrmStudentNotes : Form
    {
        public FrmStudentNotes()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LRMEISB\SQLEXPRESS;Initial Catalog=SchoolProject;Integrated Security=True");
        public string no;
        private void FrmStudentNotes_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Tbl_Notes where STNID=@p1", con);
            cmd.Parameters.AddWithValue("@p1", no);
            //this.Text = no.ToString();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
