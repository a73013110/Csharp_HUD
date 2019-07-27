using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Csharp_HUD
{
    // 實作此方法, 使Model內容改變時可反映到UI上
    public class NotifyPropertyChangedEx : INotifyPropertyChanged
    {
        /// <summary>
        /// The event handler update the UI text
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Set value and raise PropertyChangedEvent
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">The variable which want to set. Call by reference to set the value</param>
        /// <param name="value">New value</param>
        /// <param name="propertyName">直接使用CallerMemberName來取得呼叫此funciton的物件, 以便於後續不須將物件名稱寫死 (.Net 4.5)</param>
        protected void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return;   // 若Field的值與Value相同, 則不動作
            field = value;
            var handler = this.PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// The event handler update the behavior of Duration
        /// </summary>
        public event EventHandler MsgDurationChanged;
        protected void SetDurationProperty(ref int field, int value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            var handler = this.MsgDurationChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// The event handler update the value and do something when Message is completed
        /// </summary>
        public event EventHandler MsgDurationCompleted;
        protected void SetDurationCompletedProperty(ref bool field, bool value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            if (field)  // If Duration is completed
            {
                var handler = this.MsgDurationCompleted;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
