using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BatteryUI : MonoBehaviour
{
    [SerializeField]
    private PlayerStats stats;
    [SerializeField]
    private TextMeshProUGUI batteryIndicator;

    private void OnEnable()
    {
        BatteryLevelUpdated(0);
        Events.Instance.energyUpdated.AddListener(BatteryLevelUpdated);
    }

    private void OnDisable()
    {
        Events.Instance.energyUpdated.RemoveListener(BatteryLevelUpdated);
    }

    private void BatteryLevelUpdated(float level)
    {
        batteryIndicator.text = string.Format("{0} / {1}", stats.Energy.ToString("0."), stats.MaxEnergy.ToString("0."));
    }
}
