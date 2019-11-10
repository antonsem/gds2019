using ExtraTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevrageInteractions : MonoBehaviour, IInteratable
{
    [SerializeField] 
    private PlayerStats stats;
    bool opened;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Interact()
    {
        stats.CanMove = false;
        if (audioSource != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
            StartCoroutine(InteractDelay(audioSource.clip.length));
        }
        else
        {
            StartCoroutine(InteractDelay(0));
        }
    }

    IEnumerator InteractDelay(float sec)
    {
        yield return new WaitForSeconds(sec);
        if (opened)
        {
            PopUp.Instance.Register("This doors will close it self automaticly when the time comes, thank you sir.", null);
        }
        else
        {
            PopUp.Instance.Register("This is terminal for main entrence door. Please use your card to identify", null, new MessageButton("Here is my card.", inspectCard), new MessageButton("I dont have a access card. :-(", noCard));
        }
    }
    private void inspectCard()
    {
        if(stats.card)
        {
            accessGranted();
        }
        else
        {
            PopUp.Instance.Register("This is not valid card!", null);
            noCard();
        }
    }

    private void accessGranted()
    {
        PopUp.Instance.Register("Thank you for you authorization. Door will open in second.", null);
       foreach(GameObject door in GameObject.FindGameObjectsWithTag("big_doors"))
        {
            door.GetComponent<Animator>().SetTrigger("Open");
        }
        opened = true;
    }
    private void noCard()
    {
        PopUp.Instance.Register("Please leave immidietly only authorized personal !", null);
    }
}
