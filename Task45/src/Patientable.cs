namespace App
{
    class Patientable
    {
        public int RestoreHpCount { get; set; }
        public Patientable(int restoreHpCount)
        {
            RestoreHpCount = restoreHpCount;
        }

        public void Restore(Battler battler)
        {
            if (battler.Patientable == null)
            {

            }
            else
            {
                battler.Hp += RestoreHpCount;
            }
        }
    }
}
