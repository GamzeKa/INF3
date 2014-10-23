using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF3
{
    public class Parser
    {
        public String takeFromBuffer()
        {
            return"";
        }
//Pars Rules-------------------------------------
        public void parsToS(String dataBuffer)
        {
    
        }

        public void parsToServermes(String dataBuffer)
        {
            
        }

        public void parsToResult(String dataBuffer)
        {
           
        }

        public void parsToOpponent(String dataBuffer)
        {
            
        }

        public void parsToChallenge(String dataBuffer)
        {
          
        }

        public INF3.Backend.Dragon parsToDragone(String dataBuffer)
        {
            INF3.Backend.Dragon d = new INF3.Backend.Dragon();
            return d;
        }

        public INF3.Backend.Player parsToPlayer(String dataBuffer)
        {
            INF3.Backend.Player d = new INF3.Backend.Player();
            return d;
        }
        
        public void parsToPlayers(String dataBuffer)
        {
          
        }

        public INF3.Backend.Entity parsToEntitys(String dataBuffer)
        {
            INF3.Backend.Entity d = new INF3.Backend.Entity();
            return d;
        }

        public void parsToMapcell(String dataBuffer)
        {
          
        }

        public INF3.Backend.Map parsToMap(String dataBuffer)
        {
            INF3.Backend.Map d = new INF3.Backend.Map();
            return d;
        }

        public void parsToMessage(String dataBuffer)
        {
           
        }

        public void parsToUpdate(String dataBuffer)
        {
       
        }

        public void parsToDelete(String dataBuffer)
        {

        }

        public void parsToAnswer(String dataBuffer)
        {

        }
//---------------------------------------------------------
        public void determineMethod(String dataBuffer)
        {

        }
    }
}
