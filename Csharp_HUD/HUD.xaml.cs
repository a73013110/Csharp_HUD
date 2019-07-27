using System;
using System.Windows;

namespace Csharp_HUD
{
    /// <summary>
    /// HUD.xaml 的互動邏輯
    /// </summary>
    public partial class HUD : Window
    {
        public HUD()
        {
            InitializeComponent();
            // 設置視窗參數
            (this.Top, this.Left) = GetWindowStartupLocation(this.Height, this.Width);
            // 設定EventHandler
            //this.Message.MsgDurationChanged += MsgDurationChangedEventHandler;
            this.Message.MsgDurationCompleted += MsgDurationCompletedEventHandler;
        }

        //public void MsgDurationChangedEventHandler(object sender, EventArgs e)
        //{
        //    // Do something when you change the msgDuration
        //}

        public void MsgDurationCompletedEventHandler(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
