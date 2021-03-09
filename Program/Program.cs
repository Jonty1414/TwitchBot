using System;
using CSGSI;
using CSGSI.Nodes;
using TwitchLib;
using TwitchLib.Client;

namespace Program
{
    class Program
    {
        static GameStateListener gsl;
        static TwitchBot mybot;
        static void Main(string[] args)
        {
            mybot = new TwitchBot();
            gsl = new GameStateListener(3000);
            gsl.NewGameState += new NewGameStateHandler(OnNewGameState);
            if (!gsl.Start())
            {
                Environment.Exit(0);
            }
            Console.WriteLine("Listening...");
        }

        public static void OnNewGameState(GameState gs)
        {

            Console.WriteLine("New Game State");
            if (gs.Round.Phase == RoundPhase.Live && 
                gs.Player.State.RoundKills == 3 && 
                gs.Previously.Player.State.RoundKills == 2)
            {
                mybot.MessageChat("woooh, you just got a 3k!!!!");
                Console.WriteLine("3k");
            }
        }
    }
}