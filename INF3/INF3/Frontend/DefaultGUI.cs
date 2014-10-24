using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INF3.Backend;
using System.Diagnostics.Contracts;

namespace INF3.Frontend
{
    public class DefaultGUI
    {
        Backend.Backend b;

        public DefaultGUI(Backend.Backend b)
        {
            Contract.Requires(b != null);
            
        }

        // 
        public void updateGUI()
        {
            b.getMap();
            
        }

        public void sendTextMessage()
        {
            String s="";
            Contract.Requires(s != null);

        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(b != null);
 
        }

    }
}
