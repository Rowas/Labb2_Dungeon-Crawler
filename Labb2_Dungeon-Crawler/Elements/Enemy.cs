﻿abstract class Enemy : LevelElements
{
    public string Name { get; set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public int DamageDices { get; set; }
    public int dmgDiceSides { get; set; }
    public int dmgDiceModifier { get; set; }
    public int DefenseDice { get; set; }
    public int defDiceSides { get; set; }
    public int defDiceModifier { get; set; }
    public bool IsDead { get; set; }

    public void DistanceCheck(List<LevelElements> elements)
    {
        IsVisible = false;
        for (int i = -5; i < 6; i++)
        {
            for (int j = -5; j < 6; j++)
            {
                if (elements.Any(b => b.Position == (Position.Item1 + i, Position.Item2 + j)) == true)
                {
                    foreach (var element in elements)
                    {
                        if (element.Position == (Position.Item1 + i, Position.Item2 + j))
                        {
                            if (element is Player)
                            {
                                IsVisible = true;
                            }
                        }
                    }
                }
            }
        }
    }

    public (int, string) Attack()
    {
        Dice enemyDamage = new Dice(DamageDices, dmgDiceSides, dmgDiceModifier);
        
        int eDmg = enemyDamage.Throw();

        string eDmgDice = enemyDamage.ToString();

        return (eDmg, eDmgDice);
    }

    public (int, string) Defend()
    {
        Dice enemyDefend = new Dice(DefenseDice, defDiceSides, defDiceModifier);

        int eDef = enemyDefend.Throw();

        string eDefDice = enemyDefend.ToString();

        return (eDef, eDefDice);
    }
    public void Die(List<LevelElements> elements)
    {
        elements.Remove(this);
    }

    abstract public void Update(List<LevelElements> elements);
}
