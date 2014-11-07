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
        private Ringbuffer buffer;  //sortedBuffer
        private Ringbuffer uBuffer; //unsortedBufffer
        private int messageCounter = 0;
       

        public Buffer(int größe) {
            Contract.Requires(größe > 0);
            if (größe > 0)
            {
                buffer = new Ringbuffer(größe);
                uBuffer = new Ringbuffer(größe*3);
            }
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

            complete();
            if (buffer.getMsgAtReadPointer() !=null)
            {
                message = buffer.getMessage();
            }
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
            bool secondMessage = false;

            if (this.uBuffer.getMsgAtReadPointer().Contains(Syntax.BEGIN + Syntax.COLON_CHAR + this.messageCounter)) {
                while (!message.Contains(Syntax.END + Syntax.COLON_CHAR + this.messageCounter)) {
                    if (this.uBuffer.getMsgAtReadPointer().Contains(Syntax.BEGIN + Syntax.COLON_CHAR + this.messageCounter + 1))
                    {
                        while (!message2.Contains(Syntax.END + Syntax.COLON_CHAR + this.messageCounter + 1)) {
                            message2 += this.uBuffer.getMessage();
                        }
                        secondMessage = true;
                    }
                    message += this.uBuffer.getMessage();
                }

                             if (secondMessage)
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
            
        }
    }
}
