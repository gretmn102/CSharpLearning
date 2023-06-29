namespace App
{
    struct Villain
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsArrested { get; set; }
        /// <summary>measured in centimeters</summary>
        public int Height { get; set; }
        /// <summary>measured in kilograms</summary>
        public int Weight { get; set; }
        public string Nationality { get; set; }

        public override readonly string ToString()
        {
            System.Text.StringBuilder stringBuilder = new();
            string tab = "    ";
            static string SerializeBool(bool value) => value ? "true" : "false";
            static string SerializeString(string x) => $"\"{x.Replace("\\", "\\\"")}\"";
            static string SerializePropAssignment(string name, string value) =>
                $"{name} = {value}";
            string SerializeTabPropAssignmentComma(string name, string value) =>
                $"{tab}{SerializePropAssignment(name, value)},";

            stringBuilder.AppendLine("{");
            stringBuilder.AppendLine(SerializeTabPropAssignmentComma(nameof(FirstName), SerializeString(FirstName)));
            stringBuilder.AppendLine(SerializeTabPropAssignmentComma(nameof(LastName), SerializeString(LastName)));
            stringBuilder.AppendLine(SerializeTabPropAssignmentComma(nameof(IsArrested), SerializeBool(IsArrested)));
            stringBuilder.AppendLine(SerializeTabPropAssignmentComma(nameof(Height), Height.ToString()));
            stringBuilder.AppendLine(SerializeTabPropAssignmentComma(nameof(Weight), Weight.ToString()));
            stringBuilder.AppendLine(SerializeTabPropAssignmentComma(nameof(Nationality), SerializeString(Nationality)));
            stringBuilder.AppendLine("}");

            return stringBuilder.ToString();
        }
    }
}
