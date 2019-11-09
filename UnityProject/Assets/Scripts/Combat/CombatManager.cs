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
    [SerializeField]
    private Action playerDies;
    [SerializeField]
    private Action enemyDies;
    [SerializeField]
    private float delay = 1.5f;

    private void Awake()
    {
        /*List<Attack> attacks = new List<Attack>()
        {
            new Attack(5, 10, 20, "attack 1", ""),
            new Attack(15, 35, 65, "attack 2", "")
        };
        PlayerStats ps = new PlayerStats();
        ps.Attacks = attacks;
        ps.Energy = 100;

        Enemy enemy = new Enemy(80, attacks);


        this.enemy = enemy;
        playerStats = ps;*/
    }

    public CombatManager(PlayerStats playerStats, Enemy enemy, Action playerDies, Action enemyDies)
    {
        this.playerStats = playerStats;
        this.enemy = enemy;
        this.playerDies = playerDies;
        this.enemyDies = enemyDies;
    }

    public void Fight()
    {
        if (UnityEngine.Random.Range(0.0f, 1.0f) <= chanceForEnemyToStart)
            EnemyAttacks();
        else
            StartCoroutine(PlayerAttacks());
    }

    private IEnumerator PlayerAttacks()
    {
        List<ExtraTools.MessageButton> messageButtons = new List<ExtraTools.MessageButton>(9);

        foreach (Attack attack in playerStats.Attacks)
        {
            Attack temp = attack;
            messageButtons.Add(new ExtraTools.MessageButton(AttackStringFormatter(attack), () => DealDamageToEnemy(temp)));
        }

        yield return new WaitForSeconds(delay);
        ExtraTools.PopUp.Instance.Register("Choose your attack:", null, messageButtons.ToArray());
    }

    private void EnemyAttacks()
    {
        if (enemy.CanAttack())
        {
            Action<int> action = PlayerTakesDamage;
            enemy.Attack(action);
        }
        if (playerStats.Energy > 0)
            StartCoroutine(PlayerAttacks());
    }

    private void PlayerTakesDamage(int damage)
    {
        Debug.Log($"The enemy dealt {damage} to the player.");
        playerStats.Energy -= damage;
        if (playerStats.Energy <= 0)
        {
            playerDies?.Invoke();
        }
    }

    private void DealDamageToEnemy(Attack attack)
    {
        int damage = UnityEngine.Random.Range(attack.LowerRange, attack.UpperRange + 1);

        enemy.TakeDamage(damage);
        if (!enemy.CanAttack())
        {
            enemyDies?.Invoke();
        }
        else
            EnemyAttacks();


        Debug.Log($"Player dealt {damage} damage to the enemy.");
    }

    private string AttackStringFormatter(Attack attack)
    {
        return $"{attack.Name}   damage: {attack.LowerRange} - {attack.UpperRange}   energy cost: {attack.EnergyCost}";
    }


}
