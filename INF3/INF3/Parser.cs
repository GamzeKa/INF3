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

        public Parser(Buffer buffer,Backend.Backend backend)
        {
            Contract.Requires(buffer != null);
            Contract.Requires(backend != null);

            if(buffer!=null)
            {
                this.buffer=buffer;
            }
            if(backend!=null)
            {
                this.backend=backend;
            }
            while(true){
                takeFromBuffer();
            }
        }

        private void takeFromBuffer()
        {
            if (buffer!=null)
            {
                determineParsMethod(buffer.giveParser());  
            }
        }
//---------------------------------------------------------

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
                        //Überprüfung ob es sich um ein "Update" handelt.
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

                        //Empfängt wenn "Entities" gesendet werden.
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.ENTITIES).Success &&
                            !(Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.UPDATE)).Success)
                        {

                        }

                        //Empfängt wenn "Players" gesendet werden.
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PLAYERS).Success &&
                            !(Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.UPDATE)).Success)
                        {
                            
                        }

                        //Empfängt wenn nur ein "Player" gesendet wird.
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PLAYER).Success &&
                            !(Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.UPDATE)).Success)
                        {
                            
                        }

                        //Empfängt wenn nur ein "Dragon" gesendet wird.
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.DRAGON).Success &&
                            !(Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.UPDATE)).Success)
                        {
                            
                        }

                        //Überprüfung ob es sich um eine "Map" handelt.
                        else if ((Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.MAP)).Success)
                        {
                      
                        }

                        //Überprüfung ob es sich um eine "Message" handelt.
                        else if ((Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.MESSAGE)).Success)
                        {
                            
                        }


                        //Überprüfungen ob es sich um eine "ClientInfo" handelt.

                        //Time - Info
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.TIME).Success)
                        {
                            
                        }

                        //Online - Info
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.ONLINE).Success)
                        {
                            
                        }


                        //YourID - Info
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.YOURID).Success)
                        {
                            
                        }


                        //Challenge - Info
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.CHALLENGE).Success)
                        {
                          
                        }

                        //Opponent - Info
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.OPPONENT).Success)
                        {
                           
                        }

                        //Überprüfungen ob es sich um einen "Type-Minigame" handelt.                   

                        //Dragonhunt
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.TYPE).Success)
                        {
                            
                        }
                        //Staghunt
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.TYPE).Success)
                        {
                            
                        }
                        //Skirmish
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.TYPE).Success)
                        {
                            
                        }

                        //Überprüfung ob es sich um eine Antwort vom Server handelt.
                        else if (Regex.Match(dataFromBuffer, Syntax.ANSWER + Syntax.COLON_CHAR).Success)
                        {
                            
                        }
                        //Überprüfung ob es sich um eine"GameInfo handelt.
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.RESULT).Success)
                        {
                            
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

        public void updatePlayer(String dataFromBuffer)
        {
            MatchCollection matches = null;
            Int32 id;
            String typ;
            Boolean busyboolean;
            String description;
            Int32 x;
            Int32 y;
            Int32 points;
            Backend.entities.Player player;

            if (dataFromBuffer != null)
            {
                matches = parsMatchCollection(dataFromBuffer); // Der übergebene String wird gesplittet


                foreach (Match parMatch in matches) // Foreach schleife sorgt dafür das einfach die array index für index duch gelesen wird
                {
                    if ((Regex.Match(parMatch.Value, Syntax.ID + Syntax.COLON_CHAR)).Success)
                    {
                        id = parsToInt32(parMatch.Value); // Hilfs klasse ParseDrawl wandelt die Strem in denn gewünschten wert um
                        //                     Console.WriteLine("ID = " + id);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.TYPE + Syntax.COLON_CHAR)).Success)
                    {
                        typ = Regex.Match(parMatch.Value, Syntax.STRING).Value; // Hilfs klasse ParseDrawl wandelt die Strem in denn gewünschten wert um
                        //                       Console.WriteLine("Typ = " + typ);
                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.BUSY + Syntax.COLON_CHAR)).Success)
                    {
                        busyboolean = parsToBoolean(parMatch.Value); // Hilfs klasse ParseDrawl wandelt die Strem in denn gewünschten wert um
                        //                      Console.WriteLine("Busy = " + busyboolean);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.DESCRIPTION + Syntax.COLON_CHAR)).Success)
                    {
                        description = parsToString(parMatch.Value); // Hilfs klasse ParseDrawl wandelt die Strem in denn gewünschten wert um
                        //                       Console.WriteLine("desc = " + description);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.POS_X + Syntax.COLON_CHAR)).Success)
                    {
                        x = parsToInt32(parMatch.Value); // Hilfs klasse ParseDrawl wandelt die Strem in denn gewünschten wert um
                        //                       Console.WriteLine("x = " + x);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.POS_Y + Syntax.COLON_CHAR)).Success)
                    {
                        y = parsToInt32(parMatch.Value); // Hilfs klasse ParseDrawl wandelt die Strem in denn gewünschten wert um
                        //                       Console.WriteLine("y = " + y);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.POINTS + Syntax.COLON_CHAR)).Success)
                    {
                        points = parsToInt32(parMatch.Value);
                        //                       Console.WriteLine("points = " + points);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.END + Syntax.COLON_CHAR + Syntax.UPDATE)).Success)
                    {
                        player = new Backend.entities.Player(id, typ, busyboolean, description, x, y, points);
                        break;
                    }
                    //Update Player
                    backend.updatePlayer(id, typ, busyboolean, description, x, y, points);
                }
            }
            Console.WriteLine("Parsing Update Player ending\r\n");
        }

        public void updateDragon(String dataFromBuffer)
        {
            MatchCollection matches = null;
            Int32 id;
            String typ;
            Boolean busyboolean;
            String description;
            Int32 x;
            Int32 y;
            Int32 points;
            Backend.entities.Dragon dragon;

            if (dataFromBuffer != null)
            {
                matches = parsMatchCollection(dataFromBuffer); // Der übergebene String wird duch die hilfs klasse ParseDrawl gesplittet

                foreach (Match parMatch in matches) // Foreach schleife sorgt dafür das einfach die array index für index duch gelesen wird
                {
                    if ((Regex.Match(parMatch.Value, Syntax.ID + Syntax.COLON_CHAR)).Success)
                    {
                        id = parsToInt32(parMatch.Value); // Hilfs klasse ParseDrawl wandelt die Strem in denn gewünschten wert um
                        //                        Console.WriteLine("ID = " + id);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.TYPE + Syntax.COLON_CHAR)).Success)
                    {
                        typ = Regex.Match(parMatch.Value, Syntax.STRING).Value; // Hilfs klasse ParseDrawl wandelt die Strem in denn gewünschten wert um
                        //                        Console.WriteLine("Typ = " + typ);
                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.BUSY + Syntax.COLON_CHAR)).Success)
                    {
                        busyboolean = parsToBoolean(parMatch.Value); // Hilfs klasse ParseDrawl wandelt die Strem in denn gewünschten wert um
                        //                      Console.WriteLine("Busy = " + busyboolean);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.DESCRIPTION + Syntax.COLON_CHAR)).Success)
                    {
                        description = parsToString(parMatch.Value); // Hilfs klasse ParseDrawl wandelt die Strem in denn gewünschten wert um
                        //                    Console.WriteLine("desc = " + description);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.POS_X + Syntax.COLON_CHAR)).Success)
                    {
                        x = parsToInt32(parMatch.Value); // Hilfs klasse ParseDrawl wandelt die Strem in denn gewünschten wert um
                        //                   Console.WriteLine("x = " + x);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.POS_Y + Syntax.COLON_CHAR)).Success)
                    {
                        y = parsToInt32(parMatch.Value); // Hilfs klasse ParseDrawl wandelt die Strem in denn gewünschten wert um
                        //                     Console.WriteLine("y = " + y);

                    }
                    else if ((Regex.Match(parMatch.Value, Syntax.END + Syntax.COLON_CHAR + Syntax.UPDATE)).Success)
                    {
                        // beendet die Schleife
                        dragon = new Backend.entities.Dragon(id, typ, busyboolean, description, x, y);

                        break;

                    }
                    //Update Dragon
                    backend.updateDragon(id, typ, busyboolean, description, x, y);
                }
            }
            Console.WriteLine("Parsing Update Dragon ending\r\n");
        }

        public void updateMapCell(String dataFromBuffer)
        {
            MatchCollection matches = null;
            Backend.Map.MapCell cell=null;
            Int32 row;
            Int32 col;
            List<enums.Property> property = new List<enums.Property>();
            String cellcheck;
            int index = 0;

            if (dataFromBuffer != null)
            {
                matches = parsMatchCollection(dataFromBuffer);

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
                    //Update MapCell
                    backend.updateCell(row, col, property);
                }
            }
            Console.WriteLine("Parsing Update Map Cell ending\r\n");
        }

// Delete Methods---------------------------------------------------------------------------------------------------

        public void deletePlayer(String dataFromBuffer)
        {
            MatchCollection matches = null;
            Int32 idPlayer;
            String typ;

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

        public void deleteDragon(String dataFromBuffer)
        {
            MatchCollection matches = null;
            Int32 idDragon;
            String typ;

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

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(buffer != null);
            Contract.Invariant(backend != null);
        }
    }
}
