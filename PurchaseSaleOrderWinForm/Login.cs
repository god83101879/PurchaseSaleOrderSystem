using PurchaseSaleOrderSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchaseSaleOrderWinForm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.AccTB.Text = "";
            this.PassTB.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            string Account = AccTB.Text;
            string Password = PassTB.Text;

            if (!string.IsNullOrWhiteSpace(Account) && !string.IsNullOrWhiteSpace(Password))
            {
                bool isSuccess = TryLogIn(Account, Password);
                if (isSuccess)
                {
                    PurchaseOrderList newForm = new PurchaseOrderList();
                    newForm.main = this;
                    newForm.Show();
                    this.AccTB.Text = "";
                    this.PassTB.Text = "";
                }
                else
                {
                    label4.Visible = true;
                    label4.Text = "帳號密碼輸入錯誤";
                }
            }
            else
            {
                label4.Visible = true;
                label4.Text = "帳號密碼欄位不可為空";
            }
        }

        public bool TryLogIn(string Account, string Password)
        {
            //若已是登入狀態則回傳true
            if (HasLogIned())
                return true;
            //從資料庫裡撈出符合帳號的資料,若沒有則回傳FALSE
            PSOrderSystemContext useraccount = new PSOrderSystemContext();
            User dtuserAccount = useraccount.Users.Where(obj => obj.user_account == Account).FirstOrDefault();
            if (dtuserAccount == null)
                return false;
            if (dtuserAccount == null || string.Compare(Password, dtuserAccount.user_password, false) != 0)
                return false;

            Program.LoginInfo.User_ID = dtuserAccount.user_id;
            Program.LoginInfo.User_Account = dtuserAccount.user_account;
            Program.LoginInfo.User_Password = dtuserAccount.user_password;
            return true;


        }

        public bool HasLogIned()
        {
            //定義變數取得登入狀態的Session，後面接as LogInfo 前面var判斷型別才不會出錯。 
            var val = Program.LoginInfo.User_Account;
            //檢查變數內有值且為true回傳true,否則回傳false
            if (val != null)
                return true;
            else
                return false;
        }
    }
}
