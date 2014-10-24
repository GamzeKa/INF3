using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

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
        private void parsToS(String dataBuffer)
        {
            Contract.Requires(dataBuffer != null);
        }

        private void parsToServermes(String dataBuffer)
        {
            Contract.Requires(dataBuffer != null);
        }

        private void parsToResult(String dataBuffer)
        {
            Contract.Requires(dataBuffer != null);
        }

        private void parsToOpponent(String dataBuffer)
        {
            Contract.Requires(dataBuffer != null);
        }

        private void parsToChallenge(String dataBuffer)
        {
            Contract.Requires(dataBuffer != null);
        }

        private void parsToDragone(String dataBuffer)
        {
            Contract.Requires(dataBuffer != null);
        }

        private void parsToPlayer(String dataBuffer)
        {
            Contract.Requires(dataBuffer != null);
        }

        private void parsToPlayers(String dataBuffer)
        {
            Contract.Requires(dataBuffer != null);
        }

        private void parsToEntitys(String dataBuffer)
        {
            Contract.Requires(dataBuffer != null);
        }

        private void parsToMapcell(String dataBuffer)
        {
            Contract.Requires(dataBuffer != null);
        }

        private void parsToMap(String dataBuffer)
        {
            Contract.Requires(dataBuffer != null);
        }

        private void parsToMessage(String dataBuffer)
        {
            Contract.Requires(dataBuffer != null);
        }

        private void parsToUpdate(String dataBuffer)
        {
            Contract.Requires(dataBuffer != null);
        }

        private void parsToDelete(String dataBuffer)
        {
            Contract.Requires(dataBuffer != null);
        }

        private void parsToAnswer(String dataBuffer)
        {
            Contract.Requires(dataBuffer != null);
        }
//---------------------------------------------------------
        public void determineMethod(String dataBuffer)
        {
            Contract.Requires(dataBuffer != null);
            // selects the appropriate method from server tags
            //takeFromBuffer();
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(b != null);
        }
    }
}
