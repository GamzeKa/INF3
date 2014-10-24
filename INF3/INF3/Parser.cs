using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF3
{
    public class Parser
    {
        Buffer b;
        public String takeFromBuffer()
        {
            //take the informations from the buffer and pass it
            return b.giveParser();
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

        public void parsToDragone(String dataBuffer)
        {
            
        }

        public void parsToPlayer(String dataBuffer)
        {
            
        }
        
        public void parsToPlayers(String dataBuffer)
        {
          
        }

        public void parsToEntitys(String dataBuffer)
        {
           
        }

        public void parsToMapcell(String dataBuffer)
        {
          
        }

        public void parsToMap(String dataBuffer)
        {
         
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
            // selects the appropriate method from server tags
        }
    }
}
