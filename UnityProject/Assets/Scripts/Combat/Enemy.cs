using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    void Awake()
    {
        attacks = new List<Attack>();
    }

    public void Attack(int damage, Character target)
    {
        List<Attack> possibleAttacks = attacks.FindAll(x => x.energyCost < energy);
        if (possibleAttacks.Count == 0)
        {
            Surrender();
            return;
        }

        Attack chosenAttack = possibleAttacks[Random.Range(0, possibleAttacks.Count)];
        energy -= chosenAttack.energyCost;
        target.TakeDamage(Random.Range(chosenAttack.lowerRange, chosenAttack.upperRange + 1));
    }

    private void Surrender()
    {
        Debug.LogError("Not implemented yet. - Surrender() method", this);
    }
}
