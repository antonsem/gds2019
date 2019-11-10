using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtraTools;

public class FatRobot : MonoBehaviour, IInteratable
{
    private AudioSource audio;
    [SerializeField]
    private PlayerStats stats;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
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
        PopUp.Instance.Register("What?", null, new MessageButton("Sir, could you please move a little bit ?", gentleResponse), new MessageButton("Move your fat ass! You are blocking the road!", rudeResponse));
    }

    public void gentleResponse()
    {
        PopUp.Instance.Register("Why so in rush?", null, new MessageButton("I am looking for a puppy!", puppy), new MessageButton("Not of your bussiness! Just move your ass!", rudeResponse));
    }
    public void rudeResponse()
    {
        PopUp.Instance.Register("OK! ok.. ok..I am moving.. dont need to be rude!", null);
        gameObject.SetActive(false);
    }

    public void puppy()
    {
        PopUp.Instance.Register("Oh really? I head the rummors too, but honestly dont belive it. But I will move away for you ;)", null);
        gameObject.SetActive(false);
    }


}
