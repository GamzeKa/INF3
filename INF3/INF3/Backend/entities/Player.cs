using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace INF3.Backend.entities
{
   public  class Player:Entity
    {
       private int points=0;
       

       public Player(int id, String type, Boolean busy, String desc, int positionX, int positionY, int points)
           : base(id, type, new Position(positionX,positionY))
       {

           setPoints(points);
           setBusy(busy);
           setDescription(desc);

       }

       public bool getStaghuntDecision()
       {
           Contract.Requires(StaghuntDecision.GetType() == typeof(bool));
           return this.StaghuntDecision;
       }
       public void setStaghuntDecision(bool d)
       {
           Contract.Requires(d.GetType() == typeof(bool));
           Contract.Ensures(StaghuntDecision == d);
       }
       public bool getDragonDecision()
       {
           Contract.Ensures(this.DragonDecision.GetType()==typeof(bool));
           return this.DragonDecision;
       }
       public void setDragonDecision(bool d)
       {
           Contract.Requires(d.GetType() == typeof(bool));
           this.DragonDecision = d;
           Contract.Ensures(StaghuntDecision == d);
       }
       public bool getSkirmishDecision()
       {
           Contract.Requires(SkirmishDecision.GetType() == typeof(bool));
           return true;
       }
       public void setSkirmishDecision(bool d)//enum statt bool werten!
       {
           Contract.Requires(d.GetType() == typeof(bool));
           this.StaghuntDecision = d;
           Contract.Ensures(StaghuntDecision == d);
       }
       public int getPoints()
       {
           Contract.Ensures(points >= 0);
           return points;
       }
       public void setPoints(int p)
       {
           Contract.Requires(p >= 0);
           this.points = p;
           Contract.Ensures(this.points == p);
       }
       public void addPoints(int p)
       {
           Contract.Requires(p >= 0);
           this.points = this.points+p;
           Contract.Ensures(this.points == (this.points+p));
       }

       [ContractInvariantMethod]
       private void ObjectInvariant()
       {
           Contract.Invariant(id != 0);//0
           Contract.Invariant(pos != null);
       }
    }
}
