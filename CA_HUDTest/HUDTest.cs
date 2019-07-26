using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Csharp_HUD;

namespace CA_HUDTest
{
    class HUDTest
    {
        // ---------------------------------- Method 1----------------------------------
        //[STAThread] // 一定要加這行, 不然會顯示UI無法被該執行續呼叫
        //static void Main(string[] args)
        //{
        //    Application app = new Application();
        //    app.Run(new HUD());
        //}

        // ---------------------------------- Method 2----------------------------------
        static Application app;
        static void Main(string[] args)
        {
            var appthread = new Thread(new ThreadStart(() =>
            {
                app = new Application();
                app.ShutdownMode = ShutdownMode.OnExplicitShutdown;
                app.Run();
            }));
            appthread.SetApartmentState(ApartmentState.STA);
            appthread.Start();
            // 暫停程序, 當(app != null)繼續執行(怕別的執行序還沒new Application), 若逾時則強制繼續執行(後面可能引發錯誤)
            SpinWait.SpinUntil(() => (app != null), 1000);
            app.Dispatcher.Invoke(() => new HUD().Show());
        }
    }
}
