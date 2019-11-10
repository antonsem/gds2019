using ExtraTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puppy : MonoBehaviour, IInteratable
{
    [SerializeField]
    private PlayerStats stats;
    [SerializeField]
    private AudioSource audio;

    public void Interact()
    {
        stats.CanMove = false;
        if (audio != null)
        {
            audio.PlayOneShot(audio.clip);
            StartCoroutine(InteractDelay(audio.clip.length));
        }
        else
        {
            StartCoroutine(InteractDelay(0));
        }
    }

    IEnumerator InteractDelay(float sec)
    {
        yield return new WaitForSeconds(sec);
        PopUp.Instance.Register("YOU DID IT! YOU MANAGED TO SAVE THE PUPPY!!! YOU ARE THE LEGEND!", null,
            new MessageButton("YEY!", null));
    }
}
