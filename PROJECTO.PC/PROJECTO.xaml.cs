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
using System.Linq;
using System.Windows.Media.Effects;

namespace PROJECTO.PC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string chosenProject = null;
        public bool editingTodo = false;
        public string currentUserID = null;

        string oldTitleTodo = null;
        string oldDescTodo = null;

        public MainWindow(string userID)
        {
            InitializeComponent();
            Cursor = Cursors.Arrow;
            currentUserID = userID;

            LoadProjects(userID);
            LoadTodos(chosenProject);
            LoadInProgress(chosenProject);
            LoadForReview(chosenProject);
            LoadDone(chosenProject);
            LoadProjectMembers(chosenProject);

            canvas_dashboard.Visibility = Visibility.Visible;
            canvas_projects.Visibility = Visibility.Hidden;
            canvas_tasks.Visibility = Visibility.Hidden;
            canvas_storage.Visibility = Visibility.Hidden;
            canvas_communication.Visibility = Visibility.Hidden;
            canvas_finances.Visibility = Visibility.Hidden;
            canvas_charts.Visibility = Visibility.Hidden;
            canvas_users.Visibility = Visibility.Hidden;
            canvas_achievs.Visibility = Visibility.Hidden;
            canvas_settings.Visibility = Visibility.Hidden;
        }


        
        #region UI handlers
        private void btns_MouseEnter(object sender, MouseEventArgs e)
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

        private void btns_MouseLeave(object sender, MouseEventArgs e)
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

        private void btn_exit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btn_minimize_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void menu_MouseEnter(object sender, MouseEventArgs e)
        {
            Label lb = (Label)sender;
            if (lb.Name == "dashboard_label" || lb.Name == "settings_label")
            {
                lb.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                lb.Foreground.Opacity = 1;
                Cursor = Cursors.Hand;
            }
            else
            {
                lb.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                lb.Foreground.Opacity = 1;
                Cursor = Cursors.Hand;
            }

            switch (lb.Name)
            {
                case "dashboard_label":
                    {
                        dashboard_icon.Opacity = 1;
                    } break;
                case "projects_label":
                    {
                        projects_icon.Opacity = 1;
                    }
                    break;
                case "todo_label":
                    {
                        todo_icon.Opacity = 1;
                    }
                    break;
                case "storage_label":
                    {
                        storage_icon.Opacity = 1;
                    }
                    break;
                case "communication_label":
                    {
                        communication_icon.Opacity = 1;
                    }
                    break;
                case "finances_label":
                    {
                        finances_icon.Opacity = 1;
                    }
                    break;
                case "charts_label":
                    {
                        charts_icon.Opacity = 1;
                    }
                    break;
                case "users_label":
                    {
                        users_icon.Opacity = 1;
                    }
                    break;
                case "achievs_label":
                    {
                        achievs_icon.Opacity = 1;
                    }
                    break;
                case "settings_label":
                    {
                        settings_icon.Opacity = 1;
                    }
                    break;
            }
        }

        private void menu_MouseLeave(object sender, MouseEventArgs e)
        {
            Label lb = (Label)sender;
            if (lb.Name == "dashboard_label" || lb.Name == "settings_label")
            {
                lb.Foreground = new SolidColorBrush(Color.FromRgb(255,255,255));
                lb.Foreground.Opacity = 0.6;
                Cursor = Cursors.Arrow;
            }
            else
            {
                lb.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                lb.Foreground.Opacity = 0.6;
                Cursor = Cursors.Arrow;
            }
            
            switch (lb.Name)
            {
                case "dashboard_label":
                    {
                        dashboard_icon.Opacity = 0.6;
                    }
                    break;
                case "projects_label":
                    {
                        projects_icon.Opacity = 0.6;
                    }
                    break;
                case "todo_label":
                    {
                        todo_icon.Opacity = 0.6;
                    }
                    break;
                case "storage_label":
                    {
                        storage_icon.Opacity = 0.6;
                    }
                    break;
                case "communication_label":
                    {
                        communication_icon.Opacity = 0.6;
                    }
                    break;
                case "finances_label":
                    {
                        finances_icon.Opacity = 0.6;
                    }
                    break;
                case "charts_label":
                    {
                        charts_icon.Opacity = 0.6;
                    }
                    break;
                case "users_label":
                    {
                        users_icon.Opacity = 0.6;
                    }
                    break;
                case "achievs_label":
                    {
                        achievs_icon.Opacity = 0.6;
                    }
                    break;
                case "settings_label":
                    {
                        settings_icon.Opacity = 0.6;
                    }
                    break;
            }
        }

        private void menu_Clicked(object sender, MouseButtonEventArgs e)
        {
            Label lb = (Label)sender;
            switch (lb.Name)
            {
                case "dashboard_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Visible;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_tasks.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_communication.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_users.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "projects_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Visible;
                        canvas_tasks.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_communication.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_users.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "todo_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_tasks.Visibility = Visibility.Visible;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_communication.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_users.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "inprogress_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_tasks.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_communication.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_users.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "finished_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_tasks.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_communication.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_users.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "bugs_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_tasks.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_communication.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_users.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "storage_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_tasks.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Visible;
                        canvas_communication.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_users.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "communication_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_tasks.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_communication.Visibility = Visibility.Visible;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_users.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "finances_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_tasks.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_communication.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Visible;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_users.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "charts_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_tasks.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_communication.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Visible;
                        canvas_users.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "users_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_tasks.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_communication.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_users.Visibility = Visibility.Visible;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "achievs_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_tasks.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_communication.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_users.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Visible;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "settings_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_tasks.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_communication.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_users.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Visible;
                    }
                    break;
            }
        }
        #endregion



        #region DBinfoRetrieving
        public void LoadProjects(string userID)
        {
            var web_service = new localhost.Main();
            var result = web_service.LoadProjects(userID);

            chosenProject = result[2];

            name_surname_label.Content = result[0] + " " + result[1];
            label_Copy.Content = "Welcome " + result[0] + "!";

            List<string> dataProjects = new List<string>();

            for (int i = 3; i < result.Length; i++)
            {
                dataProjects.Add(result[i]);
            }

            int spacer = 65;

            foreach (string proj in dataProjects)
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
                rect.Fill = new SolidColorBrush(Color.FromArgb(255, 47, 64, 80));
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
                project_name.Foreground = Brushes.White;
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



        public void LoadTodos(string chsnProj)
        {
            todo_wrapper.Height = 610;
            var coll = todo_wrapper.Children.OfType<Canvas>().ToList();
            foreach(Canvas cv in coll)
            {
                todo_wrapper.Children.Remove(cv);
            }
            var web_service = new localhost.Main();
            var result = web_service.LoadTodos(chsnProj);

            int spacerY = 5;
            int counter = 0;

            for(int i=0;i<result.Length;i+=2)
            {
                Canvas todo_canvas = new Canvas();
                todo_canvas.Width = 250;
                todo_canvas.Height = 155;
                todo_canvas.Name = "cnvs";
                Thickness project_margin = todo_wrapper.Margin;
                project_margin.Left = 5;
                project_margin.Top = spacerY;
                todo_canvas.Margin = project_margin;
                //canvas_tasks.Children.Add(todo_canvas);
                todo_wrapper.Children.Add(todo_canvas);

                Rectangle rect = new Rectangle();
                rect.Width = 250;
                rect.Height = 155;
                //rect.Name = "rect";
                rect.RadiusX = 5;
                rect.RadiusY = 5;
                rect.Stroke = new SolidColorBrush(Color.FromArgb(255, 232, 235, 237));
                rect.Fill = Brushes.White;
                rect.MouseDown += (source, e) =>
                {

                };
                todo_canvas.Children.Add(rect);

                TextBox todo_title = new TextBox();
                todo_title.Width = 230;
                todo_title.Height = 31;
                Thickness todo_title_margin = todo_canvas.Margin;
                todo_title_margin.Left = 10;
                todo_title_margin.Top = 5;
                todo_title.Margin = todo_title_margin;
                todo_title.FontSize = 14;
                todo_title.BorderThickness = new Thickness(0, 0, 0, 2);
                todo_title.BorderBrush = Brushes.White;
                todo_title.AllowDrop = false;
                todo_title.Focusable = false;
                todo_title.Background = Brushes.White;
                todo_title.FontFamily = new FontFamily("Aaargh");
                todo_title.Foreground = Brushes.Black;
                todo_title.Text = result[i];
                //todo_title.Name = "lb";
                todo_title.MaxLength = 30;
                todo_title.Cursor = Cursors.Arrow;
                todo_canvas.Children.Add(todo_title);

                TextBox tb = new TextBox();
                tb.Width = 230;
                tb.Height = 80;
                Thickness tb_margin = todo_canvas.Margin;
                tb_margin.Left = 10;
                tb_margin.Top = 38;
                tb.Margin = tb_margin;
                tb.FontSize = 14;
                tb.BorderThickness = new Thickness(0, 0, 0, 2);
                tb.BorderBrush = Brushes.White;
                tb.AllowDrop = false;
                tb.Focusable = false;
                tb.Background = Brushes.White;
                tb.Foreground = Brushes.Black;
                tb.Text = result[i + 1];
                tb.Cursor = Cursors.Arrow;
                tb.TextWrapping = TextWrapping.Wrap;
                tb.MaxLength = 210;
                todo_canvas.Children.Add(tb);

                TextBox tb2 = new TextBox();
                tb2.Width = 160;
                tb2.Height = 32;
                Thickness tb2_margin = todo_canvas.Margin;
                tb2_margin.Left = 10;
                tb2_margin.Top = 118;
                tb2.Margin = tb2_margin;
                tb2.FontSize = 16;
                tb2.BorderThickness = new Thickness(0, 0, 0, 2);
                tb2.BorderBrush = Brushes.White;
                tb2.AllowDrop = false;
                tb2.Focusable = false;
                tb2.Background = Brushes.White;
                tb2.Foreground = Brushes.Black;
                tb2.VerticalAlignment = VerticalAlignment.Center;
                tb2.FontWeight = FontWeights.Bold;
                tb2.Text = "Maintenance";
                tb2.Cursor = Cursors.Arrow;
                tb2.TextWrapping = TextWrapping.Wrap;
                tb2.MaxLength = 210;
                todo_canvas.Children.Add(tb2);

                Image edit_icon = new Image();
                edit_icon.Height = 30;
                edit_icon.Width = 30;
                edit_icon.Name = "edi";
                Thickness edit_margin = todo_canvas.Margin;
                edit_margin.Left = 170;
                edit_margin.Top = 120;
                edit_icon.Margin = edit_margin;
                BitmapImage edit_image = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/todo/edit_task.png", UriKind.Relative));
                edit_icon.Source = edit_image;
                edit_icon.MouseDown += (source, e) =>
                {
                    if(!editingTodo)
                    {
                        todo_title.CaretBrush = null;
                        tb.CaretBrush = null;
                        tb.Focusable = true;
                        tb.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 186, 121));

                        todo_title.Focusable = true;
                        todo_title.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 186, 121));

                        BitmapImage edit_image2 = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/todo/confirm_task.png", UriKind.Relative));
                        edit_icon.Source = edit_image2;
                        editingTodo = true;
                        oldTitleTodo = todo_title.Text.ToString();
                        oldDescTodo = tb.Text.ToString();
                    }
                    else
                    {
                        todo_title.CaretBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                        tb.CaretBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                        tb.Focusable = false;
                        tb.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 243, 243, 244));

                        todo_title.Focusable = false;
                        todo_title.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 243, 243, 244));

                        BitmapImage edit_image2 = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/todo/edit_task.png", UriKind.Relative));
                        edit_icon.Source = edit_image2;
                        editingTodo = false;

                        var web_service2 = new localhost.Main();
                        var result2 = web_service.EditTodos(oldTitleTodo, todo_title.Text.ToString(), tb.Text.ToString(), chosenProject);
                        LoadTodos(chosenProject);
                    }
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
                todo_canvas.Children.Add(edit_icon);

                Image delete_icon = new Image();
                delete_icon.Height = 30;
                delete_icon.Width = 30;
                delete_icon.Name = "edi";
                Thickness delete_margin = todo_canvas.Margin;
                delete_margin.Left = 210;
                delete_margin.Top = 120;
                delete_icon.Margin = delete_margin;
                BitmapImage delete_image = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/projects/delete_project.png", UriKind.Relative));
                delete_icon.Source = delete_image;
                delete_icon.MouseDown += (source, e) =>
                {
                    var web_service2 = new localhost.Main();
                    var result2 = web_service.RemoveTodos(todo_title.Text.ToString(), chosenProject);
                    LoadTodos(chosenProject);
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
                todo_canvas.Children.Add(delete_icon);

                spacerY += 160;
                if(i==6) todo_wrapper.Height += 35;
                else if(i>6) todo_wrapper.Height += 165;
                counter++;
            }
            todo_counter.Content = counter.ToString();
        }

        public void LoadInProgress(string chsnProj)
        {
            inprogress_wrapper.Height = 610;
            var coll = inprogress_wrapper.Children.OfType<Canvas>().ToList();
            foreach (Canvas cv in coll)
            {
                inprogress_wrapper.Children.Remove(cv);
            }
            var web_service = new localhost.Main();
            var result = web_service.LoadTodos(chsnProj);

            int spacerY = 5;
            int counter = 0;

            for (int i = 0; i < result.Length; i += 2)
            {
                Canvas todo_canvas = new Canvas();
                todo_canvas.Width = 250;
                todo_canvas.Height = 155;
                todo_canvas.Name = "cnvs";
                Thickness project_margin = inprogress_wrapper.Margin;
                project_margin.Left = 5;
                project_margin.Top = spacerY;
                todo_canvas.Margin = project_margin;
                //canvas_tasks.Children.Add(todo_canvas);
                inprogress_wrapper.Children.Add(todo_canvas);

                Rectangle rect = new Rectangle();
                rect.Width = 250;
                rect.Height = 155;
                //rect.Name = "rect";
                rect.RadiusX = 5;
                rect.RadiusY = 5;
                rect.Stroke = new SolidColorBrush(Color.FromArgb(255, 232, 235, 237));
                rect.Fill = Brushes.White;
                rect.MouseDown += (source, e) =>
                {

                };
                todo_canvas.Children.Add(rect);

                TextBox todo_title = new TextBox();
                todo_title.Width = 230;
                todo_title.Height = 31;
                Thickness todo_title_margin = todo_canvas.Margin;
                todo_title_margin.Left = 10;
                todo_title_margin.Top = 5;
                todo_title.Margin = todo_title_margin;
                todo_title.FontSize = 14;
                todo_title.BorderThickness = new Thickness(0, 0, 0, 2);
                todo_title.BorderBrush = Brushes.White;
                todo_title.AllowDrop = false;
                todo_title.Focusable = false;
                todo_title.Background = Brushes.White;
                todo_title.FontFamily = new FontFamily("Aaargh");
                todo_title.Foreground = Brushes.Black;
                todo_title.Text = result[i];
                //todo_title.Name = "lb";
                todo_title.MaxLength = 30;
                todo_title.Cursor = Cursors.Arrow;
                todo_canvas.Children.Add(todo_title);

                TextBox tb = new TextBox();
                tb.Width = 230;
                tb.Height = 80;
                Thickness tb_margin = todo_canvas.Margin;
                tb_margin.Left = 10;
                tb_margin.Top = 38;
                tb.Margin = tb_margin;
                tb.FontSize = 14;
                tb.BorderThickness = new Thickness(0, 0, 0, 2);
                tb.BorderBrush = Brushes.White;
                tb.AllowDrop = false;
                tb.Focusable = false;
                tb.Background = Brushes.White;
                tb.Foreground = Brushes.Black;
                tb.Text = result[i + 1];
                tb.Cursor = Cursors.Arrow;
                tb.TextWrapping = TextWrapping.Wrap;
                tb.MaxLength = 210;
                todo_canvas.Children.Add(tb);

                TextBox tb2 = new TextBox();
                tb2.Width = 160;
                tb2.Height = 32;
                Thickness tb2_margin = todo_canvas.Margin;
                tb2_margin.Left = 10;
                tb2_margin.Top = 118;
                tb2.Margin = tb2_margin;
                tb2.FontSize = 16;
                tb2.BorderThickness = new Thickness(0, 0, 0, 2);
                tb2.BorderBrush = Brushes.White;
                tb2.AllowDrop = false;
                tb2.Focusable = false;
                tb2.Background = Brushes.White;
                tb2.Foreground = Brushes.Black;
                tb2.VerticalAlignment = VerticalAlignment.Center;
                tb2.FontWeight = FontWeights.Bold;
                tb2.Text = "Maintenance";
                tb2.Cursor = Cursors.Arrow;
                tb2.TextWrapping = TextWrapping.Wrap;
                tb2.MaxLength = 210;
                todo_canvas.Children.Add(tb2);

                Image edit_icon = new Image();
                edit_icon.Height = 30;
                edit_icon.Width = 30;
                edit_icon.Name = "edi";
                Thickness edit_margin = todo_canvas.Margin;
                edit_margin.Left = 170;
                edit_margin.Top = 120;
                edit_icon.Margin = edit_margin;
                BitmapImage edit_image = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/todo/edit_task.png", UriKind.Relative));
                edit_icon.Source = edit_image;
                edit_icon.MouseDown += (source, e) =>
                {
                    if (!editingTodo)
                    {
                        todo_title.CaretBrush = null;
                        tb.CaretBrush = null;
                        tb.Focusable = true;
                        tb.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 186, 121));

                        todo_title.Focusable = true;
                        todo_title.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 186, 121));

                        BitmapImage edit_image2 = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/todo/confirm_task.png", UriKind.Relative));
                        edit_icon.Source = edit_image2;
                        editingTodo = true;
                        oldTitleTodo = todo_title.Text.ToString();
                        oldDescTodo = tb.Text.ToString();
                    }
                    else
                    {
                        todo_title.CaretBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                        tb.CaretBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                        tb.Focusable = false;
                        tb.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 243, 243, 244));

                        todo_title.Focusable = false;
                        todo_title.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 243, 243, 244));

                        BitmapImage edit_image2 = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/todo/edit_task.png", UriKind.Relative));
                        edit_icon.Source = edit_image2;
                        editingTodo = false;

                        var web_service2 = new localhost.Main();
                        var result2 = web_service.EditTodos(oldTitleTodo, todo_title.Text.ToString(), tb.Text.ToString(), chosenProject);
                        LoadTodos(chosenProject);
                    }
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
                todo_canvas.Children.Add(edit_icon);

                Image delete_icon = new Image();
                delete_icon.Height = 30;
                delete_icon.Width = 30;
                delete_icon.Name = "edi";
                Thickness delete_margin = todo_canvas.Margin;
                delete_margin.Left = 210;
                delete_margin.Top = 120;
                delete_icon.Margin = delete_margin;
                BitmapImage delete_image = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/projects/delete_project.png", UriKind.Relative));
                delete_icon.Source = delete_image;
                delete_icon.MouseDown += (source, e) =>
                {
                    var web_service2 = new localhost.Main();
                    var result2 = web_service.RemoveTodos(todo_title.Text.ToString(), chosenProject);
                    LoadTodos(chosenProject);
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
                todo_canvas.Children.Add(delete_icon);

                spacerY += 160;
                if (i == 6) inprogress_wrapper.Height += 35;
                else if (i > 6) inprogress_wrapper.Height += 165;
                counter++;
            }
            inprogress_counter.Content = counter.ToString();
        }

        public void LoadForReview(string chsnProj)
        {
            forreview_wrapper.Height = 610;
            var coll = forreview_wrapper.Children.OfType<Canvas>().ToList();
            foreach (Canvas cv in coll)
            {
                forreview_wrapper.Children.Remove(cv);
            }
            var web_service = new localhost.Main();
            var result = web_service.LoadTodos(chsnProj);

            int spacerY = 5;
            int counter = 0;

            for (int i = 0; i < result.Length; i += 2)
            {
                Canvas todo_canvas = new Canvas();
                todo_canvas.Width = 250;
                todo_canvas.Height = 155;
                todo_canvas.Name = "cnvs";
                Thickness project_margin = inprogress_wrapper.Margin;
                project_margin.Left = 5;
                project_margin.Top = spacerY;
                todo_canvas.Margin = project_margin;
                //canvas_tasks.Children.Add(todo_canvas);
                forreview_wrapper.Children.Add(todo_canvas);

                Rectangle rect = new Rectangle();
                rect.Width = 250;
                rect.Height = 155;
                //rect.Name = "rect";
                rect.RadiusX = 5;
                rect.RadiusY = 5;
                rect.Stroke = new SolidColorBrush(Color.FromArgb(255, 232, 235, 237));
                rect.Fill = Brushes.White;
                rect.MouseDown += (source, e) =>
                {

                };
                todo_canvas.Children.Add(rect);

                TextBox todo_title = new TextBox();
                todo_title.Width = 230;
                todo_title.Height = 31;
                Thickness todo_title_margin = todo_canvas.Margin;
                todo_title_margin.Left = 10;
                todo_title_margin.Top = 5;
                todo_title.Margin = todo_title_margin;
                todo_title.FontSize = 14;
                todo_title.BorderThickness = new Thickness(0, 0, 0, 2);
                todo_title.BorderBrush = Brushes.White;
                todo_title.AllowDrop = false;
                todo_title.Focusable = false;
                todo_title.Background = Brushes.White;
                todo_title.FontFamily = new FontFamily("Aaargh");
                todo_title.Foreground = Brushes.Black;
                todo_title.Text = result[i];
                //todo_title.Name = "lb";
                todo_title.MaxLength = 30;
                todo_title.Cursor = Cursors.Arrow;
                todo_canvas.Children.Add(todo_title);

                TextBox tb = new TextBox();
                tb.Width = 230;
                tb.Height = 80;
                Thickness tb_margin = todo_canvas.Margin;
                tb_margin.Left = 10;
                tb_margin.Top = 38;
                tb.Margin = tb_margin;
                tb.FontSize = 14;
                tb.BorderThickness = new Thickness(0, 0, 0, 2);
                tb.BorderBrush = Brushes.White;
                tb.AllowDrop = false;
                tb.Focusable = false;
                tb.Background = Brushes.White;
                tb.Foreground = Brushes.Black;
                tb.Text = result[i + 1];
                tb.Cursor = Cursors.Arrow;
                tb.TextWrapping = TextWrapping.Wrap;
                tb.MaxLength = 210;
                todo_canvas.Children.Add(tb);

                TextBox tb2 = new TextBox();
                tb2.Width = 160;
                tb2.Height = 32;
                Thickness tb2_margin = todo_canvas.Margin;
                tb2_margin.Left = 10;
                tb2_margin.Top = 118;
                tb2.Margin = tb2_margin;
                tb2.FontSize = 16;
                tb2.BorderThickness = new Thickness(0, 0, 0, 2);
                tb2.BorderBrush = Brushes.White;
                tb2.AllowDrop = false;
                tb2.Focusable = false;
                tb2.Background = Brushes.White;
                tb2.Foreground = Brushes.Black;
                tb2.VerticalAlignment = VerticalAlignment.Center;
                tb2.FontWeight = FontWeights.Bold;
                tb2.Text = "Maintenance";
                tb2.Cursor = Cursors.Arrow;
                tb2.TextWrapping = TextWrapping.Wrap;
                tb2.MaxLength = 210;
                todo_canvas.Children.Add(tb2);

                Image edit_icon = new Image();
                edit_icon.Height = 30;
                edit_icon.Width = 30;
                edit_icon.Name = "edi";
                Thickness edit_margin = todo_canvas.Margin;
                edit_margin.Left = 170;
                edit_margin.Top = 120;
                edit_icon.Margin = edit_margin;
                BitmapImage edit_image = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/todo/edit_task.png", UriKind.Relative));
                edit_icon.Source = edit_image;
                edit_icon.MouseDown += (source, e) =>
                {
                    if (!editingTodo)
                    {
                        todo_title.CaretBrush = null;
                        tb.CaretBrush = null;
                        tb.Focusable = true;
                        tb.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 186, 121));

                        todo_title.Focusable = true;
                        todo_title.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 186, 121));

                        BitmapImage edit_image2 = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/todo/confirm_task.png", UriKind.Relative));
                        edit_icon.Source = edit_image2;
                        editingTodo = true;
                        oldTitleTodo = todo_title.Text.ToString();
                        oldDescTodo = tb.Text.ToString();
                    }
                    else
                    {
                        todo_title.CaretBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                        tb.CaretBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                        tb.Focusable = false;
                        tb.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 243, 243, 244));

                        todo_title.Focusable = false;
                        todo_title.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 243, 243, 244));

                        BitmapImage edit_image2 = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/todo/edit_task.png", UriKind.Relative));
                        edit_icon.Source = edit_image2;
                        editingTodo = false;

                        var web_service2 = new localhost.Main();
                        var result2 = web_service.EditTodos(oldTitleTodo, todo_title.Text.ToString(), tb.Text.ToString(), chosenProject);
                        LoadTodos(chosenProject);
                    }
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
                todo_canvas.Children.Add(edit_icon);

                Image delete_icon = new Image();
                delete_icon.Height = 30;
                delete_icon.Width = 30;
                delete_icon.Name = "edi";
                Thickness delete_margin = todo_canvas.Margin;
                delete_margin.Left = 210;
                delete_margin.Top = 120;
                delete_icon.Margin = delete_margin;
                BitmapImage delete_image = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/projects/delete_project.png", UriKind.Relative));
                delete_icon.Source = delete_image;
                delete_icon.MouseDown += (source, e) =>
                {
                    var web_service2 = new localhost.Main();
                    var result2 = web_service.RemoveTodos(todo_title.Text.ToString(), chosenProject);
                    LoadTodos(chosenProject);
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
                todo_canvas.Children.Add(delete_icon);

                spacerY += 160;
                if (i == 6) forreview_wrapper.Height += 35;
                else if (i > 6) forreview_wrapper.Height += 165;
                counter++;
            }
            forreview_counter.Content = counter.ToString();
        }

        public void LoadDone(string chsnProj)
        {
            done_wrapper.Height = 610;
            var coll = done_wrapper.Children.OfType<Canvas>().ToList();
            foreach (Canvas cv in coll)
            {
                done_wrapper.Children.Remove(cv);
            }
            var web_service = new localhost.Main();
            var result = web_service.LoadTodos(chsnProj);

            int spacerY = 5;
            int counter = 0;

            for (int i = 0; i < result.Length; i += 2)
            {
                Canvas todo_canvas = new Canvas();
                todo_canvas.Width = 250;
                todo_canvas.Height = 155;
                todo_canvas.Name = "cnvs";
                Thickness project_margin = inprogress_wrapper.Margin;
                project_margin.Left = 5;
                project_margin.Top = spacerY;
                todo_canvas.Margin = project_margin;
                //canvas_tasks.Children.Add(todo_canvas);
                done_wrapper.Children.Add(todo_canvas);

                Rectangle rect = new Rectangle();
                rect.Width = 250;
                rect.Height = 155;
                //rect.Name = "rect";
                rect.RadiusX = 5;
                rect.RadiusY = 5;
                rect.Stroke = new SolidColorBrush(Color.FromArgb(255, 232, 235, 237));
                rect.Fill = Brushes.White;
                rect.MouseDown += (source, e) =>
                {

                };
                todo_canvas.Children.Add(rect);

                TextBox todo_title = new TextBox();
                todo_title.Width = 230;
                todo_title.Height = 31;
                Thickness todo_title_margin = todo_canvas.Margin;
                todo_title_margin.Left = 10;
                todo_title_margin.Top = 5;
                todo_title.Margin = todo_title_margin;
                todo_title.FontSize = 14;
                todo_title.BorderThickness = new Thickness(0, 0, 0, 2);
                todo_title.BorderBrush = Brushes.White;
                todo_title.AllowDrop = false;
                todo_title.Focusable = false;
                todo_title.Background = Brushes.White;
                todo_title.FontFamily = new FontFamily("Aaargh");
                todo_title.Foreground = Brushes.Black;
                todo_title.Text = result[i];
                //todo_title.Name = "lb";
                todo_title.MaxLength = 30;
                todo_title.Cursor = Cursors.Arrow;
                todo_canvas.Children.Add(todo_title);

                TextBox tb = new TextBox();
                tb.Width = 230;
                tb.Height = 80;
                Thickness tb_margin = todo_canvas.Margin;
                tb_margin.Left = 10;
                tb_margin.Top = 38;
                tb.Margin = tb_margin;
                tb.FontSize = 14;
                tb.BorderThickness = new Thickness(0, 0, 0, 2);
                tb.BorderBrush = Brushes.White;
                tb.AllowDrop = false;
                tb.Focusable = false;
                tb.Background = Brushes.White;
                tb.Foreground = Brushes.Black;
                tb.Text = result[i + 1];
                tb.Cursor = Cursors.Arrow;
                tb.TextWrapping = TextWrapping.Wrap;
                tb.MaxLength = 210;
                todo_canvas.Children.Add(tb);

                TextBox tb2 = new TextBox();
                tb2.Width = 160;
                tb2.Height = 32;
                Thickness tb2_margin = todo_canvas.Margin;
                tb2_margin.Left = 10;
                tb2_margin.Top = 118;
                tb2.Margin = tb2_margin;
                tb2.FontSize = 16;
                tb2.BorderThickness = new Thickness(0, 0, 0, 2);
                tb2.BorderBrush = Brushes.White;
                tb2.AllowDrop = false;
                tb2.Focusable = false;
                tb2.Background = Brushes.White;
                tb2.Foreground = Brushes.Black;
                tb2.VerticalAlignment = VerticalAlignment.Center;
                tb2.FontWeight = FontWeights.Bold;
                tb2.Text = "Maintenance";
                tb2.Cursor = Cursors.Arrow;
                tb2.TextWrapping = TextWrapping.Wrap;
                tb2.MaxLength = 210;
                todo_canvas.Children.Add(tb2);

                Image edit_icon = new Image();
                edit_icon.Height = 30;
                edit_icon.Width = 30;
                edit_icon.Name = "edi";
                Thickness edit_margin = todo_canvas.Margin;
                edit_margin.Left = 170;
                edit_margin.Top = 120;
                edit_icon.Margin = edit_margin;
                BitmapImage edit_image = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/todo/edit_task.png", UriKind.Relative));
                edit_icon.Source = edit_image;
                edit_icon.MouseDown += (source, e) =>
                {
                    if (!editingTodo)
                    {
                        todo_title.CaretBrush = null;
                        tb.CaretBrush = null;
                        tb.Focusable = true;
                        tb.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 186, 121));

                        todo_title.Focusable = true;
                        todo_title.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 186, 121));

                        BitmapImage edit_image2 = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/todo/confirm_task.png", UriKind.Relative));
                        edit_icon.Source = edit_image2;
                        editingTodo = true;
                        oldTitleTodo = todo_title.Text.ToString();
                        oldDescTodo = tb.Text.ToString();
                    }
                    else
                    {
                        todo_title.CaretBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                        tb.CaretBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                        tb.Focusable = false;
                        tb.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 243, 243, 244));

                        todo_title.Focusable = false;
                        todo_title.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 243, 243, 244));

                        BitmapImage edit_image2 = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/todo/edit_task.png", UriKind.Relative));
                        edit_icon.Source = edit_image2;
                        editingTodo = false;

                        var web_service2 = new localhost.Main();
                        var result2 = web_service.EditTodos(oldTitleTodo, todo_title.Text.ToString(), tb.Text.ToString(), chosenProject);
                        LoadTodos(chosenProject);
                    }
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
                todo_canvas.Children.Add(edit_icon);

                Image delete_icon = new Image();
                delete_icon.Height = 30;
                delete_icon.Width = 30;
                delete_icon.Name = "edi";
                Thickness delete_margin = todo_canvas.Margin;
                delete_margin.Left = 210;
                delete_margin.Top = 120;
                delete_icon.Margin = delete_margin;
                BitmapImage delete_image = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/projects/delete_project.png", UriKind.Relative));
                delete_icon.Source = delete_image;
                delete_icon.MouseDown += (source, e) =>
                {
                    var web_service2 = new localhost.Main();
                    var result2 = web_service.RemoveTodos(todo_title.Text.ToString(), chosenProject);
                    LoadTodos(chosenProject);
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
                todo_canvas.Children.Add(delete_icon);

                spacerY += 160;
                if (i == 6) done_wrapper.Height += 35;
                else if (i > 6) done_wrapper.Height += 165;
                counter++;
            }
            done_counter.Content = counter.ToString();
        }



        public void LoadProjectMembers(string chsnProj)
        {
            var web_service = new localhost.Main();
            var result = web_service.LoadProjectMembers(chsnProj);

            int spacerY1 = 5;
            int spacerY2 = 10;

            foreach(string member in result)
            {
                Canvas cv = new Canvas();
                cv.Width = 483;
                cv.Height = 60;
                Thickness member_margin = comm_members_wrapper.Margin;
                member_margin.Left = 0;
                member_margin.Top = spacerY1;
                cv.Margin = member_margin;
                comm_members_wrapper.Children.Add(cv);

                Rectangle rect = new Rectangle();
                rect.Width = 483;
                rect.Height = 60;
                rect.Stroke = new SolidColorBrush(Color.FromArgb(255, 232, 235, 237));
                rect.Fill = new SolidColorBrush(Color.FromArgb(255, 243, 243, 244));
                rect.MouseEnter += (source, e) =>
                {
                    rect.Fill = new SolidColorBrush(Color.FromArgb(255, 52, 152, 219));
                };
                rect.MouseLeave += (source, e) =>
                {
                    rect.Fill = new SolidColorBrush(Color.FromArgb(255, 243, 243, 244));
                };
                cv.Children.Add(rect);

                Image img = new Image();
                img.Width = 50;
                img.Height = 50;
                Thickness img_margin = cv.Margin;
                img_margin.Left = 10;
                img_margin.Top = 5;
                img.Margin = img_margin;
                img.Source = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/avatar.png", UriKind.Relative));
                cv.Children.Add(img);

                Label lb = new Label();
                lb.Width = 360;
                lb.Height = 40;
                Thickness lb_margin = cv.Margin;
                lb_margin.Left = 70;
                lb_margin.Top = 10;
                lb.Margin = lb_margin;
                Thickness lb_padding = lb.Padding;
                lb_padding.Left = 0;
                lb_padding.Top = 0;
                lb_padding.Bottom = 0;
                lb.Padding = lb_padding;
                lb.FontFamily = new FontFamily("Aaargh");
                lb.FontSize = 24;
                lb.Content = member;
                lb.VerticalContentAlignment = VerticalAlignment.Center;
                lb.MouseEnter += (source, e) =>
                {
                    rect.Fill = new SolidColorBrush(Color.FromArgb(255, 52, 152, 219));
                };
                lb.MouseLeave += (source, e) =>
                {
                    rect.Fill = new SolidColorBrush(Color.FromArgb(255, 243, 243, 244));
                };
                cv.Children.Add(lb);

                spacerY1 += 65;
            }

            foreach (string member in result)
            {
                Canvas cv = new Canvas();
                cv.Width = 1040;
                cv.Height = 80;
                Thickness member_margin = members_wrapper.Margin;
                member_margin.Left = 10;
                member_margin.Top = spacerY2;
                cv.Margin = member_margin;
                members_wrapper.Children.Add(cv);

                Rectangle rect = new Rectangle();
                rect.Width = 1040;
                rect.Height = 80;
                rect.Stroke = new SolidColorBrush(Color.FromArgb(255, 232, 235, 237));
                rect.Fill = new SolidColorBrush(Color.FromArgb(255, 243, 243, 244));
                cv.Children.Add(rect);

                Image img = new Image();
                img.Width = 60;
                img.Height = 60;
                Thickness img_margin = cv.Margin;
                img_margin.Left = 10;
                img_margin.Top = 10;
                img.Margin = img_margin;
                img.Source = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/avatar.png", UriKind.Relative));
                cv.Children.Add(img);

                Label lb = new Label();
                lb.Width = 360;
                lb.Height = 30;
                Thickness lb_margin = cv.Margin;
                lb_margin.Left = 80;
                lb_margin.Top = 10;
                lb.Margin = lb_margin;
                Thickness lb_padding = lb.Padding;
                lb_padding.Left = 0;
                //lb_padding.Top = 0;
                lb.Padding = lb_padding;
                lb.FontFamily = new FontFamily("Aaargh");
                lb.FontSize = 16;
                lb.Content = member;
                lb.VerticalContentAlignment = VerticalAlignment.Center;
                cv.Children.Add(lb);

                Label lb2 = new Label();
                lb2.Width = 360;
                lb2.Height = 30;
                Thickness lb2_margin = cv.Margin;
                lb2_margin.Left = 80;
                lb2_margin.Top = 40;
                lb2.Margin = lb2_margin;
                Thickness lb2_padding = lb2.Padding;
                lb2_padding.Left = 0;
                //lb_padding.Top = 0;
                lb2.Padding = lb2_padding;
                lb2.FontFamily = new FontFamily("Aaargh");
                lb2.FontSize = 16;
                lb2.Content = "Short description of a profile.";
                lb2.VerticalContentAlignment = VerticalAlignment.Center;
                cv.Children.Add(lb2);

                Image img2 = new Image();
                img2.Width = 60;
                img2.Height = 60;
                Thickness img2_margin = cv.Margin;
                img2_margin.Left = 970;
                img2_margin.Top = 10;
                img2.Margin = img2_margin;
                img2.Source = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/todo/add_task.png", UriKind.Relative));
                img2.MouseEnter += (source, e) =>
                {
                    img2.Opacity = 0.7;
                    Cursor = Cursors.Hand;
                };
                img2.MouseLeave += (source, e) =>
                {
                    img2.Opacity = 1.0;
                    Cursor = Cursors.Arrow;
                };
                cv.Children.Add(img2);

                spacerY2 += 90;
            }
        }

        public void LoadMessages(string firstUserID, string secondUserID, string chsnProj)
        {

        }
        #endregion



        private void add_todo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var blur = new BlurEffect();
            blur.Radius = 9;
            canvas_main.Effect = blur;
            canvas_add_todo.Visibility = Visibility.Visible;
        }

        private void add_todo_confirm_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string title = add_todo_title.Text.ToString();
                string desc = add_todo_desc.Text.ToString();
                
                if(title!="" || desc!="")
                {
                    var web_service = new localhost.Main();
                    var result = web_service.AddTodos(title, desc, chosenProject);
                    LoadTodos(chosenProject);
                }

                canvas_main.Effect = null;
                add_todo_title.Text = "";
                add_todo_desc.Text = "";
                canvas_add_todo.Visibility = Visibility.Hidden;
            }
            catch (Exception ex) { }
        }

        private void add_todo_cancel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            canvas_main.Effect = null;
            add_todo_title.Text = "";
            add_todo_desc.Text = "";
            canvas_add_todo.Visibility = Visibility.Hidden;
        }



        private void find_member_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var web_service = new localhost.Main();
                var result = web_service.LoadMemberInfo(null, member_email.Text.ToString());
                members_wrapper.Children.Clear();

                if (result[0] == "ERR")
                {
                    Label lb = new Label();
                    lb.Width = 360;
                    lb.Height = 60;
                    //Thickness lb_margin = members_wrapper.Margin;
                    //lb_margin.Left = 80;
                    //lb_margin.Top = 10;
                    //lb.Margin = lb_margin;
                    //Thickness lb_padding = lb.Padding;
                    //lb_padding.Left = 0;
                    //lb_padding.Top = 0;
                    //lb.Padding = lb_padding;
                    lb.FontFamily = new FontFamily("Aaargh");
                    lb.FontSize = 24;
                    lb.Content = "Nothing Found!";
                    lb.Foreground = Brushes.Gray;
                    lb.VerticalContentAlignment = VerticalAlignment.Center;
                    members_wrapper.Children.Add(lb);
                    return;
                }

                int spacerY2 = 10;

                foreach (string member in result)
                {
                    Canvas cv = new Canvas();
                    cv.Width = 1040;
                    cv.Height = 80;
                    Thickness member_margin = members_wrapper.Margin;
                    member_margin.Left = 10;
                    member_margin.Top = spacerY2;
                    cv.Margin = member_margin;
                    members_wrapper.Children.Add(cv);

                    Rectangle rect = new Rectangle();
                    rect.Width = 1040;
                    rect.Height = 80;
                    rect.Stroke = new SolidColorBrush(Color.FromArgb(255, 232, 235, 237));
                    rect.Fill = new SolidColorBrush(Color.FromArgb(255, 243, 243, 244));
                    cv.Children.Add(rect);

                    Image img = new Image();
                    img.Width = 60;
                    img.Height = 60;
                    Thickness img_margin = cv.Margin;
                    img_margin.Left = 10;
                    img_margin.Top = 10;
                    img.Margin = img_margin;
                    img.Source = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/avatar.png", UriKind.Relative));
                    cv.Children.Add(img);

                    Label lb = new Label();
                    lb.Width = 360;
                    lb.Height = 30;
                    Thickness lb_margin = cv.Margin;
                    lb_margin.Left = 80;
                    lb_margin.Top = 10;
                    lb.Margin = lb_margin;
                    Thickness lb_padding = lb.Padding;
                    lb_padding.Left = 0;
                    //lb_padding.Top = 0;
                    lb.Padding = lb_padding;
                    lb.FontFamily = new FontFamily("Aaargh");
                    lb.FontSize = 16;
                    lb.Content = member;
                    lb.VerticalContentAlignment = VerticalAlignment.Center;
                    cv.Children.Add(lb);

                    Label lb2 = new Label();
                    lb2.Width = 360;
                    lb2.Height = 30;
                    Thickness lb2_margin = cv.Margin;
                    lb2_margin.Left = 80;
                    lb2_margin.Top = 40;
                    lb2.Margin = lb2_margin;
                    Thickness lb2_padding = lb2.Padding;
                    lb2_padding.Left = 0;
                    //lb_padding.Top = 0;
                    lb2.Padding = lb2_padding;
                    lb2.FontFamily = new FontFamily("Aaargh");
                    lb2.FontSize = 16;
                    lb2.Content = "Short description of a profile.";
                    lb2.VerticalContentAlignment = VerticalAlignment.Center;
                    cv.Children.Add(lb2);

                    Image img2 = new Image();
                    img2.Width = 60;
                    img2.Height = 60;
                    Thickness img2_margin = cv.Margin;
                    img2_margin.Left = 970;
                    img2_margin.Top = 10;
                    img2.Margin = img2_margin;
                    img2.Source = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/todo/add_task.png", UriKind.Relative));
                    img2.MouseEnter += (source, ev) =>
                    {
                        img2.Opacity = 0.7;
                        Cursor = Cursors.Hand;
                    };
                    img2.MouseLeave += (source, ev) =>
                    {
                        img2.Opacity = 1.0;
                        Cursor = Cursors.Arrow;
                    };
                    cv.Children.Add(img2);

                    spacerY2 += 90;
                }
            }
            catch (Exception ex) { }
        }



        private void message_textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if(message_textBox.Text != "")
                {
                    try
                    {
                        var web_service = new localhost.Main();
                        var result = web_service.SendMessage(message_textBox.Text.ToString(), currentUserID, "2", DateTime.Now.ToString(), chosenProject);
                        //LoadMessages(chosenProject);
                        message_textBox.Text = "";
                    }
                    catch (Exception ex) { }
                }
            }
        }
    }
}
