﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;
using Model;


namespace CourseSelectionSystem
{
    public partial class FmAddCourse : Form
    {
        private string cname;
        private int credit;
        private int week;
        private int section;
        private int tid;
        private int pid;
        private int precourse;
        private int maxstu;

        public FmAddCourse()
        {
            InitializeComponent();
            this.cb_pid.DataSource = new PlaceBusiness().getAllPlace();
            this.cb_pid.DisplayMember = "pname";
            this.cb_pid.ValueMember = "pid";
            this.cb_tid.DataSource = new TeacherBusiness().getAllTeacherWithoutTname();
            this.cb_tid.DisplayMember = "tname";
            this.cb_tid.ValueMember = "tid";
        }
        public FmAddCourse(int tid)
        {
            InitializeComponent();
            this.tid = tid;
            this.cb_tid.Text = tid.ToString();
            this.cb_tid.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        //新增课程
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.tb_cname.Text != "" && this.tb_credit.Text != "" && this.cb_week.Text != "请选择周次" && this.cb_tid.Text != "请选择教师" && this.cb_section.Text != "请选择时间" && this.cb_pid.Text != "请选择地点")
            {
                cname = this.tb_cname.Text;
                credit = int.Parse(this.tb_credit.Text);
                week = this.cb_section.SelectedIndex + 1;//1:1-16 2:1-8 3:9-16
                section = this.cb_section.SelectedIndex+1;
                tid = int.Parse(this.cb_tid.SelectedValue.ToString());
                pid = int.Parse(this.cb_pid.SelectedValue.ToString());
                maxstu = int.Parse(this.tb_maxstu.Text);
                if (this.tb_precourse.Text != "")
                {
                    precourse = int.Parse(this.tb_precourse.Text);
                }
                else
                {
                    precourse = 0;
                }

                int cid = 0;
                CourseBusiness couBusiness = new CourseBusiness();
                CourseModel courseModel = new CourseModel(cid,cname,credit,week,section,tid,pid,precourse,maxstu);
                cid = couBusiness.addCourse(courseModel);
                if (cid != 0)
                {
                    MessageBox.Show("成功!");
                }
                else
                {
                    MessageBox.Show("失败，请重试!");
                }
                this.Dispose();
            }
            else
            {
                MessageBox.Show("请填写所有信息！");
            }
        }
    }
}
