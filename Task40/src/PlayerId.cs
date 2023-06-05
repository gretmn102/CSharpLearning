namespace App
{
    using System.Diagnostics.CodeAnalysis;

    // Зачем упаковывать `GUID` в какой-то `PlayerId`? Ну, хочется.
    // Я даже не уверен, что правильно упаковал его.
    // По-идеи, `Dictionary` полагается на `Equals` и `GetHashCode`, вот их пробросил через Guid
    readonly struct PlayerId : IComparable<PlayerId>, IEquatable<PlayerId>
    {
        public Guid Guid { get; }

        public static PlayerId NewPlayerId()
        {
            return new(Guid.NewGuid());
        }

        public PlayerId()
        {
            Guid = new();
        }

        public PlayerId(Guid guid)
        {
            Guid = guid;
        }

        public override readonly int GetHashCode()
        {
            return Guid.GetHashCode();
        }

        public override string ToString()
        {
            return Guid.ToString();
        }

        public bool Equals(PlayerId other)
        {
            // throw new NotImplementedException();
            // Guid.Equals(other.Guid);
            return Guid.Equals(other.Guid);
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return obj is PlayerId id && Equals(id);
        }

        public int CompareTo(PlayerId other)
        {
            return Guid.CompareTo(other);
        }

        public static bool operator ==(PlayerId a, PlayerId b)
        {
            return a.Guid == b.Guid;
        }

        public static bool operator !=(PlayerId a, PlayerId b)
        {
            return a.Guid != b.Guid;
        }
}
}
