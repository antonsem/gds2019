using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;
    [SerializeField]
    private PlayerStats playerStats;
    [SerializeField]
    private float chanceForEnemyToStart = 0.1f;

    public void Fight()
    {
        if (UnityEngine.Random.Range(0, 1) <= chanceForEnemyToStart)
            EnemyAttacks();

        while (playerStats.Energy > 0 && enemy.CanAttack())
        {
            PlayerAttacks();
            if (!enemy.CanAttack())
                break;

            EnemyAttacks();
        }
    }

    private void PlayerAttacks()
    {
        Attack chosenAttack = ChooseAttack(playerStats.Attacks);
        int damage = UnityEngine.Random.Range(chosenAttack.lowerRange, chosenAttack.upperRange + 1);

        enemy.TakeDamage(damage);
    }

    private void EnemyAttacks()
    {
        if (enemy.CanAttack())
        {
            Action<int> action = PlayerTakesDamage;
            enemy.Attack(action);
        }
    }

    private void PlayerTakesDamage(int damage)
    {
        playerStats.Energy -= damage;
        if (playerStats.Energy <= 0)
            PlayerDies();
    }

    private Attack ChooseAttack(List<Attack> attacks)
    {
        //TODO
        Debug.Log("TODO");
        return attacks[0];
    }

    private void PlayerDies()
    {

    }
}
