﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : ScriptableObject
{
    [SerializeField]
    private int maxEnergy;
    public int energy;
    [SerializeField]
    protected List<Attack> attacks;

    public virtual void TakeDamage(int damage)
    {
        energy -= damage;
        if (energy <= 0)
            Die();
    }

    protected void Die()
    {
        Debug.LogError("Not implemented yet. - Die() method", this);
    }

    public void RestoreEnergy(int restoredEnergy)
    {
        energy += restoredEnergy;
        energy = Mathf.Min(energy, maxEnergy);
    }

}
