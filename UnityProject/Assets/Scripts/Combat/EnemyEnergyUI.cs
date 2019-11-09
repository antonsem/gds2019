using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyEnergyUI : MonoBehaviour
{
    private Enemy enemy;
    [SerializeField]
    private TextMeshProUGUI energyIndicator;

    private void OnEnable()
    {
        enemy = CombatManager.enemy;
        BatteryLevelUpdated(0);
        Events.Instance.enemyEnergyUpdated.AddListener(BatteryLevelUpdated);
    }


    private void OnDisable()
    {
        Events.Instance.enemyEnergyUpdated.RemoveListener(BatteryLevelUpdated);
    }

    private void BatteryLevelUpdated(int level)
    {
        energyIndicator.text = string.Format("{0} / {1}", enemy.Energy.ToString(), enemy.MaxEnergy.ToString());
    }

}
