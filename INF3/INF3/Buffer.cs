using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace INF3
{
    public class Buffer //is filled by the connector
    {
        private Ringbuffer buffer;  //sortedBuffer
        private List<String> uBuffer; //unsortedBufffer
        private Thread bufferThread;
       

        public Buffer(int size) {
            Contract.Requires(size > 0);
            if (size > 0)
            {
                buffer = new Ringbuffer(size);
                uBuffer = new List<String>();
            }
            this.bufferThread = new Thread(new ThreadStart(complete));
            this.bufferThread.Name = "BufferThread";
            this.bufferThread.Start();
        }

        public void append(String s)
        {
            //add a new message to the Buffer
            Contract.Requires(s != null);
            if (s != null) {
                lock(uBuffer)
                {
                    uBuffer.Add(s);
                }
            }
        }

        public String giveParser()
        {
            Contract.Requires(buffer != null);
            String message=null;

            lock (buffer)
            {
                if (buffer.getMsgAtReadPointer() != null)
                {
                    message = buffer.getMessage();
                }
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
            String messageNumber;

            while (true)
            {
                if (this.uBuffer.Count > 0)
                {
                    lock (this.uBuffer)
                    {
                        messageNumber = Regex.Match(this.uBuffer[0], Syntax.INTEGER).ToString();

                        if (Regex.Match(this.uBuffer[0], Syntax.BEGIN + Syntax.COLON_CHAR + messageNumber).Success)
                        {
                            while (!(Regex.Match(message, Syntax.END + Syntax.COLON_CHAR + messageNumber).Success))
                            {
                                if (uBuffer.Count > 0)
                                {
                                    message += this.uBuffer[0];
                                    this.uBuffer.RemoveAt(0);
                                }
                            }
                            lock (this.buffer)
                            {
                                buffer.addMessage(message);
                            }
                            message = "";
                        }
                    }
                }
                else
                {
                    Thread.Sleep(200);
                }
            }
        }
    }
}
