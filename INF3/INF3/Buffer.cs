using System;
using System.Collections.Generic;
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

        }

        public String giveParser()
        {
            return ""; //if the buffer ist full or a message is finished reading, content is give to the parser
        }

        public bool isBufferEmpty()
        {
            return true;  //information if the Buffer is full or empty
        }

        public void clearBuffer()
        {
            //delet all messages 
        }

        public bool MessageComplete()
        {
            return true; //mechanism taht detects wether a message is finished
        }


    }
}
