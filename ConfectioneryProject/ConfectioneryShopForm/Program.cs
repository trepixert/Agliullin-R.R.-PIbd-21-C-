﻿using System;
using System.Windows.Forms;

namespace ConfectioneryShopForm {
    static class Program {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main() {
            APICustomer.Connect();
            MailCustomer.Connect();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ConfectioneryShopForm());
        }
    }
}