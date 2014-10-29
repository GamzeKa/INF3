using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF3
{
    public class Buffer //is filed by the connector
    {
        Ringbuffer buffer;
       

        public Buffer(int größe) {
            Contract.Requires(größe > 0);
            buffer = new Ringbuffer(größe);
        }

        public void append(String s)
        {
            //add a new message to the Buffer
            Contract.Requires(s != null);
            buffer.addMessage(s);
        }

        public String giveParser()
        {
            Contract.Requires(buffer != null);
            String message="";
            if (MessageComplete()) {
                message = buffer.getMessage();
                //message Parser ünergben 

            }
            return message; //if the buffer is full or a message is finished reading, content is give to the parser
        }

        public bool isBufferFull()
        {
            return buffer.isFull();  
        }

        public void clearBuffer()
        {
     
            //delete all messages 
        }

        public bool MessageComplete()
        {   
            return true; //mechanism that detects wether a message is finished
        }

        public String getMessage() {
            return buffer.getMessage(); 
        }


        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
           
        }
    }
}
