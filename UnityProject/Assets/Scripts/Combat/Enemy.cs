using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField]
    private float delay = 1;

    void Awake()
    {
        attacks = new List<Attack>();
    }

    public virtual void Attack(Character target, Action callback = null)
    {
        //start coroutine
    }

    private IEnumerator AttackCoroutine(Character target, Action callback)
    {
        yield return new WaitForSeconds(delay);
        List<Attack> possibleAttacks = attacks.FindAll(x => x.energyCost < energy);
        if (possibleAttacks.Count == 0)
        {
            Surrender(callback);
            yield break;
        }

        Attack chosenAttack = possibleAttacks[UnityEngine.Random.Range(0, possibleAttacks.Count)];
        energy -= chosenAttack.energyCost;
        target.TakeDamage(UnityEngine.Random.Range(chosenAttack.lowerRange, chosenAttack.upperRange + 1));

        callback?.Invoke();
    }

    private void Surrender(Action callback)
    {
        callback?.Invoke();
        Debug.LogError("Not implemented yet. - Surrender() method", this);
    }
}
