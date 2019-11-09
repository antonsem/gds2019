using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergyScaler : MonoBehaviour
{
    [SerializeField]
    private PlayerStats stats;
    [SerializeField]
    private Transform batteryLiquid;
    private Vector3 defaultScale = Vector3.one;
    private bool init = false;

    private void OnEnable()
    {
        if(!init)
        { 
            defaultScale = batteryLiquid.localScale;
            init = true;
        }
        
        ChargeUpdated(1);
        Events.Instance.energyUpdated.AddListener(ChargeUpdated);
    }

    private void OnDisable()
    {
        Events.Instance.energyUpdated.RemoveListener(ChargeUpdated);
    }

    private void ChargeUpdated(float ammount)
    {
        Vector3 scale = batteryLiquid.localScale;
        scale.z = stats.Energy / stats.MaxEnergy * defaultScale.z;
        batteryLiquid.localScale = scale;
    }
}
