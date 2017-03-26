using System;
using System.Windows;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Windows.Input;
using System.Windows.Controls;

namespace PROJECTO.PC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Cursor = Cursors.Arrow;
        }

        private void btns_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Label lb = (Label)sender;
            lb.Opacity = 0.7;
            Cursor = Cursors.Hand;
        }

        private void btns_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Label lb = (Label)sender;
            lb.Opacity = 1;
            Cursor = Cursors.Arrow;
        }

        private void btn_exit_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btn_minimize_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Rectangle_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
