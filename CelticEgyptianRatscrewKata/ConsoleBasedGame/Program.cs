using CelticEgyptianRatscrewKata.PenaltyGame;

namespace ConsoleBasedGame
{
    class Program
    {
        static void Main()
        {
            var ratscrewGame = new RatscrewGame(new RatscrewPenaltyGameFactory(), new ConsoleUserInterface());
            ratscrewGame.Play(new ConsoleLog());
        }
    }
}
