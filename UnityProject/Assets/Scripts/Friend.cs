using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtraTools;

public class Friend : MonoBehaviour, IInteratable
{
    [SerializeField]
    private Companion companion;
    [SerializeField]
    private PlayerStats stats;

    public void Interact()
    {
        PopUp.Instance.Register("Can I join you? Pleasepleaseplease!!! I will be super silent and won't bother your! Promise!!!", companion.Image, 
            new MessageButton("Sure, why not", Yes), 
            new MessageButton("NO WAY! Fuck off!", No));
    }

    private void No()
    {
        PopUp.Instance.Register("Fuck you! I didn't want to join you anyway!!!", companion.Image, new MessageButton("K...", null));
    }

    private void Yes()
    {
        PopUp.Instance.Register("OMGOMGOMG! Thank you! That is very exciting!!!", companion.Image, new MessageButton("No problem bruh", Join));
    }

    private void Join()
    {
        stats.AddCompanion(companion);
        gameObject.SetActive(false);
    }
}
