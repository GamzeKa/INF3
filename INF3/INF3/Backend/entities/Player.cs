using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

using INF3.enums;
   
namespace INF3.Backend.entities
{
   public  class Player:Entity
    {
       private int points=0;

       public Player(int id, EnumType type, Boolean busy, String des, int positionX, int positionY, int points)
           : base(id, type, new Position(positionX,positionY))
       {

           setPoints(points);
           setBusy(busy);
           setDescription(des);

       }
       /*
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
       public void setSkirmishDecision(EnumSkirmish skirmish)//enum statt bool werten!
       {
           Contract.Requires(skirmish.GetType() == typeof(EnumSkirmish);
           this.skirmish = skirmish;
           Contract.Ensures(StaghuntDecision == d);
       }*/ //should be answerd by Game
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

       public override string ToString()
       {
           return "Player Id:" + this.getID() + " Points:" + this.getPoints() + " Pos:" + this.getPos().ToString();
       }

       [ContractInvariantMethod]
       private void ObjectInvariant()
       {
          // Contract.Invariant(id != 0);//0
           //Contract.Invariant(pos != null);
       }
    }
}
