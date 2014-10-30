using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INF3.Backend.Minigames
{
    public abstract class Game
    {
        private int id;
		private bool accepted;
		
		public Game(int id,bool accepted)
		{
            setID(id);
			setAccepted(accepted);
		}
		
		public void setID(int id){
			this.id=id;
		}
		
		public int getID(){
			return id;
		}
		
		public void setAccepted(bool accepted){
			this.accepted=accepted;
		}

        public bool isAccepted()
        {
            return accepted;
        }
    }
}
