﻿using System;
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
    public partial class FrmTeacher : Form
    {
        public FrmTeacher()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmClub club = new FrmClub();
            club.Show();
        }

        private void BtnLesson_Click(object sender, EventArgs e)
        {
            FrmLessons lssn= new FrmLessons();
            lssn.Show();
        }

        private void FrmTeacher_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmStudent student = new FrmStudent();
            student.Show();

        }

        private void BtnExamMarks_Click(object sender, EventArgs e)
        {
            FrmExamNotes notes = new FrmExamNotes();
            notes.Show();

        }
    }
}
