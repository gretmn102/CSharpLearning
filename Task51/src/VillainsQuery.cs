namespace App
{
    struct VillainsQuery
    {
        public int? MinHeight { get; set; }

        public bool IsArrested { get; set; }

        public VillainsQuery()
        {
            MinHeight = null;
            IsArrested = false;
        }

        public override string ToString()
        {
            System.Text.StringBuilder stringBuilder = new();
            stringBuilder.Append("Преступники, которые");

            if (MinHeight.HasValue)
            {
                stringBuilder.Append($" выше или равняются {MinHeight.Value}см, ");
            }

            stringBuilder.Append(IsArrested ? "находятся" : "не находятся под стражей");
            stringBuilder.Append("под стражей");

            return stringBuilder.ToString();
        }
    }
}
