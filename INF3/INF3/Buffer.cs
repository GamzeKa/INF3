﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF3
{
    public class Buffer //is filed by the connector
    {
        public void append(String s)
        {
            //add a new message to the Buffer
            Contract.Requires(s != null);

        }

        public String giveParser()
        {
            return ""; //if the buffer ist full or a message is finished reading, content is give to the parser
        }

        public bool isBufferEmpty()
        {
            return true;  //information if the Buffer is empty
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
            return "";
        }
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
           
        }
    }
}
