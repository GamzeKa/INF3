using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace INF3.Frontend
{
   public class GUImanager
    {

       public static DefaultGUI gui;

        public static bool isGUIaktiv()
        {
            return gui != null;
        }

        public static String getCommand()
        {
            return "";
        }

        public static bool isCommand()
        {
            Contract.Requires(isCommand());
            return true;
        }

        public static String getChat()
        {
            return "";
        }

        public static bool isChat()
        {
            return true;
        }

       [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(gui != null);
        }
       
    }
}
