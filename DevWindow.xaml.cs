using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace MiniMotorways_Mod_Manager
{
    /// <summary>
    /// Interaction logic for DevWindow.xaml
    /// </summary>
    public partial class DevWindow : Window
    {

        public ObservableCollection<LogEntry> LogEntries;

        public DevWindow()
        {
            InitializeComponent();

            LogEntries = new ObservableCollection<LogEntry>();

            // tie View with ViewModel
            LogEntryList.ItemsSource = LogEntries;

            // add test data
            LogEntries.Add(new LogEntry
            {
                Modification = "Test Mod",
                Message = "Hello, Test Message!"
            });
        }

        private void LogEntryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        public class LogEntry
        {
            public string Modification { get; set; }
            public string Message { get; set; }
        }
    }
}
