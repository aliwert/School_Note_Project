using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
