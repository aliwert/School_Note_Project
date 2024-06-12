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
            ds.AddLesson(TxtLessonName.Text);
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

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ds.DeleteLesson(byte.Parse(TxtLessonid.Text));
            MessageBox.Show("Lesson deleted succesfully");
            list();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            ds.UpdateLesson(TxtLessonName.Text, byte.Parse(TxtLessonid.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtLessonid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtLessonName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            
        }
    }
}
