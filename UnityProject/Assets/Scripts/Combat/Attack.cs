﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "GDS/Attack")]
public class Attack : ScriptableObject
{
    [SerializeField]
    private int energyCost;
    [SerializeField]
    private int lowerRange;
    [SerializeField]
    private int upperRange;
    [SerializeField]
    private string _name;
    [SerializeField]
    private string description;

    public int EnergyCost { get => energyCost; set => energyCost = value; }
    public int LowerRange { get => lowerRange; set => lowerRange = value; }
    public int UpperRange { get => upperRange; set => upperRange = value; }
    public string Name { get => _name; set => _name = value; }
    public string Description { get => description; set => description = value; }

    public Attack(int _energyCost, int _lowerRange, int _upperRange, string _name, string _description)
    {
        energyCost = _energyCost;
        lowerRange = _lowerRange;
        upperRange = _upperRange;
        this._name = _name;
        description = _description;
    }
}
