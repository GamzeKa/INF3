using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF3
{
    class Ringbuffer
    {
        private String[] memory = null;
        private int readPointer=0;
        private int writePointer=0;


        public Ringbuffer(int size){
            if (size != null && size > 0)
            {  
                memory = new String[size];
            }
        }

        public void incReadPointer() {
            if (readPointer <= this.memory.Length-1){
                this.readPointer++;
            }
            else {
                this.readPointer = 0;
            }
        }

        public void incWritePointer()
        {
            if (writePointer <= this.memory.Length-1)
            {
                this.writePointer++;
            }
            else
            {
                this.writePointer = 0;
            }
        }

        public bool isFull() {
            bool full=false;
        for(int i=0; i<=memory.Length; i++){
                if(memory[i]!=null){
                    full = true;
                    return full;
                }
             
            }
        return full;
        }

        public void addMessage(String message){
            if (message != null)
            {
                if (this.memory[this.writePointer] == null)
                {
                    memory[this.writePointer] = message;
                    this.incWritePointer();
                }
                else
                {
                    //Speicherplatz zuweisen
                }
            }
        }

        public String getMessage() {
            if (this.memory[this.readPointer] == null)
            {
                //throw new Exception("Feld leer");
            }
            String s = this.memory[this.readPointer];
            this.memory[this.readPointer] = null;
            this.incReadPointer();
            return s;
        }

        public bool isBufferEmpty()
        {
            if (this.memory.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    
}
