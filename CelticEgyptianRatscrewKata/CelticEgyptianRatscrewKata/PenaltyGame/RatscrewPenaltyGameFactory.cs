using CelticEgyptianRatscrewKata.GameSetup;
using CelticEgyptianRatscrewKata.Game;
using CelticEgyptianRatscrewKata.SnapRules;

namespace CelticEgyptianRatscrewKata.PenaltyGame
{
    public class RatscrewPenaltyGameFactory : IGameFactory
    {
        public IGameController Create(ILog log)
        {
            ISnapRule[] rules =
            {
                new DarkQueenSnapRule(),
                new SandwichSnapRule(),
                new StandardSnapRule(),
            };

            var gameController = new PenaltyGameController(new PenaltyGameState(), new SnapValidator(rules), new Dealer(), new Shuffler());
            return new LoggedPenaltyGameController(gameController, log);
        }
    }
}