using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtraTools;

public class AttackGiver : MonoBehaviour, IInteratable
{
    private AudioSource audio;
    [SerializeField]
    private PlayerStats playerStats;
    [SerializeField]
    private Attack betterAttack;
    [SerializeField]
    private Attack worseAttack;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void Interact()
    {
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
        PopUp.Instance.Register("Hey, you there! Do you want to learn some cool stuff? Just for 20 energy", null,
                                new MessageButton("Yeah, sure, show me everythink you can.", Yes),
                                new MessageButton("20 energy? How about 15?", Haggle),
                                new MessageButton("20 energy??? That's so expensive! I will give you 10.", Ridiculous),
                                new MessageButton("Sorry, I don't have spare energy.", No));
    }

    public void Yes()
    {
        playerStats.Attacks.Add(betterAttack);
        playerStats.Energy -= 20;
        PopUp.Instance.Register("New attack learned.", null);
        Destroy(gameObject);
    }
    public void No()
    {
        Destroy(gameObject);
    }

    public void Haggle()
    {
        playerStats.Attacks.Add(worseAttack);
        playerStats.Energy -= 15;
        PopUp.Instance.Register("I think I yan do it for 15. \nNew attack learned.", null);
        Destroy(gameObject);
    }

    public void Ridiculous()
    {
        PopUp.Instance.Register("Only 10 energy??? You must be crazy. Go away, I don't want to see you there.", null);
        Destroy(gameObject);
    }
}