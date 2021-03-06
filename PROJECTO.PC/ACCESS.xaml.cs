﻿using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PROJECTO.PC
{
    public partial class INITIATOR : Window
    {
        public INITIATOR()
        {
            InitializeComponent();
            canvas_loading.Visibility = Visibility.Visible;
            canvas_login.Visibility = Visibility.Hidden;
            canvas_register.Visibility = Visibility.Hidden;
            canvas_forgot.Visibility = Visibility.Hidden;
            Internet_Check();
        }

        #region UI event handlers
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void btns_MouseEnter(object sender, MouseEventArgs e)
        {
            Label lb = (Label)sender;
            lb.Opacity = 0.7;
            Cursor = Cursors.Hand;
        }

        private void btns_MouseLeave(object sender, MouseEventArgs e)
        {
            Label lb = (Label)sender;
            lb.Opacity = 1;
            Cursor = Cursors.Arrow;
        }

        private void btn_exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btn_minimize_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btn_new_account_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            canvas_loading.Visibility = Visibility.Hidden;
            canvas_login.Visibility = Visibility.Hidden;
            canvas_register.Visibility = Visibility.Visible;
            canvas_forgot.Visibility = Visibility.Hidden;
        }

        private void btn_back_register_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            canvas_loading.Visibility = Visibility.Hidden;
            canvas_login.Visibility = Visibility.Visible;
            canvas_register.Visibility = Visibility.Hidden;
            canvas_forgot.Visibility = Visibility.Hidden;
        }

        private void btn_back_forgot_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            canvas_loading.Visibility = Visibility.Hidden;
            canvas_login.Visibility = Visibility.Visible;
            canvas_register.Visibility = Visibility.Hidden;
            canvas_forgot.Visibility = Visibility.Hidden;
        }

        private void btn_goto_forgot_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            canvas_loading.Visibility = Visibility.Hidden;
            canvas_login.Visibility = Visibility.Hidden;
            canvas_register.Visibility = Visibility.Hidden;
            canvas_forgot.Visibility = Visibility.Visible;
        }
        #endregion







        public async void Internet_Check()
        {
            await Task.Delay(500);
            await Check();
        }
        public async Task Check()
        {
            try
            {
                Ping ping = new Ping();
                string host = "localhost";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions options = new PingOptions();
                PingReply reply = ping.Send(host, timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                {
                    canvas_loading.Visibility = Visibility.Hidden;
                    canvas_login.Visibility = Visibility.Visible;
                    canvas_network_error.Visibility = Visibility.Hidden;
                    canvas_register.Visibility = Visibility.Hidden;
                    canvas_forgot.Visibility = Visibility.Hidden;
                }
                else
                {
                    canvas_loading.Visibility = Visibility.Hidden;
                    canvas_login.Visibility = Visibility.Hidden;
                    canvas_network_error.Visibility = Visibility.Visible;
                    canvas_register.Visibility = Visibility.Hidden;
                    canvas_forgot.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                canvas_loading.Visibility = Visibility.Hidden;
                canvas_login.Visibility = Visibility.Hidden;
                canvas_network_error.Visibility = Visibility.Visible;
                canvas_register.Visibility = Visibility.Hidden;
                canvas_forgot.Visibility = Visibility.Hidden;
            }
        }

        private void btn_login_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var web_service = new AccMgmtWS.AccMgmt();
            string result = web_service.Login(email_login.Text.ToString(), password_login.Password.ToString());
            if (result != "ERR")
            {
                MainWindow mw = new MainWindow(result);
                mw.Show();
                this.Hide();
            }
            else
            {
                error1.Content = "Oh no! It seems that your";
                error2.Content = "username or password is incorrect.";
            }
            //MessageBox.Show(result);
        }

        private void btn_register_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var web_service = new AccMgmtWS.AccMgmt();
            string result = web_service.Register(name_register.Text.ToString(), surname_register.Text.ToString(), email_register.Text.ToString(), password_register.Text.ToString());
            if (result == "OK")
            {
                canvas_loading.Visibility = Visibility.Hidden;
                canvas_login.Visibility = Visibility.Visible;
                canvas_register.Visibility = Visibility.Hidden;
                canvas_forgot.Visibility = Visibility.Hidden;
                message_label.Content = "Almost done!";
                small_message_label.Content = "Now log in to your new account:";
                error1.Content = "";
                error2.Content = "";
            }
            else { MessageBox.Show(result); }
        }

        private void btn_forgot_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void btn_reconnect_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            canvas_loading.Visibility = Visibility.Visible;
            canvas_login.Visibility = Visibility.Hidden;
            canvas_register.Visibility = Visibility.Hidden;
            canvas_forgot.Visibility = Visibility.Hidden;
            canvas_network_error.Visibility = Visibility.Hidden;
            Internet_Check();
        }
    }
}
