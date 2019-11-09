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

    void Awake()
    {
        attacks = new List<Attack>();
    }

    public virtual void Attack(Action<int> callback = null)
    {
        //start coroutine
    }

    private IEnumerator AttackCoroutine (Action<int> callback)
    {
        yield return new WaitForSeconds(delay);
        List<Attack> possibleAttacks = attacks.FindAll(x => x.energyCost < energy);
        if (possibleAttacks.Count == 0)
        {
            Surrender();
            yield break;
        }

        Attack chosenAttack = possibleAttacks[UnityEngine.Random.Range(0, possibleAttacks.Count)];
        energy -= chosenAttack.energyCost;
        int damage = UnityEngine.Random.Range(chosenAttack.lowerRange, chosenAttack.upperRange + 1);

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
