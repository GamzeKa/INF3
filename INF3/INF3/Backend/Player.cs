using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF3.Backend
{
   public  class Player:Entity
    {
       private int points=0;
       public bool getStaghuntDecision()
       {
           return true;
       }
       public void setStaghuntDecision()
       {
          
       }
       public bool getDragonDecision()
       {
           return true;
       }
       public void setDragonDecision()
       {

       }
       public bool getSkirmishDecision()
       {
           return true;
       }
       public void setSkirmishDecision()
       {
          
       }
       public int getPoints()
       {
           return points;
       }
       public void setPoints(int p)
       {
           this.points = p;
       }
       public void addPoints(int p)
       {
           this.points = this.points+p;
       }
    }
}
