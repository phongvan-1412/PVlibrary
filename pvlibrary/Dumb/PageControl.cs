using System;
using System.Windows;
using System.Windows.Controls;

namespace pvlibrary
{
    internal class PageControl
    {
        public static Uri pvLibraryApp = new Uri(@"C:\Aptech\.Net-work\pvlibrary");

        private static MainWindow mainWindow;
        private static readonly Lazy<PageControl> lazy = new Lazy<PageControl>(() => new PageControl());

        private static MainWindow _mainWindow;
        private static Page _page;
        private static Grid _grid;
        public void SetMainWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }
        public void Login(Page Login)
        {
            _page = Login;
            _mainWindow.Content = Login;
        }
        
        public void Logout()
        {
            _mainWindow.Close();
        }
        public void HomeMenu(Page HomeMenu)
        {
            _page = HomeMenu;
            _mainWindow.Content = HomeMenu;
        }
        public void MainView(UserControl Content, Grid grid)
        {
            _grid = grid;
            grid.Children.Clear();
            grid.Children.Add(Content);
        }
        public void SubView(UserControl subView, Grid grid)
        {
            _grid = grid;
            grid.Children.Clear();
            grid.Children.Add(subView);
        }
        
        public static MainWindow MainWindow { get => mainWindow; set => mainWindow = value; }
        public static PageControl Instance { get { return lazy.Value; } }

    }
}
