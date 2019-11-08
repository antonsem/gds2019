using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : ScriptableObject
{
    public int energy;
    public List<Attack> attacks;

    public void TakeDamage(int damage)
    {
        energy -= damage;
        if (energy <= 0)
            Die();
    }

    protected void Die()
    {
        Debug.LogError("Not implemented yet. - Die() method", this);
    }

}
