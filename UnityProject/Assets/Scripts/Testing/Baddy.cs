using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtraTools;

public class Baddy : MonoBehaviour, IInteratable
{
    [SerializeField]
    private Enemy enemy;

    public void Interact()
    {
        PopUp.Instance.Register("Come at me bruh!", null, new MessageButton("Nah...", null), new MessageButton("You asked for it bruh!", DoFight));
    }

    private void DoFight()
    {
        CombatManager.enemy = enemy;
        CombatManager.Instance.Fight();
    }
}
