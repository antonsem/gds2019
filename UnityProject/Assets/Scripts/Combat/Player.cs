using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private const int maxNumberOfAttacks = 6; 

    void Awake()
    {
        attacks = new List<Attack>(maxNumberOfAttacks);
    }

    public void Attack(int indexOfAttack, Enemy target)
    {
        int damage = Random.Range(attacks[indexOfAttack].lowerRange, attacks[indexOfAttack].upperRange + 1);
        target.TakeDamage(damage);

        energy -= attacks[indexOfAttack].energyCost;
        if (energy <= 0)
            Die();
    }
}
