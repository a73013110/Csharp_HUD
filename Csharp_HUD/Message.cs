using System;

namespace Csharp_HUD
{
    /// <summary>
    /// Like a MVC Model, store Message which can be get and set
    /// </summary>
    public class Message : NotifyPropertyChangedEx
    {
        // Message title(Upper in GUI)
        private string msgTitle;
        public string MsgTitle
        {
            get { return msgTitle; }
            set { this.SetProperty(ref msgTitle, value); }
        }
        // Message detail (Below in GUI)
        private string msgDetail;
        public string MsgDetail
        {
            get { return msgDetail; }
            set { this.SetProperty(ref msgDetail, value); }
        }
        // Message show up duration
        private int msgDuration;
        public int MsgDuration
        {
            get { return msgDuration; }
            set { this.SetDurationProperty(ref msgDuration, value); }
        }
        // The tag whether the progressbar animation is completed
        private bool isMsgDurationCompleted;
        public bool IsMsgDurationCompleted
        {
            get { return isMsgDurationCompleted; }
            set { this.SetDurationCompletedProperty(ref isMsgDurationCompleted, value); }
        }
    }
}
