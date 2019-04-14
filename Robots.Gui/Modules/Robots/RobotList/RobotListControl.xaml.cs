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

namespace Robots.Gui.Modules.Robots.RobotList
{
    /// <summary>
    /// Interaction logic for RobotListControl.xaml
    /// </summary>
    public partial class RobotListControl : UserControl
    {
        public RobotListControl()
        {
            InitializeComponent();
        }

        private void onRobotSelect(object sender, MouseButtonEventArgs e)
        {
            var item = sender as RobotListItemViewModel;

            item.SelectRobot();
        }
    }
}
