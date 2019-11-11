using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtraTools;
using TMPro;

public class CombatManager : Singleton<CombatManager>
{
    public static GameObject enemyVisual;
    public static Enemy enemy;
    [SerializeField]
    private PlayerStats playerStats;
    [SerializeField]
    private float chanceForEnemyToStart = 0.1f;
    [SerializeField]
    private Action enemyDies;
    [SerializeField]
    private float delay = 1.5f;

    private Action fightEnded;

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

    public void Fight(Action fightEnded)
    {
        this.fightEnded = fightEnded;

        if (UnityEngine.Random.Range(0.0f, 1.0f) <= chanceForEnemyToStart)
            EnemyAttacks();
        else
            StartCoroutine(PlayerAttacks());
    }

    private IEnumerator PlayerAttacks()
    {
        List<MessageButton> messageButtons = new List<MessageButton>(9);

        foreach (Attack attack in playerStats.Attacks)
        {
            Attack temp = attack;
            messageButtons.Add(new MessageButton(AttackStringFormatter(attack), () => DealDamageToEnemy(temp)));
        }

        yield return new WaitForSeconds(delay);
        PopUp.Instance.Register("Choose your attack:", null, messageButtons.ToArray());
    }

    private void EnemyAttacks()
    {
        if (enemy.CanAttack())
        {
            Action<int, Attack> action = PlayerTakesDamage;
            enemy.Attack(action);
        }
        else
        {
            Victory();
            return;
        }
        if (playerStats.Energy > 0)
            StartCoroutine(PlayerAttacks());
    }

    private void PlayerTakesDamage(int damage, Attack attack)
    {
        Debug.Log($"The enemy dealt {damage} to the player.");

        PopUp.Instance.Register($"The enemy used {attack.Name}. \nYou took {damage} point(s) of damage.", null);

        playerStats.Energy -= damage;
    }

    private void DealDamageToEnemy(Attack attack)
    {
        int damage = UnityEngine.Random.Range(attack.LowerRange, attack.UpperRange + 1);
        Debug.Log($"Player dealt {damage} damage to the enemy.");
        PopUp.Instance.Register($"The enemy took {damage} point(s) of damage.", null);
        playerStats.Energy -= attack.EnergyCost;
        enemy.TakeDamage(damage);
        if (!enemy.CanAttack())
        {
            enemyDies?.Invoke();
            Victory();
        }
        else
            EnemyAttacks();
    }

    public void Victory()
    {
        MessageButton messageButton = new MessageButton("Go back", TemporarySceneSwitcher.Instance.GetBackFromCombat);
        string message = "";
        if (enemy.Energy > 0)
            message = "The enemy has low energy and surrenders! Victory!";
        else
            message = "Congratulation, you have successfully defeated your enemy.";
            PopUp.Instance.Register(message, null, messageButton);
        fightEnded?.Invoke();
    }

    private string AttackStringFormatter(Attack attack)
    {
        return $"{attack.Name}   damage: {attack.LowerRange} - {attack.UpperRange}   energy cost: {attack.EnergyCost}";
    }


}
