using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "GDS/Enemy")]
public class Enemy : Character
{
    [SerializeField]
    private float delay = 1;
    [SerializeField]
    private bool canAttack = true;
    [SerializeField]
    private List<Attack> attacks = new List<Attack>();

    public Enemy(int _energy, List<Attack> _attacks)
    {
        Energy = _energy;
        attacks = _attacks;
    }

    public virtual void Attack(Action<int, Attack> callback = null)
    {
        CoroutineStarter.Instance.StartCoroutine(AttackCoroutine(callback));
    }

    private IEnumerator AttackCoroutine(Action<int, Attack> callback)
    {
        yield return new WaitForSeconds(delay);
        List<Attack> possibleAttacks = attacks.FindAll(x => x.EnergyCost < Energy);
        if (possibleAttacks.Count == 0)
        {
            Surrender();
            yield break;
        }

        Attack chosenAttack = possibleAttacks[UnityEngine.Random.Range(0, possibleAttacks.Count)];
        Energy -= chosenAttack.EnergyCost;
        int damage = UnityEngine.Random.Range(chosenAttack.LowerRange, chosenAttack.UpperRange + 1);

        callback?.Invoke(damage, chosenAttack);
    }

    protected override void Die()
    {
        canAttack = false;
        base.Die();
    }

    public override void TakeDamage(int damage)
    {
        Energy -= damage;
        if (Energy <= 0)
        {
            Die();
            return;
        }

        List<Attack> possibleAttacks = attacks.FindAll(x => x.EnergyCost < Energy);
        if (possibleAttacks.Count == 0)
            canAttack = false;
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
