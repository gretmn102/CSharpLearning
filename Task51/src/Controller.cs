namespace App
{
    class Controller
    {
        readonly VillainsRepository _villainsRepository;

        public Controller(VillainsRepository villainsRepository)
        {
            _villainsRepository = villainsRepository;
        }

        public void Start()
        {
            View.Menu(this);
        }

        public void FilterVillains(VillainsQuery villainsQuery)
        {
            var filtredVillains = _villainsRepository.Filter(villainsQuery);
            View.DisplayFilteredVillains(villainsQuery, filtredVillains);
            View.Menu(this);
        }

        internal void ShowAllVillains()
        {
            View.DisplayVillains(_villainsRepository.Villains);
            View.Menu(this);
        }
    }
}
