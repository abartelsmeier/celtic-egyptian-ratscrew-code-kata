using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata.Game
{
    public class PenaltyManager : IPenaltyManager
    {
        private readonly IDictionary<IPlayer, Penalty> _penalties;

        public PenaltyManager(IEnumerable<IPlayer> players)
        {
            _penalties = new Dictionary<IPlayer, Penalty>();
            foreach (var player in players)
            {
                _penalties.Add(player, Penalty.None);
            }
        }

        public Penalty HasPenalty(IPlayer player)
        {
            if (_penalties.ContainsKey(player)) return _penalties[player];
            return Penalty.Null;
        }

        public void ImposePenalty(IPlayer player, Penalty penalty)
        {
            if (_penalties.ContainsKey(player)) _penalties[player] = penalty;
        }

        public void ClearPenalty(IPlayer player)
        {
            if (_penalties.ContainsKey(player)) _penalties[player] = Penalty.None;
        }

        public void ClearAllPenalties()
        {
            foreach (var player in _penalties.Keys)
            {
                _penalties[player] = Penalty.None;
            }
        }

        public bool IsDeadlock()
        {
            return _penalties.Any(x => x.Value == Penalty.None);
        }
    }

    public enum Penalty
    {
        Null,
        None,
        PlayedOutOfTurn,
        IncorrectSnap
    }
}