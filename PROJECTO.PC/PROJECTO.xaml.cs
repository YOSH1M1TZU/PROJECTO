using System;
using System.Windows;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Windows.Input;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace PROJECTO.PC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(string userID)
        {
            InitializeComponent();
            Cursor = Cursors.Arrow;
            LoadData(userID);
        }

        public void LoadData(string userID)
        {
            var web_service = new localhost.Main();
            var result = web_service.LoadData(userID);
            
            name_surname_label.Content = result[0] + " " + result[1];
            label_Copy.Content = "Welcome " + result[0] + "!";

            List<string> data = new List<string>();
            
            for(int i=2;i<result.Length;i++)
            {
                data.Add(result[i]);
            }

            int spacer = 65;

            foreach (string proj in data)
            {
                Canvas project_canvas = new Canvas();
                project_canvas.Width = 1060;
                project_canvas.Height = 75;
                project_canvas.Name = "cnvs";
                Thickness project_margin = project_canvas.Margin;
                project_margin.Left = 20;
                project_margin.Top = spacer;
                project_canvas.Margin = project_margin;
                canvas_projects.Children.Add(project_canvas);

                Rectangle rect = new Rectangle();
                rect.Width = 1060;
                rect.Height = 75;
                rect.Name = "rect";
                rect.RadiusX = 5;
                rect.RadiusY = 5;
                rect.Fill = new SolidColorBrush(Color.FromArgb(255, 243, 243, 244));
                project_canvas.Children.Add(rect);

                Label project_name = new Label();
                project_name.Width = 550;
                project_name.Height = 55;
                Thickness project_name_margin = project_canvas.Margin;
                project_name_margin.Left = 10;
                project_name_margin.Top = 10;
                project_name.Margin = project_name_margin;
                project_name.FontSize = 36;
                project_name.FontFamily = new FontFamily("Aaargh");
                project_name.Content = proj;
                project_name.Name = "lb";
                project_canvas.Children.Add(project_name);

                Image edit_icon = new Image();
                edit_icon.Height = 40;
                edit_icon.Width = 40;
                edit_icon.Name = "edi";
                Thickness edit_margin = project_canvas.Margin;
                edit_margin.Left = 950;
                edit_margin.Top = 17;
                edit_icon.Margin = edit_margin;
                BitmapImage edit_image = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/projects/edit_project.png", UriKind.Relative));
                edit_icon.Source = edit_image;
                edit_icon.MouseDown += (source, e) =>
                {

                };
                edit_icon.MouseEnter += (source, e) =>
                {
                    edit_icon.Opacity = 0.3;
                    Cursor = Cursors.Hand;
                };
                edit_icon.MouseLeave += (source, e) =>
                {
                    edit_icon.Opacity = 1;
                    Cursor = Cursors.Arrow;
                };
                project_canvas.Children.Add(edit_icon);

                Image delete_icon = new Image();
                delete_icon.Height = 40;
                delete_icon.Width = 40;
                delete_icon.Name = "edi";
                Thickness delete_margin = project_canvas.Margin;
                delete_margin.Left = 1000;
                delete_margin.Top = 17;
                delete_icon.Margin = delete_margin;
                BitmapImage delete_image = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/projects/delete_project.png", UriKind.Relative));
                delete_icon.Source = delete_image;
                delete_icon.MouseDown += (source, e) =>
                {

                };
                delete_icon.MouseEnter += (source, e) =>
                {
                    delete_icon.Opacity = 0.3;
                    Cursor = Cursors.Hand;
                };
                delete_icon.MouseLeave += (source, e) =>
                {
                    delete_icon.Opacity = 1;
                    Cursor = Cursors.Arrow;
                };
                project_canvas.Children.Add(delete_icon);

                spacer += 95;
            }
        }

        private void btns_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender.GetType() == typeof(Label))
            {
                Label lb = (Label)sender;
                lb.Opacity = 0.7;
                Cursor = Cursors.Hand;
            }
            else
            {
                Image img = (Image)sender;
                img.Opacity = 0.7;
                Cursor = Cursors.Hand;
            }
        }

        private void btns_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender.GetType() == typeof(Label))
            {
                Label lb = (Label)sender;
                lb.Opacity = 1;
                Cursor = Cursors.Arrow;
            }
            else
            {
                Image img = (Image)sender;
                img.Opacity = 1;
                Cursor = Cursors.Arrow;
            }
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
