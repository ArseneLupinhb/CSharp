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
    public partial class FormContactList : Form
    {
        public FormContactList()
        {
            InitializeComponent();
        }

        BLL.Contact bll = new BLL.Contact();
        public void Fill()
        {
            string strWhere = "";
            if (cboCondition.Text == "姓名")
                strWhere="Name like '%" + txtSearch.Text.Trim() + "%'";
            if(cboCondition.Text == "手机")
                strWhere = "Phone like '%" + txtSearch.Text.Trim() + "%'";
            dgvContactList.DataSource = bll.GetList(strWhere);              
        }

        private void FormContactList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormContactAdd frmAddContact = new FormContactAdd();
            frmAddContact.ShowDialog();
            Fill();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Fill();
        }

        private void dgvContactList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = 0;
            try
            {
                id = (int)dgvContactList.CurrentRow.Cells[0].Value;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请双击有效数据行！");
                return;
            }
            FormContactDetail f = new FormContactDetail(id);
            f.ShowDialog();
            Fill();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                id = (int)dgvContactList.CurrentRow.Cells[0].Value;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请选择有效数据行！");
                return;
            }
            if (MessageBox.Show("确定要删除吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            if (bll.Delete(id))
            {
                MessageBox.Show("删除成功！");
            }
            else
            {
                MessageBox.Show("删除失败！");
            }
            Fill();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                id = (int)dgvContactList.CurrentRow.Cells[0].Value;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请选择有效数据行！");
                return;
            }
            FormContactDetail f = new FormContactDetail(id);
            f.ShowDialog();
            Fill();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
