namespace CelticEgyptianRatscrewKata.Game
{
    public interface IPenaltyManager
    {
        Penalty HasPenalty(IPlayer player);
        void ImposePenalty(IPlayer player, Penalty penalty);
        void ClearPenalty(IPlayer player);
        void ClearAllPenalties();
    }
}