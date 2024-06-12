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
    public partial class FrmLessons : Form
    {
        public FrmLessons()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LRMEISB\SQLEXPRESS;Initial Catalog=SchoolProject;Integrated Security=True");
        void list()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Lessons", con);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        DataSet1TableAdapters.Tbl_LessonsTableAdapter ds = new DataSet1TableAdapters.Tbl_LessonsTableAdapter();
        private void FrmLessons_Load(object sender, EventArgs e)
        {
            // select with dataset 
            dataGridView1.DataSource = ds.LessonList();

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ds.AddLesson(TxtClubName.Text);
            MessageBox.Show("Lesson addition process has been completed");
            list();
            
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.LessonList();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}
