using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace INF3
{
    public class Parser
    {
        Buffer buffer;
        Backend.Backend backend;

        public Parser(Buffer buffer, Backend.Backend backend)
        {
            Contract.Requires(buffer != null);
            Contract.Requires(backend != null);
            Contract.OldValue(this.buffer == null);
            Contract.OldValue(this.backend == null);

            if(buffer!=null)
            {
                this.buffer=buffer;
            }
            if(backend!=null)
            {
                this.backend=backend;
            }
            //checks the conditions of buffer and backend
            Contract.Assert(this.buffer != null);
            Contract.Assert(this.backend != null);
            while(true){
                takeFromBuffer();
            }
        }

        private void takeFromBuffer()
        {
            if (buffer!=null)
            {
                determineParsMethod(buffer.giveParser());  //takes the information from buffer with the giveparser() method
            }
        }
//---------------------------------------------------------
        //parsto-methods for the string input, to int32, bool, long etc..
        public static String parsToString(String input)
        {
            return Regex.Match(input, Syntax.STRING).Value.Replace("\r", "");
        }

        public static Int32 parsToInt32(String input)
        {
            return Convert.ToInt32(Regex.Match(input, Syntax.INTEGER).Value);
        }

        public static bool parsToBoolean(String input)
        {
            return Convert.ToBoolean(Regex.Match(input, Syntax.BOOLEAN).Value);
        }

        public static long parsToLong(String input)
        {
            return Convert.ToInt64(Regex.Match(input, Syntax.LONG).Value);
        }

        public static MatchCollection parsMatchCollection(String input)
        {
            return Regex.Matches(input, Syntax.CUT);
        }

        public static String[] parsMatchPlayer(String input)
        {
            return Regex.Split(input, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PLAYER);
        }

        public static String[] parsMatchDragon(String input)
        {
            return Regex.Split(input, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.DRAGON);
        }

        public static String[] parsMatchMapCell(String input)
        {
            return Regex.Split(input, Syntax.CUTCELL);
        }

        public static String[] parsMatchMapCells(String input)
        {
            return Regex.Split(input, Syntax.CUTCELLS);
        }

//---------------------------------------------------------
        private void determineParsMethod(String dataFromBuffer)
        {
            Contract.Requires(dataFromBuffer != null);
                
                try
                {
                        
                        //Check if this is an update
                        if ((Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.UPDATE)).Success)
                        {
                            //Player - Update
                            if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PLAYER).Success)
                            {
                                updatePlayer(dataFromBuffer);
                            }

                            //Dragon - Update
                            else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.DRAGON).Success)
                            {
                                updateDragon(dataFromBuffer);
                            }

                            //Cell - Update
                            else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.CELL).Success)
                            {
                                updateMapCell(dataFromBuffer);
                            }

                        }
                            //Check if this is a delete
                        else if ((Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.DELETE)).Success)
                        {

                            //Player - Delete
                            if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PLAYER).Success)
                            {
                                deletePlayer(dataFromBuffer);
                            }

                            //Dragon - Delete
                            else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.DRAGON).Success)
                            {
                                deleteDragon(dataFromBuffer);
                            }


                        }

                        //recieves entities
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.ENTITIES).Success &&
                            !(Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.UPDATE)).Success)
                        {
                            this.EntityList(dataFromBuffer);
                        }

                        //receives players
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PLAYERS).Success &&
                            !(Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.UPDATE)).Success)
                        {
                            this.creatPlayers(dataFromBuffer);
                        }

                        //recieves a player
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PLAYER).Success &&
                            !(Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.UPDATE)).Success)
                        {
                            this.creatPlayer(dataFromBuffer);
                        }

                        //recieves a dragon
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.DRAGON).Success &&
                            !(Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.UPDATE)).Success)
                        {
                            this.creatDragon(dataFromBuffer);
                        }

                        //recieves a map
                        else if ((Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.MAP)).Success)
                        {
                            this.createMap(dataFromBuffer);
                        }

                        //check if this is a message
                        else if ((Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.MESSAGE)).Success)
                        {
                            this.createMessage(dataFromBuffer);
                        }
                        

                        //Time - Info
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.TIME).Success)
                        {
                            this.createTimeInfo(dataFromBuffer);
                        }

                        //Online - Info
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.ONLINE).Success)
                        {
                            this.createOnlineInfo(dataFromBuffer);
                        }
                        //YourID - Info
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.YOURID).Success)
                        {
                            this.createYourID(dataFromBuffer);
                        }
                        //recieves Challenge
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.CHALLENGE).Success)
                        {
                            this.createChallenge(dataFromBuffer);
                        }
                        //recieves Opponent
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.OPPONENT).Success)
                        {
                            this.createOpponent(dataFromBuffer);
                        }
                        //check if this is a type of a minigame                 

                        //Dragonhunt
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.TYPE).Success)
                        {
                            createDragonFight(dataFromBuffer);
                        }
                        //Staghunt
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.TYPE).Success)
                        {
                            createStaghunt(dataFromBuffer);
                        }
                        //Skirmish
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.TYPE).Success)
                        {
                            createSkirmish(dataFromBuffer);
                        }

                        //Check if this is a answer from server
                        else if (Regex.Match(dataFromBuffer, Syntax.ANSWER + Syntax.COLON_CHAR).Success)
                        {
                            createAnswer(dataFromBuffer);
                        }
                        //Check if this is a game info
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.RESULT).Success)
                        {
                            createResult(dataFromBuffer);
                        }
                        else
                        {
                            Console.WriteLine("Fehler: Befehl vom Server nicht Parsbar");
                        }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }

// Update Methods---------------------------------------------------------------------------------------------------

        public void updatePlayer(String dataFromBuffer) //update method for the player
        {
            MatchCollection matches = null;
            Int32 id=0;
            String typ=null;
            Boolean busyboolean=false;
            String description=null;
            Int32 x=0;
            Int32 y=0;
            Int32 points=0;
            Backend.entities.Player player;

            if (dataFromBuffer != null)
            {
                matches = parsMatchCollection(dataFromBuffer); 


                foreach (Match parMatch in matches) 
                {
                    if ((Regex.Match(parMatch.Value, Syntax.ID + Syntax.COLON_CHAR)).Success)
                    {
                        id = parsToInt32(parMatch.Value); 

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.TYPE + Syntax.COLON_CHAR)).Success)
                    {
                        typ = Regex.Match(parMatch.Value, Syntax.STRING).Value; 
                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.BUSY + Syntax.COLON_CHAR)).Success)
                    {
                        busyboolean = parsToBoolean(parMatch.Value); 

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.DESCRIPTION + Syntax.COLON_CHAR)).Success)
                    {
                        description = parsToString(parMatch.Value); 

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.POS_X + Syntax.COLON_CHAR)).Success)
                    {
                        x = parsToInt32(parMatch.Value); 

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.POS_Y + Syntax.COLON_CHAR)).Success)
                    {
                        y = parsToInt32(parMatch.Value); 

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.POINTS + Syntax.COLON_CHAR)).Success)
                    {
                        points = parsToInt32(parMatch.Value);
                      

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.END + Syntax.COLON_CHAR + Syntax.UPDATE)).Success) //end update information
                    {
                        player = new Backend.entities.Player(id, typ, busyboolean, description, x, y, points);
                        break;
                    }
                    //Updates Player
                    backend.updatePlayer(id, typ, busyboolean, description, x, y, points);
                }
            }
            Console.WriteLine("Parsing Update Player ending\r\n");
        }

        public void updateDragon(String dataFromBuffer) //update method for the dragon
        {
            MatchCollection matches = null;
            Int32 id=0;
            String typ=null;
            Boolean busyboolean=false;
            String description=null;
            Int32 x=0;
            Int32 y=0;
            Backend.entities.Dragon dragon;

            if (dataFromBuffer != null)
            {
                matches = parsMatchCollection(dataFromBuffer); 

                foreach (Match parMatch in matches) // Foreach searches for each parMatch in matches index to index
                {
                    if ((Regex.Match(parMatch.Value, Syntax.ID + Syntax.COLON_CHAR)).Success)
                    {
                        id = parsToInt32(parMatch.Value); 
                        //                        Console.WriteLine("ID = " + id);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.TYPE + Syntax.COLON_CHAR)).Success)
                    {
                        typ = Regex.Match(parMatch.Value, Syntax.STRING).Value; 
                        //                        Console.WriteLine("Typ = " + typ);
                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.BUSY + Syntax.COLON_CHAR)).Success)
                    {
                        busyboolean = parsToBoolean(parMatch.Value); 
                        //                      Console.WriteLine("Busy = " + busyboolean);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.DESCRIPTION + Syntax.COLON_CHAR)).Success)
                    {
                        description = parsToString(parMatch.Value); 
                        //                    Console.WriteLine("desc = " + description);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.POS_X + Syntax.COLON_CHAR)).Success)
                    {
                        x = parsToInt32(parMatch.Value); 
                        //                   Console.WriteLine("x = " + x);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.POS_Y + Syntax.COLON_CHAR)).Success)
                    {
                        y = parsToInt32(parMatch.Value); 
                        //                     Console.WriteLine("y = " + y);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.END + Syntax.COLON_CHAR + Syntax.UPDATE)).Success)
                    {
                        // ends foreach 
                        dragon = new Backend.entities.Dragon(id, typ, busyboolean, description, x, y);

                        break;

                    }
                    //Updates the Dragon
                    backend.updateDragon(id, typ, busyboolean, description, x, y);
                }
            }
            Console.WriteLine("Parsing Update Dragon ending\r\n");
        }

        public void updateMapCell(String dataFromBuffer) //update method for mapcell
        {
            MatchCollection matches = null;
            Backend.Map.MapCell cell=null;
            Int32 row=0;
            Int32 col=0;
            List<enums.Property> property = new List<enums.Property>();
            String cellcheck;
            int index = 0;

            if (dataFromBuffer != null)
            {
                matches = parsMatchCollection(dataFromBuffer); //split method

                foreach (Match parMatch in matches)
                {
                    if ((Regex.Match(parMatch.Value, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.CELL)).Success)
                    {
                        cellcheck = parsToString(parMatch.Value);
                        //                     Console.WriteLine("cellcheck = " + cellcheck);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.ROW + Syntax.COLON_CHAR)).Success)
                    {
                        row = parsToInt32(parMatch.Value);
                        //                     Console.WriteLine("row = " + row);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.COL + Syntax.COLON_CHAR)).Success)
                    {
                        col = parsToInt32(parMatch.Value);
                        //                     Console.WriteLine("col = " + col);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.WALKABLE)).Success)
                    {

                        property.Add(enums.Property.WALKABLE);
                        //                        Console.WriteLine("property" + (index + 1) + " = " + property[index].ToString());
                        index++;
                    }
                    else if (Regex.Match(parMatch.Value, Syntax.WALL).Success)
                    {
                        property.Add(enums.Property.WALL);
                        //                      Console.WriteLine("property" + (index + 1) + " = " + property[index].ToString());
                        index++;
                    }
                    else if (Regex.Match(parMatch.Value, Syntax.WATER).Success)
                    {
                        property.Add(enums.Property.WATER);
                        //                       Console.WriteLine("property" + (index + 1) + " = " + property[index].ToString());
                        index++;
                    }
                    else if (Regex.Match(parMatch.Value, Syntax.HUNTABLE).Success)
                    {
                        property.Add(enums.Property.HUNTABLE);
                        //                       Console.WriteLine("property" + (index + 1) + " = " + property[index].ToString());
                        index++;
                    }
                    else if (Regex.Match(parMatch.Value, Syntax.FOREST).Success)
                    {
                        property.Add(enums.Property.FOREST);
                        //                       Console.WriteLine("property"+(index+1)+" = " + property[index].ToString());
                        index++;
                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.END + Syntax.COLON_CHAR + Syntax.UPDATE)).Success)
                    {


                        cell = new Backend.Map.MapCell(row, col, property);
                        property.Clear();
                        break;

                    }
                    //Updates the MapCell
                    backend.updateCell(row, col, property);
                }
            }
            Console.WriteLine("Parsing Update Map Cell ending\r\n");
        }

// Delete Methods---------------------------------------------------------------------------------------------------

        public void deletePlayer(String dataFromBuffer)//delete method the player
        {
            MatchCollection matches = null;
            Int32 idPlayer=0;
            String typ=null;

            if (dataFromBuffer != null)
            {
                matches = parsMatchCollection(dataFromBuffer);

                foreach (Match parMatch in matches)
                {
                    if ((Regex.Match(parMatch.Value, Syntax.ID + Syntax.COLON_CHAR)).Success)
                    {
                        idPlayer = parsToInt32(parMatch.Value);
                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.TYPE + Syntax.COLON_CHAR)).Success)
                    {
                        typ = parsToString(parMatch.Value);
                    }
                }
                backend.deletePlayer(idPlayer,typ);
            }
            Console.WriteLine("Parsing Delete Player ending\r\n");
        }

        public void deleteDragon(String dataFromBuffer) //delete method for dragon
        {
            MatchCollection matches = null;
            Int32 idDragon=0;
            String typ=null;

            if (dataFromBuffer != null)
            {
                matches = parsMatchCollection(dataFromBuffer);

                foreach (Match parMatch in matches)
                {
                    if ((Regex.Match(parMatch.Value, Syntax.ID + Syntax.COLON_CHAR)).Success)
                    {
                        idDragon = parsToInt32(parMatch.Value);
                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.TYPE + Syntax.COLON_CHAR)).Success)
                    {
                        typ = parsToString(parMatch.Value);
                    }
                }
                backend.deleteDragon(idDragon, typ);
            }
            Console.WriteLine("Parsing Delete Dragon ending\r\n");
        }

        public void EntityList(String dataFromBuffer) //entities method for dragon and player
        {
            if (dataFromBuffer != null)
            {

                
                String[] matchPlayer = parsMatchPlayer(dataFromBuffer);

                foreach (String parMatch in matchPlayer)
                {
                    if ((Regex.Match(parMatch, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.DRAGON)).Success)
                    {
                        String[] matchDragon = parsMatchDragon(dataFromBuffer);

                        foreach (String parMatchDragon in matchDragon)
                        {
                            if ((Regex.Match(parMatchDragon, Syntax.END + Syntax.COLON_CHAR + Syntax.PLAYER)).Success)
                            {
                                creatPlayer(parMatchDragon);
                            }
                            else if ((Regex.Match(parMatchDragon, Syntax.END + Syntax.COLON_CHAR + Syntax.DRAGON)).Success)
                            {
                                creatDragon(parMatchDragon);
                            }
                        }
                    }
                    else if ((Regex.Match(parMatch, Syntax.END + Syntax.COLON_CHAR + Syntax.PLAYER)).Success)
                    {
                        creatPlayer(parMatch);
                    }
                }
            }
        }

        public void creatPlayer(String dataFromBuffer) //create method for the player
        {
            Int32 id=0;
            String typ=null;
            Boolean busyboolean=false;
            String description=null;
            Int32 x=0;
            Int32 y=0;

            MatchCollection matches = null;

            Int32 points=0;
		
            if (dataFromBuffer != null)
            {
                matches = parsMatchCollection(dataFromBuffer);

                // foreach searches for each parMatch in matches
                // repeats this for each index in array
                foreach (Match parMatch in matches)
                {
                    if ((Regex.Match(parMatch.Value, Syntax.ID + Syntax.COLON_CHAR)).Success)
                    {
                        
                        id = parsToInt32(parMatch.Value);
                        //			Console.WriteLine("ID = " + id);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.TYPE + Syntax.COLON_CHAR)).Success)
                    {
                        
                        typ = Regex.Match(parMatch.Value, Syntax.STRING).Value;
                        //				Console.WriteLine("Typ = " + typ);
                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.BUSY + Syntax.COLON_CHAR)).Success)
                    {
                        
                        busyboolean = parsToBoolean(parMatch.Value);
                        //				Console.WriteLine("Busy = " + busyboolean);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.DESCRIPTION + Syntax.COLON_CHAR)).Success)
                    {
                        
                        description = parsToString(parMatch.Value);
                        //			Console.WriteLine("desc = " + description);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.POS_X + Syntax.COLON_CHAR)).Success)
                    {
                        
                        x = parsToInt32(parMatch.Value);
                        //		Console.WriteLine("x = " + x);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.POS_Y + Syntax.COLON_CHAR)).Success)
                    {
                        
                        y = parsToInt32(parMatch.Value);
                        //				Console.WriteLine("y = " + y);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.POINTS + Syntax.COLON_CHAR)).Success)
                    {
                        
                        points = parsToInt32(parMatch.Value);
                        //			Console.WriteLine("points = " + points);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.END + Syntax.COLON_CHAR + Syntax.PLAYER)).Success)
                    {
                        Backend.entities.Player p = new Backend.entities.Player(id, typ, busyboolean, description, x, y, points);
                        backend.storePlayer(p);
                        break;
                    }
                }
            }
            Console.WriteLine("Parsing Player ending\r\n");
        }

        public void creatPlayers(String dataFromBuffer) //create method for players
        {
            MatchCollection matches = null;

            if (dataFromBuffer != null)
            {
                //			Console.WriteLine("--------------------------Parsing Players--------------------------------");
                
                matches = parsMatchCollection(dataFromBuffer);

                // foreach searches each parMatch in matches
                foreach (Match parMatch in matches)
                {
                    this.creatPlayer(parMatch.Value);
                }
            }
            Console.WriteLine("Parsing Players ending\r\n");
        }

        public void creatDragon(String dataFromBuffer) //create method for the dragon
		{

		    MatchCollection matches = null;
            Int32 id=0;
            String typ=null;
            Boolean busyboolean=false;
            String description=null;
            Int32 x=0;
            Int32 y=0;

			if (dataFromBuffer != null)
			{
				
                matches = parsMatchCollection(dataFromBuffer);
                // foreach searches each parMatch in matches
				foreach (Match parMatch in matches)
				{
					if ((Regex.Match(parMatch.Value, Syntax.ID + Syntax.COLON_CHAR)).Success)
					{
						
						id = parsToInt32(parMatch.Value);
			//			Console.WriteLine("ID = " + id);

					}
					else if ((Regex.Match(parMatch.Value, Syntax.TYPE + Syntax.COLON_CHAR)).Success)
					{
						typ = Regex.Match(parMatch.Value, Syntax.STRING).Value;
			//			Console.WriteLine("Typ = " + typ);
					}
					else if ((Regex.Match(parMatch.Value, Syntax.BUSY + Syntax.COLON_CHAR)).Success)
					{
						
						busyboolean = parsToBoolean(parMatch.Value);
		//				Console.WriteLine("Busy = " + busyboolean);

					}
					else if ((Regex.Match(parMatch.Value, Syntax.DESCRIPTION + Syntax.COLON_CHAR)).Success)
					{
						
						description = parsToString(parMatch.Value);
		//				Console.WriteLine("desc = " + description);

					}
					else if ((Regex.Match(parMatch.Value, Syntax.POS_X + Syntax.COLON_CHAR)).Success)
					{
						
						x = parsToInt32(parMatch.Value);
			//			Console.WriteLine("x = " + x);

					}
					else if ((Regex.Match(parMatch.Value, Syntax.POS_Y + Syntax.COLON_CHAR)).Success)
					{
						
						y = parsToInt32(parMatch.Value);
		//				Console.WriteLine("y = " + y);

					}
					else if ((Regex.Match(parMatch.Value, Syntax.END + Syntax.COLON_CHAR + Syntax.DRAGON)).Success)
					{
						// beendet die Schleife
                        Backend.entities.Dragon d = new Backend.entities.Dragon(id, typ, busyboolean, description, x, y);
                        backend.storeDragon(d);
                        break;
					}
				}
			}
            Console.WriteLine("Parsing Create Dragon ending\r\n");
		}

        private void createResult(string dataFromBuffer)// create method for result
        {
            Int32 round=0;
            Boolean running=false;
            Int32 delay=0;

            backend.setResult(round, running, delay);
        }

        private void createAnswer(string dataFromBuffer) // create method for the answer
        {
            String answer = null;
            backend.serverAnswer(answer);
        }

        private void createOpponent(string dataFromBuffer) //create method for the opponent
        {
            Backend.Opponent o=null;
            backend.setOpponent(o);
        }

        private void createChallenge(string dataFromBuffer) // create method for the challenge
        {
            Backend.Minigames.Game minigame = null;
            backend.setChallange(minigame);
        }

        private void createYourID(string dataFromBuffer) //create method for creating the id
        {
            Int32 yourid=0;
            backend.yourID(yourid);
        }

        private void createOnlineInfo(string dataFromBuffer) //create method for online info
        {
            Int32 online=0;
            backend.onlineInfo(online);
        }

        private void createTimeInfo(string dataFromBuffer) // create method for the time info
        {
            long time=0;
            backend.receiveTime(time);
        }

        private void createMessage(string dataFromBuffer)// create method for the message
        {
            String message=null;
            backend.setMessage(message);
        }

        private void createMap(string dataFromBuffer)//create method for map
        {
            Backend.Map.Map m=null;

            backend.setMap(m);
        }

        public void createMapCell(String value) //create method for mapcell
        { 
        
        }

        public void createSkirmish(string dataFromBuffer)
        {
            throw new NotImplementedException();
        }

        public void createStaghunt(string dataFromBuffer)
        {
            throw new NotImplementedException();
        }

        public void createDragonFight(string dataFromBuffer)
        {
            throw new NotImplementedException();
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(buffer != null);
            Contract.Invariant(backend != null);
        }
    }
}
