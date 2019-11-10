using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField]
    private int maxEnergy;
    [SerializeField]
    protected int energy;

    public int Energy
    {
        get => energy;
        //set => { energy = value; Even }
        set
        {
            energy = value;
            Events.Instance.enemyEnergyUpdated.Invoke(energy);
        }
    }
    public int MaxEnergy { get => maxEnergy; set => maxEnergy = value; }

    public virtual void TakeDamage(int damage)
    {
        energy -= damage;
        if (energy <= 0)
            Die();
    }

    protected virtual void Die()
    {

    }

    /*public void RestoreEnergy(int restoredEnergy)
    {
        energy += restoredEnergy;
        energy = Mathf.Min(energy, maxEnergy);
    }*/

    public void OnBeforeSerialize()
    {
    }

    public void OnAfterDeserialize()
    {
        energy = maxEnergy;
    }
}
