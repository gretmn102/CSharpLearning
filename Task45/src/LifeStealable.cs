namespace App
{
    class LifeStealable
    {
        public int RestoreHpCount { get; set; }
        public LifeStealable(int restoreHpCount)
        {
            RestoreHpCount = restoreHpCount;
        }

        public void Restore(Battler battler)
        {
            if (battler.LifeStealable == null)
            {

            }
            else
            {
                battler.Hp += RestoreHpCount;
            }
        }
    }
}
