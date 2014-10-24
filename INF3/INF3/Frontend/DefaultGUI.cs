using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace INF3.Frontend
{
    public class DefaultGUI
    {
        Backend b = new Backend();

        public DefaultGUI(Backend b)
        {
            
        }

        // 
        public void updateGUI()
        {
            b.getMap();
            
        }

        public void sendTextMessage()
        {

        }

    }
}
