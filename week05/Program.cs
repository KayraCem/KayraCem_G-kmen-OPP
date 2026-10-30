// ===== PART A =====
// A1: cevap 5, 11/4 = 2 (küsurat umursanmıyor), 11%4 = 3    2+3 = 5
// A2: cevap Hurt, HP = 45 >50 false , 45 >20 hurt durumda
// A3: cevap 4, 0 - 1 = -1 , -1 + 2 = 1 , 1 - 1 = 0, 0 + 4 = 4 , i = 5 i <= 4 döngü bitti
// A4: cevap 14, 3 x 2=6    a=6, a +1 = 7 , 7 x 2 = 14 

// ===== B1 =====
{
    int baseDamage = 40;
    int armor = 15;
    int level = 4;

    int damage = baseDamage - armor;
    if (level >= 5) damage += 10;
    if (damage < 1) damage = 1;

    string label;
    if (damage >= 30) label = "Strong hit";
    else if (damage >= 10) label = "Normal hit";
    else label = "Weak hit";

    Console.WriteLine($"Damage: {damage} ({label})");
}

// ===== B2 =====
{
    int gold = 120;
    int choice = 2;

    string itemName = "";
    int price = 0;

    switch (choice)
    {
        case 1:
            itemName = "Sword";
            price = 100;
            break;
        case 2:
            itemName = "Bow";
            price = 80;
            break;
        case 3:
            itemName = "Potion";
            price = 25;
            break;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }

    if (choice >= 1 && choice <= 3)
    {
        if (gold >= price)
        {
            gold -= price;
            Console.WriteLine($"You bought a {itemName}! Gold left: {gold}");
        }
        else
        {
            Console.WriteLine($"You need {price - gold} more gold.");
        }
    }
}

// ===== B3 =====
{
    for (int wave = 1; wave <= 30; wave++)
    {
        if (wave % 3 == 0 && wave % 5 == 0)
        {
            Console.WriteLine($"Wave {wave}: BOSS");
        }
        else if (wave % 3 == 0)
        {
            Console.WriteLine($"Wave {wave}: Slime");
        }
        else if (wave % 5 == 0)
        {
            Console.WriteLine($"Wave {wave}: Bat");
        }
        else
        {
            Console.WriteLine($"Wave {wave}: empty");
        }
    }
}

// ===== B4 =====
{
    int level = 1;
    int xp = 0;
    int fights = 0;

    while (level < 5)
    {
        xp += 35;
        fights++;

        if (xp >= 100)
        {
            xp -= 100;
            level++;
            Console.WriteLine($"LEVEL UP! Now level {level}");
        }
    }

    Console.WriteLine($"Reached level {level} after {fights} fights (xp left: {xp})");
}

// ===== B5 =====
{
    int Clamp(int value, int min, int max)
    {
        if (value < min)
        {
            return min;
        }
        else if (value > max)
        {
            return max;
        }
        else
        {
            return value;
        }
    }

    // Test
    Console.WriteLine(Clamp(150, 0, 100));
    Console.WriteLine(Clamp(-20, 0, 100));
    Console.WriteLine(Clamp(55, 0, 100));

    // Potion
    int hp = 80;
    hp = Clamp(hp + 50, 0, 100);
    Console.WriteLine($"HP after potion: {hp}");
}

// ===== B6 =====
{
    string GetRank(int score)
    {
        if (score >= 1000)
        {
            return "Gold";
        }
        else if (score >= 500)
        {
            return "Silver";
        }
        else if (score >= 1)
        {
            return "Bronze";
        }
        else
        {
            return "No medal";
        }
    }

    // Test with a for loop
    for (int score = 0; score <= 1250; score += 250)
    {
        Console.WriteLine($"Score {score}: {GetRank(score)}");
    }
}

// ===== B7 =====
{
    int Attack(int hp, int damage)
    {
        hp -= damage;
        if (hp < 0)
        {
            hp = 0;
        }
        return hp;
    }

    bool IsAlive(int hp)
    {
        return hp > 0;
    }

    // Starting values
    int playerHp = 150;
    int bossHp = 120;
    int turn = 0;

    while (IsAlive(playerHp) && IsAlive(bossHp))
    {
        turn++;

        // Player attacks first
        bossHp = Attack(bossHp, 25);

        // Boss can only attack if still alive
        if (IsAlive(bossHp))
        {
            int bossDamage = 25;

            // Every 3rd turn, double damage
            if (turn % 3 == 0)
            {
                bossDamage *= 2;
            }

            playerHp = Attack(playerHp, bossDamage);
            Console.WriteLine($"Turn {turn} | Boss: {bossHp} | Player: {playerHp}");
        }
        else
        {
            Console.WriteLine($"Turn {turn} | Boss: {bossHp}");
        }
    }

    // Winner
    if (IsAlive(playerHp))
    {
        Console.WriteLine($"You win in {turn} turns! HP left: {playerHp}");
    }
    else
    {
        Console.WriteLine($"Boss wins in {turn} turns! HP left: {bossHp}");
    }
}

// ===== B8 =====
{
    string Hint(int guess, int secret)
    {
        if (guess < secret)
        {
            return "Too low";
        }
        else if (guess > secret)
        {
            return "Too high";
        }
        else
        {
            return "Correct!";
        }
    }

    // Game settings
    int secret = 42;
    int triesLeft = 5;
    int attempts = 0;
    bool won = false;

    // Game loop
    while (triesLeft > 0 && !won)
    {
        Console.Write($"Guess ({triesLeft} tries left): ");
        int guess = int.Parse(Console.ReadLine()!);

        attempts++;

        string hint = Hint(guess, secret);
        Console.WriteLine(hint);

        if (hint == "Correct!")
        {
            won = true;
        }

        triesLeft--;
    }

    // Game result
    if (won)
    {
        Console.WriteLine($"You found it in {attempts} tries!");
    }
    else
    {
        Console.WriteLine($"You lost! The number was {secret}.");
    }
}
