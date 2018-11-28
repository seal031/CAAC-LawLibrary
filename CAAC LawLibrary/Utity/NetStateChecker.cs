using CAAC_LawLibrary.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAAC_LawLibrary.Utity
{
    public class NetStateChecker
    {
        private static System.Threading.Timer timer = new System.Threading.Timer(checkNetState, null, 0, 30 * 1000);

        private static void checkNetState(object state)
        {
            bool oldState = Global.online;
            RemoteWorker.checkInternet();
            bool newState = Global.online;
            if (oldState != newState)
            {
                if (newState)
                {
                    MessageBox.Show("检测到网络已连接，切换至联网状态","网络状态发生变化");
                }
                else
                {
                    MessageBox.Show("检测到网络已断开，切换至离线状态","网络状态发生变化");
                }
            }
        }
        
    }
}
