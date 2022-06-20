using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gaten.Study.TestWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
            //EventTrigger check = new EventTrigger(ToggleButton.CheckedEvent);
            //TriggerAction action = new TriggerAction();
            //check.Actions.Add(Act());
            //EventTrigger uncheck = new EventTrigger(ToggleButton.UncheckedEvent);

            //Style style = new Style();
            //style.Triggers.Add(check);
            //style.Triggers.Add(uncheck);

            //var a = box;
            //box.Resources.Add(typeof(GroupBox), style);
        }
    }
}
