using System.Collections.Generic;
using CelticEgyptianRatscrewKata.SnapRules;

namespace CelticEgyptianRatscrewKata.Game
{
    class GameController
    {
        private IStackController m_StackController;
        private ISnapValidator m_SnapValidator;
        private IList<IRule> m_Rules;
        
        public GameController(IEnumerable<IPlayer> players, Cards deck, List<IRule> rules)
        {
            m_Rules = rules;
            m_SnapValidator = new SnapValidator();
            m_StackController = new StackController(players, deck);
        }
        
        public void Start()
        {
            m_StackController.Shuffle();
            m_StackController.Deal();
        }

        public void PlayCard(IPlayer player)
        {
            m_StackController.PlayCard(player);              
        }

        public bool AttemptSnap(IPlayer player)
        {
            if (!m_SnapValidator.CanSnap(m_StackController.Stack(), m_Rules)) return false;
            m_StackController.TakeStack(player);
            return true;
        }

        public IPlayer Winner()
        {
            return m_StackController.Winner();
        }
    }
}
