namespace App
{
    public interface IBattlerActionResult { }

    public readonly struct SuccessfulAttack : IBattlerActionResult
    {
        public int ResultDamage { get; }

        public SuccessfulAttack(int resultDamage)
        {
            ResultDamage = resultDamage;
        }
    }

    public struct EnemyDodged : IBattlerActionResult { }

    public struct NotEnoughAngry : IBattlerActionResult { }

    public struct BattlerIsNotAngryable : IBattlerActionResult { }
}
