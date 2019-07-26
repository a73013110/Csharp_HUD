namespace Csharp_HUD
{
    /// <summary>
    /// Like a MVC Model, store Message which can be get and set
    /// </summary>
    public class Message : NotifyPropertyChangedEx
    {
        // 大標題(GUI上方訊息)
        private string msgTitle;
        public string MsgTitle
        {
            get { return msgTitle; }
            set { this.SetProperty(ref msgTitle, value); }
        }
        // 詳細內容(GUI下方訊息)
        private string msgDetail;
        public string MsgDetail
        {
            get { return msgDetail; }
            set { this.SetProperty(ref msgDetail, value); }
        }
        // 通知顯示持續時間
        private int msgDuration;
        public int MsgDuration
        {
            get { return msgDuration; }
            set { this.SetDurationProperty(ref msgDuration, value); }
        }
    }
}
