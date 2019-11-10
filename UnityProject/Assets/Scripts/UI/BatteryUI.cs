using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BatteryUI : MonoBehaviour
{
    [SerializeField]
    private PlayerStats stats;
    [SerializeField]
    private TextMeshProUGUI batteryIndicator;
    [SerializeField]
    private Slider energyLevel;


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
        energyLevel.value = stats.Energy / stats.MaxEnergy;
    }
}
