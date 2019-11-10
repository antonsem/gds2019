using ExtraTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour,ITrigger
{

   

    public void Trigger()
    {
        PopUp.Instance.Register("Zony: Everytihng here cost energy, movement, attacks, trades, connections.. so please if I forgot about my energy level remind it to me.. or i will shut down and thiefs will crush me to parts.");
        PopUp.Instance.Register("Zony: I am more or less a loner and trying to avoid contact with others. But sometime it is sadly needed. I can comunicate with other robots via ethernet cable - Yes since civilization is gone the wi-fi sucks! If there is oportunity to comunicate with someone the option will be displayed in upper part of monitor. You run my dial up protocol by SPACE button.");
        Destroy(transform.gameObject);
    }
}
