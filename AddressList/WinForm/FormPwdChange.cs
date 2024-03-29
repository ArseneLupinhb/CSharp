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
    public partial class FormPwdChange : Form
    {
        public FormPwdChange()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtOldPwd.Text.Trim() != UserHelper.password)
            {
                MessageBox.Show("原始密码错误！");
                txtOldPwd.Focus();
                return;
            }
            if (txtNewPwd.Text.Trim() == "")
            {
                MessageBox.Show("新密码不能为空，请输入！");
                txtNewPwd.Focus();
                return;
            }
            if (txtNewPwdAgain.Text.Trim() != txtNewPwd.Text.Trim())
            {
                MessageBox.Show("两次输入密码不一致，请重新输入！");
                txtNewPwdAgain.Focus();
                return;
            }
            Model.User model = new Model.User();
            model.UserName = UserHelper.userName;
            model.Password = txtNewPwd.Text.Trim();//新密码
            BLL.User user = new BLL.User();
            if (user.Update(model))
            {
                UserHelper.password = model.Password;
                MessageBox.Show("密码更新成功！");//同步修改保存在UserHelpher类中的密码
            }
            else
            {
                MessageBox.Show("密码修改失败！");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
