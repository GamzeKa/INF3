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
            if (buffer!=null && !buffer.isBufferEmpty())
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

            MatchCollection matches = null;
                
                try
                {
                        //Überprüfung ob es sich um ein "Update" handelt.
                        if ((Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.UPDATE)).Success)
                        {
                            //Player - Update
                            if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PLAYER).Success)
                            {
                                
                            }

                            //Dragon - Update
                            else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.DRAGON).Success)
                            {
                                
                            }

                            //Cell - Update
                            else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.CELL).Success)
                            {
                                
                            }

                        }
                        else if ((Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.DELETE)).Success)
                        {

                            //Player - Delete
                            if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PLAYER).Success)
                            {
                               
                            }

                            //Dragon - Delete
                            else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.DRAGON).Success)
                            {
                                
                            }


                        }
                        else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.ENTITIES).Success &&
                            !(Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.UPDATE)).Success)
                        {
                            
                        }
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

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(buffer != null);
            Contract.Invariant(backend != null);
        }
    }
}
