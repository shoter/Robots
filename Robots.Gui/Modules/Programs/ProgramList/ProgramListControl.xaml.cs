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

namespace Robots.Gui.Modules.Programs.ProgramList
{
    /// <summary>
    /// Interaction logic for ProgramList.xaml
    /// </summary>
    public partial class ProgramListControl : UserControl
    {

        public ProgramListControl()
        {
            InitializeComponent();
        }

        private void onProgramSelected(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListViewItem).DataContext as ProgramListItemViewModel;

            if (ProgramListItemViewModel.SelectProgram.CanExecute(item))
                ProgramListItemViewModel.SelectProgram.Execute(item);
        }

    }
}
