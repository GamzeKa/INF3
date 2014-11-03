using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace INF3
{
    public class Buffer //is filled by the connector
    {
        private Ringbuffer buffer;
        private Ringbuffer uBuffer;
        private int messageCounter = 0;
       

        public Buffer(int größe) {
            Contract.Requires(größe > 0);
            buffer = new Ringbuffer(größe);
            uBuffer = new Ringbuffer(größe);
        }

        public void append(String s)
        {
            //add a new message to the Buffer
            Contract.Requires(s != null);
            uBuffer.addMessage(s);
        }

        public String giveParser()
        {
            Contract.Requires(buffer != null);
            String message="";
            Contract.Requires(MessageComplete());
            if (MessageComplete()) {
                message = buffer.getMessage();
                //send message to parser

            }
            return message; //if the buffer is full or a message is finished reading, content is give to the parser
        }

        public bool isBufferFull()
        {
            return buffer.isFull();  
        }
        public bool isBufferEmpty()
        {
            return this.buffer.isBufferEmpty();
        }

        public bool MessageComplete() //mechanism that detects wether a message is finished
        {   String message="";
        while (!message.Contains(Syntax.END + Syntax.COLON_CHAR + messageCounter)) {
            message += this.uBuffer.getMessage();
        }
        String[] content=Regex.Split(message, Syntax.END + Syntax.COLON_CHAR + messageCounter);
        message = String.Empty;
        if (!buffer.isFull())
        {
            this.buffer.addMessage(content[0]);
            this.messageCounter++;
        }
        else {
            Console.WriteLine("Parser zu langsam :D");    
        }
            return true; 
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
