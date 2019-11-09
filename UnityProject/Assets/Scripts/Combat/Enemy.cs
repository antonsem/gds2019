using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField]
    private float delay = 1;
    [SerializeField]
    private bool canAttack = true;

    public Enemy(int _energy, List<Attack> _attacks)
    {
        Energy = _energy;
        attacks = _attacks;
    }

    void Awake()
    {
        attacks = new List<Attack>();
    }

    public virtual void Attack(Action<int> callback = null)
    {
        CoroutineStarter.Instance.StartCoroutine(AttackCoroutine(callback));
    }

    private IEnumerator AttackCoroutine (Action<int> callback)
    {
        yield return new WaitForSeconds(delay);
        List<Attack> possibleAttacks = attacks.FindAll(x => x.EnergyCost < energy);
        if (possibleAttacks.Count == 0)
        {
            Surrender();
            yield break;
        }

        Attack chosenAttack = possibleAttacks[UnityEngine.Random.Range(0, possibleAttacks.Count)];
        energy -= chosenAttack.EnergyCost;
        int damage = UnityEngine.Random.Range(chosenAttack.LowerRange, chosenAttack.UpperRange + 1);

        callback?.Invoke(damage);
    }

    protected override void Die()
    {
        canAttack = false;
        base.Die();
    }

    private void Surrender()
    {
        canAttack = false;
        Debug.LogError("Not implemented yet. - Surrender() method", this);
    }

    public bool CanAttack()
    {
        return canAttack;
    }
}
