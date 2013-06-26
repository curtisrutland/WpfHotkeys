using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Com.CurtisRutland.WpfHotkeys.Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Hotkey myHotkey, myHotkey2;

        public MainWindow()
        {
            InitializeComponent();
        }

        //create hotkey in the Loaded event so that the window has a handle
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            myHotkey = new Hotkey(Modifiers.Ctrl | Modifiers.Shift, Keys.A, this, registerImmediately: true);
            myHotkey2 = new Hotkey(Modifiers.Alt | Modifiers.Shift, Keys.B, this, registerImmediately: true);
            //register for the hotkey's event
            myHotkey.HotkeyPressed += HotkeyPressed;
            myHotkey2.HotkeyPressed += HotkeyPressed;
        }

        private void HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            ConsoleTextBox.Text += string.Format("Hotkey Pressed | {0} | Key: {1} | Modifiers: {2}{3}", 
                DateTime.Now, e.HotkeyInfo.Key, e.HotkeyInfo.Modifier, Environment.NewLine);
        }

        //Dispose of when closing
        private void WindowClosing(object sender, CancelEventArgs e)
        {
            myHotkey.Dispose();
        }
    }
}
