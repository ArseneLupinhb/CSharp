﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }



        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            tsslblUserName.Text = "欢迎" + UserHelper.userName + "使用通讯录";
            tsslblDate.Text = "当前日期:"+DateTime.Now.ToLongDateString();
        }

        private void tsmiContactList_Click(object sender, EventArgs e)
        {
            FormContactList frmContact = new FormContactList();
            frmContact.ShowDialog();
        }

        private void tsmiPwd_Click(object sender, EventArgs e)
        {
            FormPwdChange f = new FormPwdChange();
            f.ShowDialog();
        }

        private void tsmiContactAdd_Click(object sender, EventArgs e)
        {
            FormContactAdd f = new FormContactAdd();
            f.ShowDialog();
        }

        private void tsmiGroupList_Click(object sender, EventArgs e)
        {
            FormGroupList f = new FormGroupList();
            f.ShowDialog();
        }

        private void tsmiGroupAdd_Click(object sender, EventArgs e)
        {
            FormGroupAdd f = new FormGroupAdd();
            f.ShowDialog();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            FormAbout f = new FormAbout();
            f.ShowDialog();
        }

        private void tsmiDatabase_Click(object sender, EventArgs e)
        {
            FormDB f = new FormDB();
            f.ShowDialog();
        }
    }
}
