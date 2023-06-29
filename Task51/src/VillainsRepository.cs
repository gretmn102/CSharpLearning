namespace App
{
    class VillainsRepository
    {
        public Villain[] Villains { get; set; }

        public VillainsRepository(Villain[] villains)
        {
            Villains = villains;
        }

        public IEnumerable<Villain> Filter(VillainsQuery villainsQuery)
        {
            return from villain in Villains
                   where (!villainsQuery.MinHeight.HasValue || villain.Height >= villainsQuery.MinHeight)
                       && villainsQuery.IsArrested == villain.IsArrested
                   select villain;
        }
    }
}
