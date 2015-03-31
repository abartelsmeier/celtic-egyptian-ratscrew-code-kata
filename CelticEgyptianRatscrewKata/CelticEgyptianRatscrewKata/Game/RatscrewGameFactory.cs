using CelticEgyptianRatscrewKata.GameSetup;
using CelticEgyptianRatscrewKata.SnapRules;

namespace CelticEgyptianRatscrewKata.Game
{
    public class RatscrewGameFactory : IGameFactory
    {
        public IGameController Create(ILog log)
        {
            var playerSequence = new PlayerSequence();
            var callout = new LoggedCallout(playerSequence, log);
            
            ISnapRule[] rules =
            {
                //new DarkQueenSnapRule(),
                //new SandwichSnapRule(),
                //new StandardSnapRule(),
                new CallOutSnapRule(callout)
            };

            var penalties = new Penalties();
            var loggedPenalties = new LoggedPenalties(penalties, log);
            var gameController = new GameController(new GameState(), new SnapValidator(rules), new Dealer(), new Shuffler(), loggedPenalties, callout);
            return new LoggedGameController(gameController, log);
        }
    }
}