using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtraTools;

public class Battery : MonoBehaviour, ITrigger
{
    [SerializeField]
    private float AdditionalCapacity = 5f;
    [SerializeField]
    private PlayerStats playerStats;
    [SerializeField]
    private Sprite img;
    public bool Additional = false;

    public void Trigger()
    {
        if (Additional)
        {
            PopUp.Instance.Register("You found the additional BATTERY!! This bad boy gives you additional capacity of " + AdditionalCapacity + " Energy!!", img);
            playerStats.MaxEnergy += AdditionalCapacity;
        }
        else
        {
            PopUp.Instance.Register("You found the BATTERY!! You recharged " + AdditionalCapacity + "  Eneregy!!", img);
        }
        playerStats.Energy += AdditionalCapacity;
        Destroy(transform.gameObject);
    }
}
