using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using Csharp_HUD;

namespace WPF_HUDTest
{
    /// <summary>
    /// HUDTestWindow.xaml 的互動邏輯
    /// </summary>
    public partial class HUDTestWindow : Window
    {
        public HUDTestWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Variable for HUD window
        /// </summary>
        private HUD hud = null;

        /// <summary>
        /// Click event to open the HUD which was dll file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_openHUD_Click(object sender, RoutedEventArgs e)
        {
            // if there is no HUD window, new one
            if (hud == null || !hud.IsVisible)
            {
                hud = new HUD();
                hud.Owner = this;
                _ = AccordingTimeToChangeValue(hud);
                hud.Show();
                hud.StartDuration();
            }
            else
            {
                Console.WriteLine("HUD already exist");
            }
            _ = AbortApp(this, hud);
        }

        /// <summary>
        /// Change title and message according time
        /// </summary>
        private async Task AccordingTimeToChangeValue(HUD hud)
        {
            int durationTime = 3;
            string[] msgTitle = { "螢幕即將關閉", "螢幕即將關閉", "螢幕即將關閉" };
            string[] msgDetail = { "剩餘3秒", "剩餘2秒", "剩餘1秒" };
            hud.Message.MsgDuration = 3;
            for (int i = 0; i < durationTime; i++)
            {
                hud.SetMsg(msgTitle[i], msgDetail[i]);
                await Task.Delay(1000);
            }
        }

        /// <summary>
        /// If progress bar complete, than abort the main window
        /// </summary>
        private async Task AbortApp(Window window, HUD hud)
        {            
            while (!hud.Message.IsMsgDurationCompleted)
            {
                await Task.Delay(1000);
            }
            window.Close();
        }
    }
}
