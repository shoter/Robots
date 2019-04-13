using Robots.Gui.Modules.Programs.ProgramList;
using Robots.Gui.Modules.Programs.ProgramsSection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Robots.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ProgramSectionViewModel vm)
        {
            InitializeComponent();

            this.DataContext = vm;
        }

        private void RibbonApplicationMenu_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = (RibbonApplicationMenu.Template.FindName("MainPaneBorder", RibbonApplicationMenu) as Border).Parent as Grid;
            grid.ColumnDefinitions[2].Width = new GridLength(0);
        }

        private void ProgramListView_ProgramSelected(object sender, ProgramListItemEventArgs e)
        {

        }

        private void Ribbon_Loaded(object sender, RoutedEventArgs e)
        {
            Grid child = VisualTreeHelper.GetChild((DependencyObject)sender, 0) as Grid;
            if (child != null)
            {
                child.RowDefinitions[0].Height = new GridLength(0);
            }
        }
    }
}
