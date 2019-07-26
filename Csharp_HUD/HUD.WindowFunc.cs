using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Csharp_HUD
{
    public partial class HUD
    {
        /// <summary>
        /// Get the show up location of notifacation window
        /// </summary>
        /// <param name="window_height">Height of monitor</param>
        /// <param name="window_width">Width of monitor</</param>
        /// <returns></returns>
        public static (double, double) GetWindowStartupLocation(double window_height, double window_width)
        {
            double top = System.Windows.SystemParameters.WorkArea.Height * 0.9 - window_height;
            double left = (System.Windows.SystemParameters.WorkArea.Width - window_width) / 2;
            return (top, left);
        }
    }
}
