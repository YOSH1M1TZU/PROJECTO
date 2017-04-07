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

        string oldTitleTodo = null;
        string oldDescTodo = null;

        public MainWindow(string userID)
        {
            InitializeComponent();
            Cursor = Cursors.Arrow;
            LoadProjects(userID);
            LoadTodos(chosenProject);

            canvas_dashboard.Visibility = Visibility.Visible;
            canvas_projects.Visibility = Visibility.Hidden;
            canvas_todo.Visibility = Visibility.Hidden;
            canvas_in_progress.Visibility = Visibility.Hidden;
            canvas_finished.Visibility = Visibility.Hidden;
            canvas_bugs.Visibility = Visibility.Hidden;
            canvas_storage.Visibility = Visibility.Hidden;
            canvas_chat.Visibility = Visibility.Hidden;
            canvas_finances.Visibility = Visibility.Hidden;
            canvas_charts.Visibility = Visibility.Hidden;
            canvas_teams.Visibility = Visibility.Hidden;
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
                case "inprogress_label":
                    {
                        inprogress_icon.Opacity = 1;
                    }
                    break;
                case "finished_label":
                    {
                        finished_icon.Opacity = 1;
                    }
                    break;
                case "bugs_label":
                    {
                        bugs_icon.Opacity = 1;
                    }
                    break;
                case "storage_label":
                    {
                        storage_icon.Opacity = 1;
                    }
                    break;
                case "chat_label":
                    {
                        chat_icon.Opacity = 1;
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
                case "teams_label":
                    {
                        teams_icon.Opacity = 1;
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
                case "inprogress_label":
                    {
                        inprogress_icon.Opacity = 0.6;
                    }
                    break;
                case "finished_label":
                    {
                        finished_icon.Opacity = 0.6;
                    }
                    break;
                case "bugs_label":
                    {
                        bugs_icon.Opacity = 0.6;
                    }
                    break;
                case "storage_label":
                    {
                        storage_icon.Opacity = 0.6;
                    }
                    break;
                case "chat_label":
                    {
                        chat_icon.Opacity = 0.6;
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
                case "teams_label":
                    {
                        teams_icon.Opacity = 0.6;
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
                        canvas_todo.Visibility = Visibility.Hidden;
                        canvas_in_progress.Visibility = Visibility.Hidden;
                        canvas_finished.Visibility = Visibility.Hidden;
                        canvas_bugs.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_chat.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_teams.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "projects_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Visible;
                        canvas_todo.Visibility = Visibility.Hidden;
                        canvas_in_progress.Visibility = Visibility.Hidden;
                        canvas_finished.Visibility = Visibility.Hidden;
                        canvas_bugs.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_chat.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_teams.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "todo_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_todo.Visibility = Visibility.Visible;
                        canvas_in_progress.Visibility = Visibility.Hidden;
                        canvas_finished.Visibility = Visibility.Hidden;
                        canvas_bugs.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_chat.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_teams.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "inprogress_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_todo.Visibility = Visibility.Hidden;
                        canvas_in_progress.Visibility = Visibility.Visible;
                        canvas_finished.Visibility = Visibility.Hidden;
                        canvas_bugs.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_chat.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_teams.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "finished_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_todo.Visibility = Visibility.Hidden;
                        canvas_in_progress.Visibility = Visibility.Hidden;
                        canvas_finished.Visibility = Visibility.Visible;
                        canvas_bugs.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_chat.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_teams.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "bugs_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_todo.Visibility = Visibility.Hidden;
                        canvas_in_progress.Visibility = Visibility.Hidden;
                        canvas_finished.Visibility = Visibility.Hidden;
                        canvas_bugs.Visibility = Visibility.Visible;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_chat.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_teams.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "storage_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_todo.Visibility = Visibility.Hidden;
                        canvas_in_progress.Visibility = Visibility.Hidden;
                        canvas_finished.Visibility = Visibility.Hidden;
                        canvas_bugs.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Visible;
                        canvas_chat.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_teams.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "chat_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_todo.Visibility = Visibility.Hidden;
                        canvas_in_progress.Visibility = Visibility.Hidden;
                        canvas_finished.Visibility = Visibility.Hidden;
                        canvas_bugs.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_chat.Visibility = Visibility.Visible;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_teams.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "finances_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_todo.Visibility = Visibility.Hidden;
                        canvas_in_progress.Visibility = Visibility.Hidden;
                        canvas_finished.Visibility = Visibility.Hidden;
                        canvas_bugs.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_chat.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Visible;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_teams.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "charts_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_todo.Visibility = Visibility.Hidden;
                        canvas_in_progress.Visibility = Visibility.Hidden;
                        canvas_finished.Visibility = Visibility.Hidden;
                        canvas_bugs.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_chat.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Visible;
                        canvas_teams.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "teams_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_todo.Visibility = Visibility.Hidden;
                        canvas_in_progress.Visibility = Visibility.Hidden;
                        canvas_finished.Visibility = Visibility.Hidden;
                        canvas_bugs.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_chat.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_teams.Visibility = Visibility.Visible;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "achievs_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_todo.Visibility = Visibility.Hidden;
                        canvas_in_progress.Visibility = Visibility.Hidden;
                        canvas_finished.Visibility = Visibility.Hidden;
                        canvas_bugs.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_chat.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_teams.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Visible;
                        canvas_settings.Visibility = Visibility.Hidden;
                    }
                    break;
                case "settings_label":
                    {
                        canvas_dashboard.Visibility = Visibility.Hidden;
                        canvas_projects.Visibility = Visibility.Hidden;
                        canvas_todo.Visibility = Visibility.Hidden;
                        canvas_in_progress.Visibility = Visibility.Hidden;
                        canvas_finished.Visibility = Visibility.Hidden;
                        canvas_bugs.Visibility = Visibility.Hidden;
                        canvas_storage.Visibility = Visibility.Hidden;
                        canvas_chat.Visibility = Visibility.Hidden;
                        canvas_finances.Visibility = Visibility.Hidden;
                        canvas_charts.Visibility = Visibility.Hidden;
                        canvas_teams.Visibility = Visibility.Hidden;
                        canvas_achievs.Visibility = Visibility.Hidden;
                        canvas_settings.Visibility = Visibility.Visible;
                    }
                    break;
            }
        }
        #endregion



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



        public void LoadTodos(string chsnProj)
        {
            var coll = canvas_todo.Children.OfType<Canvas>().ToList();
            foreach(Canvas cv in coll)
            {
                canvas_todo.Children.Remove(cv);
            }
            var web_service = new localhost.Main();
            var result = web_service.LoadTodos(chsnProj);

            int spacerY = 55;
            int spacerX = 20;

            for(int i=0;i<result.Length;i+=2)
            {
                Canvas todo_canvas = new Canvas();
                todo_canvas.Width = 300;
                todo_canvas.Height = 180;
                todo_canvas.Name = "cnvs";
                Thickness project_margin = todo_canvas.Margin;
                project_margin.Left = spacerX;
                project_margin.Top = spacerY;
                todo_canvas.Margin = project_margin;
                canvas_todo.Children.Add(todo_canvas);

                Rectangle rect = new Rectangle();
                rect.Width = 300;
                rect.Height = 180;
                //rect.Name = "rect";
                rect.RadiusX = 5;
                rect.RadiusY = 5;
                rect.Fill = new SolidColorBrush(Color.FromArgb(255, 243, 243, 244));
                todo_canvas.Children.Add(rect);

                TextBox todo_title = new TextBox();
                todo_title.Width = 280;
                todo_title.Height = 31;
                Thickness todo_title_margin = todo_canvas.Margin;
                todo_title_margin.Left = 10;
                todo_title_margin.Top = 10;
                todo_title.Margin = todo_title_margin;
                todo_title.FontSize = 14;
                todo_title.BorderThickness = new Thickness(0, 0, 0, 2);
                todo_title.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 243, 243, 244));
                todo_title.AllowDrop = false;
                todo_title.Focusable = false;
                todo_title.Background = new SolidColorBrush(Color.FromArgb(255, 243, 243, 244));
                todo_title.FontFamily = new FontFamily("Aaargh");
                todo_title.Foreground = Brushes.Black;
                todo_title.Text = result[i];
                //todo_title.Name = "lb";
                todo_title.MaxLength = 30;
                todo_title.Cursor = Cursors.Arrow;
                todo_canvas.Children.Add(todo_title);

                TextBox tb = new TextBox();
                tb.Width = 280;
                tb.Height = 100;
                Thickness tb_margin = todo_canvas.Margin;
                tb_margin.Left = 10;
                tb_margin.Top = 43;
                tb.Margin = tb_margin;
                tb.FontSize = 14;
                tb.BorderThickness = new Thickness(0, 0, 0, 2);
                tb.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 243, 243, 244));
                tb.AllowDrop = false;
                tb.Focusable = false;
                tb.Background = new SolidColorBrush(Color.FromArgb(255, 243, 243, 244));
                tb.Text = result[i + 1];
                tb.Cursor = Cursors.Arrow;
                tb.TextWrapping = TextWrapping.Wrap;
                tb.MaxLength = 210;
                todo_canvas.Children.Add(tb);

                Image query_icon = new Image();
                query_icon.Height = 30;
                query_icon.Width = 30;
                query_icon.Name = "edi";
                Thickness query_margin = todo_canvas.Margin;
                query_margin.Left = 180;
                query_margin.Top = 145;
                query_icon.Margin = query_margin;
                BitmapImage query_image = new BitmapImage(new Uri("/Projecto.PC;component/Resources/UI/todo/progress_task.png", UriKind.Relative));
                query_icon.Source = query_image;
                query_icon.MouseDown += (source, e) =>
                {

                };
                query_icon.MouseEnter += (source, e) =>
                {
                    query_icon.Opacity = 0.3;
                    Cursor = Cursors.Hand;
                };
                query_icon.MouseLeave += (source, e) =>
                {
                    query_icon.Opacity = 1;
                    Cursor = Cursors.Arrow;
                };
                todo_canvas.Children.Add(query_icon);

                Image edit_icon = new Image();
                edit_icon.Height = 30;
                edit_icon.Width = 30;
                edit_icon.Name = "edi";
                Thickness edit_margin = todo_canvas.Margin;
                edit_margin.Left = 220;
                edit_margin.Top = 145;
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
                delete_margin.Left = 260;
                delete_margin.Top = 145;
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

                if(i==4)
                {
                    spacerX += 320;
                    spacerY = 55;
                }
                else if(i==10)
                {
                    spacerX += 320;
                    spacerY = 55;
                }
                else spacerY += 200;

            }
        }

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
    }
}
