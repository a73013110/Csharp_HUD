using System;
using System.Windows;

namespace Csharp_HUD
{
    /// <summary>
    /// This file delegate the comminucation between MainWindow and its DataContext(Message Model)
    /// </summary>
    public partial class HUD
    {
        #region Communication with DataContext(Message Model)
        public Message Message
        {
            get { return ((Message)this.DataContext); }
        }

        public void SetMsg(string msgTitle, string msgDetail)
        {
            this.Message.MsgTitle = msgTitle;
            this.Message.MsgDetail = msgDetail;
        }

        public void SetMsg(string msgTitle, string msgDetail, int msgDuration = 3)
        {
            this.Message.MsgTitle = msgTitle;
            this.Message.MsgDetail = msgDetail;
            this.Message.MsgDuration = msgDuration;
        }
        #endregion

        public void StartDuration()
        {
            this.Message.MsgDuration = (this.Message.MsgDuration == 0) ? 3 : this.Message.MsgDuration;    // if Duration = 0, set it as default (3 seconds)
            this.Message.IsMsgDurationCompleted = false;    // Updata the tag whether duration is completed
            // There are 5 line which compose progressbar. Calaulate each line animation time (Actually corners don't perform animation)
            DURATION = new Duration(new TimeSpan(0, 0, 0, 0, this.Message.MsgDuration * 1000 / line.Length));
            DrawProgressBar();  // Create progressbar
            line[0].BeginStoryboard(SetDurationAnimation(0, 0));    // Start progressbar animation
        }
    }
}
