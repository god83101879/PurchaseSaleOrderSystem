using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchaseSaleOrderWinForm
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }

        public static class LoginInfo
        {
            public static int User_ID { get; set; }
            public static string User_Account { get; set; }
            public static string User_Password { get; set; }
        }
    }
}
