internal class Program
{
    private static void Main()
    {
        int heroMaxHp = 300;
        int heroHp = heroMaxHp;

        int bossHp = 3000;
        int bossDamage = 30;

        int roshamonCastHpCost = 100;
        int huganzakuraDamage = 100;
        int interdimensionalRiftHpRestore = 250;
        int fireballDamage = 100;
        int iceboltDamage = 100;

        bool roshamonIsSpawned = false;
        bool magicStaffIsCharged = false;
        while (true)
        {
            Console.WriteLine($"Ваши жизни — {heroHp}");
            Console.WriteLine($"Жизни босса — {bossHp}");

            Console.WriteLine("Выберите заклинание:");
            Console.WriteLine($"1) Рошамон – призывает теневого духа для нанесения атаки. Отнимает {roshamonCastHpCost}HP у игрока.");
            Console.WriteLine($"2) Хуганзакура — наносит {huganzakuraDamage} ед. урона. Может быть выполнен только после призыва теневого духа.");
            Console.WriteLine($"3) Межпространственный разлом – позволяет скрыться в разломе и восстановить {interdimensionalRiftHpRestore}HP. Урон босса по вам не проходит.");
            Console.WriteLine("4) Зарядить посох магией — позволяет кинуть фаербол или ледяной болт.");
            Console.WriteLine($"5) Кинуть фаерболл, который наносит {fireballDamage} ед. урона. Требует зарядить посох магией.");
            Console.WriteLine($"6) Кинуть ледяной болт, который отнимает {iceboltDamage} ед. урона. Требует зарядить посох магией.");

            string playerInput = Console.ReadLine() ?? "";
            switch (playerInput)
            {
                case "1":
                    Console.WriteLine("Вы призываете Рошамона!");
                    roshamonIsSpawned = true;
                    break;
                case "2":
                    if (!roshamonIsSpawned)
                    {
                        Console.WriteLine("Чтобы использовать Хуганазакуру, сперва нужно призвать Рошамона!");
                        Console.WriteLine();
                        continue;
                    }
                    bossHp -= huganzakuraDamage;
                    Console.WriteLine($"Вы велите использовать Рошамону его способность Хуганазакуру. Он ее использует и наносит врагу {huganzakuraDamage}!");
                    break;
                case "3":
                    interdimensionalRiftHpRestore += heroHp;
                    if (heroHp > heroMaxHp)
                    {
                        heroHp = heroMaxHp;
                    }
                    Console.WriteLine($"Вы скрываетесь в разломе и восстанавливаете {interdimensionalRiftHpRestore}. Враг пропускает свой ход.");
                    Console.WriteLine();
                    continue;
                case "4":
                    magicStaffIsCharged = true;
                    Console.WriteLine("Вы заряжаете посох!");
                    break;
                case "5":
                    if (!magicStaffIsCharged)
                    {
                        Console.WriteLine("Сперва нужно зарядить посох, чтобы пуляться фаерболами!");
                        Console.WriteLine();
                        continue;
                    }
                    magicStaffIsCharged = false;
                    bossHp -= fireballDamage;
                    Console.WriteLine($"Вы поджигаете босса фаерболом, что наносит ему {fireballDamage}HP!");
                    break;
                case "6":
                    if (!magicStaffIsCharged)
                    {
                        Console.WriteLine("Сперва нужно зарядить посох, чтобы пуляться ледяными болтами!");
                        Console.WriteLine();
                        continue;
                    }
                    magicStaffIsCharged = false;
                    bossHp -= iceboltDamage;
                    Console.WriteLine($"Вы поджигаете босса фаерболом, что наносит ему {iceboltDamage}HP!");
                    break;
                default:
                    Console.WriteLine($"{playerInput} — неизвестная команда!");
                    Console.WriteLine();
                    continue;
            }

            if (!(bossHp > 0))
            {
                Console.WriteLine("Босс погиб, победа!");
                break;
            }

            heroHp -= bossDamage;
            Console.WriteLine($"Босс наносит {bossDamage}HP!");

            if (!(heroHp > 0))
            {
                Console.WriteLine("К сожалению, герой погибает.");
                break;
            }

            Console.WriteLine();
        }
    }
}
