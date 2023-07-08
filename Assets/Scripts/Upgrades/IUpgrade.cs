namespace Upgrades
{
    public interface IUpgrade
    {
        int Rank { get; }
        bool IsMax { get; }

        void UpdateRank();

        //string Name { get; }
        //void UpdateRank();
        //void Activate();
        //void Use();
        //void Stop();
        //void ChargeBoost(bool forceFullCharge = false);
        //void UpdateBoostAfterCharge();
    }
}
