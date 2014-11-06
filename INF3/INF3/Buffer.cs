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

            messageComplete();
            message = buffer.getMessage();
            //send message to parser
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

        public void complete()
        {
            String message = "";
            String message2 = "";
            bool zweiteMessage = false;

            if (this.uBuffer.getMsgAtReadPointer().Contains(Syntax.BEGIN + Syntax.COLON_CHAR + this.messageCounter)) {
                while (!message.Contains(Syntax.END + Syntax.COLON_CHAR + this.messageCounter)) {
                    if (this.uBuffer.getMsgAtReadPointer().Contains(Syntax.BEGIN + Syntax.COLON_CHAR + this.messageCounter + 1))
                    {
                        while (!message2.Contains(Syntax.END + Syntax.COLON_CHAR + this.messageCounter + 1)) {
                            message2 += this.uBuffer.getMessage();
                        }
                        zweiteMessage = true;
                    }
                    message += this.uBuffer.getMessage();
                }

                             if (zweiteMessage)
                             {
                                this.messageCounter = this.messageCounter + 2;
                                buffer.addMessage(message);
                                buffer.addMessage(message2);
                             }
                            else
                             {
                                 this.messageCounter++;
                                 buffer.addMessage(message);
                             }   
                
            }
            
            message = String.Empty;
            message2 = String.Empty;
        }

        public void messageComplete() //mechanism that detects wether a message is finished
        {   
            String message="";
            while (!message.Contains(Syntax.END + Syntax.COLON_CHAR + messageCounter)) 
            {
                message += this.uBuffer.getMessage();
            }
            String[] content=Regex.Split(message, Syntax.END + Syntax.COLON_CHAR + messageCounter);
            message = String.Empty;
            if (!buffer.isFull())
            {
                this.buffer.addMessage(content[0]);
                this.messageCounter++;
            }
            else 
            {
                Console.WriteLine("Parser is too slow :D");    
            } 
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
