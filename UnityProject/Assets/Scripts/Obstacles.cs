using ExtraTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour,ITrigger
{

    [SerializeField]
    Sprite spr;

    public void Trigger()
    {
        PopUp.Instance.Register("Zony: Everything here cost energy, movement, attacks, trades, connections… so please if I forgot about my energy level remind it to me… or I will shut down and thiefs will crush me to parts.");
        PopUp.Instance.Register("Zony: I am more or less a loner and trying to avoid contact with others. But sometime it is sadly needed. I can comunicate with other robots via ethernet cable. Yes since civilization is gone the wi-fi sucks! If there is an oportunity to communicate with someone, the option will be displayed in upper part of the monitor. You run my dial up protocol by the SPACE button.");
        Destroy(transform.gameObject);
    }
}
