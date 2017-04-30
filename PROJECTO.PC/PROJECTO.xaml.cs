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
        public string whoAmICommWith = null;

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
            var web_service = new MainWS.Main();
            var result = web_service.LoadProjects(userID);

            chosenProject = result[2];

            name_surname_label.Content = result[0] + " " + result[1];
            label_Copy.Content = "Welcome " + result[0] + "!";

            List<string> dataProjects = new List<string>();

            for (int i = 3; i < result.Length; i++)
            {
                dataProjects.Add(result[i]);
            }

            int spacer = 5;
            int counter = 0;

            for(int zz=0; zz<dataProjects.Count; zz+=4)
            {
                Canvas project_canvas = new Canvas();
                project_canvas.Width = 1053;
                project_canvas.Height = 44;
                //project_canvas.Name = "cnvs";
                Thickness project_margin = project_canvas.Margin;
                project_margin.Left = 5;
                project_margin.Top = spacer;
                project_canvas.Margin = project_margin;
                projects_wrapper.Children.Add(project_canvas);

                Rectangle rect = new Rectangle();
                rect.Width = 1053;
                rect.Height = 44;
                //rect.Name = "rect";
                if(counter%2==0) rect.Fill = Brushes.White; //new SolidColorBrush(Color.FromArgb(255, 47, 64, 80));
                else rect.Fill = new SolidColorBrush(Color.FromArgb(255, 190, 222, 255));
                project_canvas.Children.Add(rect);

                Label project_name = new Label();
                project_name.Width = 300;
                project_name.Height = 40;
                Thickness project_name_margin = project_canvas.Margin;
                project_name_margin.Left = 5;
                project_name_margin.Top = 2;
                project_name.Margin = project_name_margin;
                project_name.FontSize = 24;
                project_name.FontFamily = new FontFamily("Aaargh");
                if(counter%2==0) project_name.Foreground = Brushes.Black;
                else project_name.Foreground = Brushes.White;
                project_name.Content = dataProjects[zz];
                //project_name.Name = "lb";
                project_canvas.Children.Add(project_name);

                Label creator = new Label();
                creator.Width = 300;
                creator.Height = 40;
                Thickness creator_margin = project_canvas.Margin;
                creator_margin.Left = 315;
                creator_margin.Top = 2;
                creator.Margin = creator_margin;
                creator.FontSize = 24;
                creator.FontFamily = new FontFamily("Aaargh");
                if (counter % 2 == 0) creator.Foreground = Brushes.Black;
                else creator.Foreground = Brushes.White;
                creator.Content = dataProjects[zz + 1];
                //project_name.Name = "lb";
                project_canvas.Children.Add(creator);

                Label membersCount = new Label();
                membersCount.Width = 40;
                membersCount.Height = 40;
                Thickness membersCount_margin = project_canvas.Margin;
                membersCount_margin.Left = 630;
                membersCount_margin.Top = 2;
                membersCount.Margin = membersCount_margin;
                membersCount.FontSize = 28;
                membersCount.FontFamily = new FontFamily("MOON");
                if (counter % 2 == 0) membersCount.Foreground = Brushes.Black;
                else membersCount.Foreground = Brushes.White;
                membersCount.Content = dataProjects[zz + 2];
                //project_name.Name = "lb";
                project_canvas.Children.Add(membersCount);

                Label deadline = new Label();
                deadline.Width = 240;
                deadline.Height = 40;
                Thickness deadline_margin = project_canvas.Margin;
                deadline_margin.Left = 695;
                deadline_margin.Top = 2;
                deadline.Margin = deadline_margin;
                deadline.FontSize = 24;
                deadline.FontFamily = new FontFamily("Aaargh");
                if (counter % 2 == 0) deadline.Foreground = Brushes.Black;
                else deadline.Foreground = Brushes.White;
                deadline.Content = dataProjects[zz + 3];
                //project_name.Name = "lb";
                project_canvas.Children.Add(deadline);

                Image edit_icon = new Image();
                edit_icon.Height = 40;
                edit_icon.Width = 40;
                //edit_icon.Name = "edi";
                Thickness edit_margin = project_canvas.Margin;
                edit_margin.Left = 960;
                edit_margin.Top = 2;
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
                //delete_icon.Name = "edi";
                Thickness delete_margin = project_canvas.Margin;
                delete_margin.Left = 1010;
                delete_margin.Top = 2;
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

                spacer += 44;
                counter++;
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
            var web_service = new TasksWS.Tasks();
            var result = web_service.LoadTodos(chsnProj);

            int spacerY = 5;
            int counter = 0;

            for(int i=0;i<result.Length;i+=3)
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
                todo_title.Width = 195; //230
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
                tb2.Text = result[i + 2];
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

                        var web_service2 = new TasksWS.Tasks();
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
                    var web_service2 = new TasksWS.Tasks();
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

                Image move_icon = new Image();
                move_icon.Height = 30;
                move_icon.Width = 30;
                move_icon.Name = "edi";
                Thickness move_margin = todo_canvas.Margin;
                move_margin.Left = 210;
                move_margin.Top = 5;
                move_icon.Margin = move_margin;
                BitmapImage move_image = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/todo/move_forward_task.png", UriKind.Relative));
                move_icon.Source = move_image;
                move_icon.MouseDown += (source, e) =>
                {
                    MoveTask("todo", "inprogress", todo_title.Text.ToString(), tb.Text.ToString(), tb2.Text.ToString());
                    LoadTodos(chosenProject);
                    LoadInProgress(chosenProject);
                };
                move_icon.MouseEnter += (source, e) =>
                {
                    move_icon.Opacity = 0.3;
                    Cursor = Cursors.Hand;
                };
                move_icon.MouseLeave += (source, e) =>
                {
                    move_icon.Opacity = 1;
                    Cursor = Cursors.Arrow;
                };
                todo_canvas.Children.Add(move_icon);

                spacerY += 160;
                if(i==6) todo_wrapper.Height += 35;
                else if(i>6) todo_wrapper.Height += 165;
                counter++;
            }
            todo_counter.Content = "Count: " + counter.ToString();
        }

        public void LoadInProgress(string chsnProj)
        {
            inprogress_wrapper.Height = 610;
            var coll = inprogress_wrapper.Children.OfType<Canvas>().ToList();
            foreach (Canvas cv in coll)
            {
                inprogress_wrapper.Children.Remove(cv);
            }
            var web_service = new TasksWS.Tasks();
            var result = web_service.LoadInProgress(chsnProj);

            int spacerY = 5;
            int counter = 0;

            for (int i = 0; i < result.Length; i += 3)
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
                todo_title.Width = 195;
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
                tb2.Text = result[i + 2];
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

                        var web_service2 = new TasksWS.Tasks();
                        var result2 = web_service.EditTodos(oldTitleTodo, todo_title.Text.ToString(), tb.Text.ToString(), chosenProject);
                        LoadInProgress(chosenProject);
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
                    var web_service2 = new TasksWS.Tasks();
                    var result2 = web_service.RemoveTodos(todo_title.Text.ToString(), chosenProject);
                    LoadInProgress(chosenProject);
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

                Image move_icon = new Image();
                move_icon.Height = 30;
                move_icon.Width = 30;
                move_icon.Name = "edi";
                Thickness move_margin = todo_canvas.Margin;
                move_margin.Left = 210;
                move_margin.Top = 5;
                move_icon.Margin = move_margin;
                BitmapImage move_image = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/todo/move_forward_task.png", UriKind.Relative));
                move_icon.Source = move_image;
                move_icon.MouseDown += (source, e) =>
                {
                    MoveTask("inprogress", "forreview", todo_title.Text.ToString(), tb.Text.ToString(), tb2.Text.ToString());
                    LoadInProgress(chosenProject);
                    LoadForReview(chosenProject);
                };
                move_icon.MouseEnter += (source, e) =>
                {
                    move_icon.Opacity = 0.3;
                    Cursor = Cursors.Hand;
                };
                move_icon.MouseLeave += (source, e) =>
                {
                    move_icon.Opacity = 1;
                    Cursor = Cursors.Arrow;
                };
                todo_canvas.Children.Add(move_icon);

                Image back_icon = new Image();
                back_icon.Height = 30;
                back_icon.Width = 30;
                back_icon.Name = "edi";
                Thickness back_margin = todo_canvas.Margin;
                back_margin.Left = 180;
                back_margin.Top = 5;
                back_icon.Margin = back_margin;
                BitmapImage back_image = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/todo/move_backward_task.png", UriKind.Relative));
                back_icon.Source = back_image;
                back_icon.MouseDown += (source, e) =>
                {
                    MoveTask("inprogress", "todo", todo_title.Text.ToString(), tb.Text.ToString(), tb2.Text.ToString());
                    LoadInProgress(chosenProject);
                    LoadTodos(chosenProject);
                };
                back_icon.MouseEnter += (source, e) =>
                {
                    back_icon.Opacity = 0.3;
                    Cursor = Cursors.Hand;
                };
                back_icon.MouseLeave += (source, e) =>
                {
                    back_icon.Opacity = 1;
                    Cursor = Cursors.Arrow;
                };
                todo_canvas.Children.Add(back_icon);

                spacerY += 160;
                if (i == 6) inprogress_wrapper.Height += 35;
                else if (i > 6) inprogress_wrapper.Height += 165;
                counter++;
            }
            inprogress_counter.Content = "Count: " + counter.ToString();
        }

        public void LoadForReview(string chsnProj)
        {
            forreview_wrapper.Height = 610;
            var coll = forreview_wrapper.Children.OfType<Canvas>().ToList();
            foreach (Canvas cv in coll)
            {
                forreview_wrapper.Children.Remove(cv);
            }
            var web_service = new TasksWS.Tasks();
            var result = web_service.LoadForReview(chsnProj);

            int spacerY = 5;
            int counter = 0;

            for (int i = 0; i < result.Length; i += 3)
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
                todo_title.Width = 195;
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
                tb2.Text = result[i + 2];
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

                        var web_service2 = new TasksWS.Tasks();
                        var result2 = web_service.EditTodos(oldTitleTodo, todo_title.Text.ToString(), tb.Text.ToString(), chosenProject);
                        LoadForReview(chosenProject);
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
                    var web_service2 = new TasksWS.Tasks();
                    var result2 = web_service.RemoveTodos(todo_title.Text.ToString(), chosenProject);
                    LoadForReview(chosenProject);
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

                Image move_icon = new Image();
                move_icon.Height = 30;
                move_icon.Width = 30;
                move_icon.Name = "edi";
                Thickness move_margin = todo_canvas.Margin;
                move_margin.Left = 210;
                move_margin.Top = 5;
                move_icon.Margin = move_margin;
                BitmapImage move_image = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/todo/move_forward_task.png", UriKind.Relative));
                move_icon.Source = move_image;
                move_icon.MouseDown += (source, e) =>
                {
                    MoveTask("forreview", "done", todo_title.Text.ToString(), tb.Text.ToString(), tb2.Text.ToString());
                    LoadForReview(chosenProject);
                    LoadDone(chosenProject);
                };
                move_icon.MouseEnter += (source, e) =>
                {
                    move_icon.Opacity = 0.3;
                    Cursor = Cursors.Hand;
                };
                move_icon.MouseLeave += (source, e) =>
                {
                    move_icon.Opacity = 1;
                    Cursor = Cursors.Arrow;
                };
                todo_canvas.Children.Add(move_icon);

                Image back_icon = new Image();
                back_icon.Height = 30;
                back_icon.Width = 30;
                back_icon.Name = "edi";
                Thickness back_margin = todo_canvas.Margin;
                back_margin.Left = 180;
                back_margin.Top = 5;
                back_icon.Margin = back_margin;
                BitmapImage back_image = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/todo/move_backward_task.png", UriKind.Relative));
                back_icon.Source = back_image;
                back_icon.MouseDown += (source, e) =>
                {
                    MoveTask("forreview", "inprogress", todo_title.Text.ToString(), tb.Text.ToString(), tb2.Text.ToString());
                    LoadForReview(chosenProject);
                    LoadInProgress(chosenProject);
                };
                back_icon.MouseEnter += (source, e) =>
                {
                    back_icon.Opacity = 0.3;
                    Cursor = Cursors.Hand;
                };
                back_icon.MouseLeave += (source, e) =>
                {
                    back_icon.Opacity = 1;
                    Cursor = Cursors.Arrow;
                };
                todo_canvas.Children.Add(back_icon);

                spacerY += 160;
                if (i == 6) forreview_wrapper.Height += 35;
                else if (i > 6) forreview_wrapper.Height += 165;
                counter++;
            }
            forreview_counter.Content = "Count: " + counter.ToString();
        }

        public void LoadDone(string chsnProj)
        {
            done_wrapper.Height = 610;
            var coll = done_wrapper.Children.OfType<Canvas>().ToList();
            foreach (Canvas cv in coll)
            {
                done_wrapper.Children.Remove(cv);
            }
            var web_service = new TasksWS.Tasks();
            var result = web_service.LoadDone(chsnProj);

            int spacerY = 5;
            int counter = 0;

            for (int i = 0; i < result.Length; i += 3)
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
                tb2.Text = result[i + 2];
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

                        var web_service2 = new TasksWS.Tasks();
                        var result2 = web_service.EditTodos(oldTitleTodo, todo_title.Text.ToString(), tb.Text.ToString(), chosenProject);
                        LoadDone(chosenProject);
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
                    var web_service2 = new TasksWS.Tasks();
                    var result2 = web_service.RemoveTodos(todo_title.Text.ToString(), chosenProject);
                    LoadDone(chosenProject);
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

                Image back_icon = new Image();
                back_icon.Height = 30;
                back_icon.Width = 30;
                back_icon.Name = "edi";
                Thickness back_margin = todo_canvas.Margin;
                back_margin.Left = 180;
                back_margin.Top = 5;
                back_icon.Margin = back_margin;
                BitmapImage back_image = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/todo/move_backward_task.png", UriKind.Relative));
                back_icon.Source = back_image;
                back_icon.MouseDown += (source, e) =>
                {
                    MoveTask("done", "forreview", todo_title.Text.ToString(), tb.Text.ToString(), tb2.Text.ToString());
                    LoadDone(chosenProject);
                    LoadForReview(chosenProject);
                };
                back_icon.MouseEnter += (source, e) =>
                {
                    back_icon.Opacity = 0.3;
                    Cursor = Cursors.Hand;
                };
                back_icon.MouseLeave += (source, e) =>
                {
                    back_icon.Opacity = 1;
                    Cursor = Cursors.Arrow;
                };
                todo_canvas.Children.Add(back_icon);

                spacerY += 160;
                if (i == 6) done_wrapper.Height += 35;
                else if (i > 6) done_wrapper.Height += 165;
                counter++;
            }
            done_counter.Content = "Count: " + counter.ToString();
        }

        public void MoveTask(string from, string to, string taskTitle, string taskDesc, string taskCategory)
        {
            var web_service = new TasksWS.Tasks();
            var result = web_service.MoveTask(from, to, taskTitle, taskDesc, taskCategory, chosenProject);
        }






        public void LoadProjectMembers(string chsnProj)
        {
            var web_service = new MainWS.Main();
            var result = web_service.LoadProjectMembers(chsnProj);

            int spacerY1 = 5;
            int spacerY2 = 10;

            //communication members
            foreach(string member in result)
            {
                string[] mem = member.Split(',');
                Canvas cv = new Canvas();
                cv.Width = 483;
                cv.Height = 60;
                Thickness member_margin = comm_members_wrapper.Margin;
                member_margin.Left = 0;
                member_margin.Top = spacerY1;
                cv.Margin = member_margin;
                comm_members_wrapper.Children.Add(cv);

                Label lb2 = new Label();
                Thickness lb2_margin = cv.Margin;
                lb2_margin.Left = 70;
                lb2_margin.Top = 10;
                lb2.Margin = lb2_margin;
                lb2.Content = mem[0];
                lb2.Foreground = Brushes.White;
                cv.Children.Add(lb2);

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
                rect.MouseLeftButtonDown += (source, e) =>
                {
                    LoadMessages(currentUserID, lb2.Content.ToString(), chosenProject);
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
                //lb.Name = mem[0];
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
                lb.Content = mem[1];
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

            //project members
            foreach (string member in result)
            {
                string[] mem = member.Split(',');
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
                lb.Content = mem[1];
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
            var web_service = new MainWS.Main();
            var result = web_service.LoadMessages(firstUserID, secondUserID, chsnProj);

            chat_wrapper.Children.Clear();

            int spacerY = 10;

            for (int i = 0; i < result.Length; i++)
            {
                Canvas cv = new Canvas();
                cv.Width = 375;
                cv.Height = 60;
                Thickness cv_thickness = chat_wrapper.Margin;
                cv_thickness.Left = 10;
                cv_thickness.Top = spacerY;
                cv.Margin = cv_thickness;
                chat_wrapper.Children.Add(cv);

                Rectangle rect = new Rectangle();
                rect.Width = 375;
                rect.Height = 35;
                rect.RadiusX = 5;
                rect.RadiusY = 5;
                rect.Fill = new SolidColorBrush(Color.FromArgb(255, 52, 152, 219));
                cv.Children.Add(rect);
            }
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
                string category = add_todo_category.Text.ToString();

                if (title!="" && desc!="" && category!="")
                {
                    var web_service = new TasksWS.Tasks();
                    var result = web_service.AddTodos(title, desc, category, chosenProject);
                    LoadTodos(chosenProject);
                }

                canvas_main.Effect = null;
                add_todo_title.Text = "";
                add_todo_desc.Text = "";
                add_todo_category.Text = "";
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
                var web_service = new MainWS.Main();
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
                    string[] mem = member.Split(',');
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
                    lb.Content = mem[1];
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
                        var web_service = new MainWS.Main();
                        var result = web_service.SendMessage(message_textBox.Text.ToString(), currentUserID, actual_comm_member_id.Content.ToString(), DateTime.Now.ToString(), chosenProject);
                        //LoadMessages(chosenProject);
                        message_textBox.Text = "";
                    }
                    catch (Exception ex) { }
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            LoadMessages(currentUserID, "2", chosenProject);
        }

        private void create_project_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var blur = new BlurEffect();
            blur.Radius = 9;
            canvas_main.Effect = blur;
            canvas_add_project.Visibility = Visibility.Visible;
        }

        private void add_project_cancel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            canvas_main.Effect = null;
            add_todo_title.Text = "";
            add_todo_desc.Text = "";
            canvas_add_project.Visibility = Visibility.Hidden;
        }

        private void add_project_confirm_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
