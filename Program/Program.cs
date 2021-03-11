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
                gs.Player.State.RoundKills == 1 && 
                gs.Previously.Player.State.RoundKills == 0)
            {
                mybot.MessageChat("ok ok, thats 1 now get more.");
                Console.WriteLine("1k");
            }
            if (gs.Round.Phase == RoundPhase.Live &&
                gs.Player.State.RoundKills == 2 &&
                gs.Previously.Player.State.RoundKills == 1)
            {
                mybot.MessageChat("2? thats decent but i want more");
                Console.WriteLine("2k");
            }
            if (gs.Round.Phase == RoundPhase.Live &&
                gs.Player.State.RoundKills == 3 &&
                gs.Previously.Player.State.RoundKills == 2)
            {
                mybot.MessageChat("woooh, you just got a 3k!");
                Console.WriteLine("3k");
            }
            if (gs.Round.Phase == RoundPhase.Live &&
                gs.Player.State.RoundKills == 4 &&
                gs.Previously.Player.State.RoundKills == 3)
            {
                mybot.MessageChat("4k WOOOOOOOOH");
                Console.WriteLine("3k");
            }
            if (gs.Round.Phase == RoundPhase.Live &&
                gs.Player.State.RoundKills == 5 &&
                gs.Previously.Player.State.RoundKills == 4)
            {
                mybot.MessageChat("ACELELELELELELEL");
                Console.WriteLine("5k");
            }
        }
    }
}