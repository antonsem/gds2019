﻿using ExtraTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour,ITrigger
{

   

    public void Trigger()
    {
        PopUp.Instance.Register("Zony: I am more or less a loner and trying to avoid contact with others. But sometime it is sadly needed. I can comunicate with other robots via ethernet cable - Yes since civilization is gone the wi-fi sucks! If there is oportunity to comunicate with someone the option will be displayed in lover part of monitor. You run my dial up protocol by SPACE button.");
        Destroy(transform.gameObject);
    }
}
