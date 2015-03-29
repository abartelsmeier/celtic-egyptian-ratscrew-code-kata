using System.Collections.Generic;

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
            return Penalty.None;
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
    }

    public enum Penalty
    {
        None,
        PlayedOutOfTurn
    }
}