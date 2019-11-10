using ExtraTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FriendlyFat : MonoBehaviour,IInteratable
{
    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private Companion companion;
    [SerializeField]
    private PlayerStats stats;

    private bool wantToTalk = true;
    private bool talkedBefore = false;

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
        if (wantToTalk)
        {
            if (!talkedBefore)
            {
                PopUp.Instance.Register("Oh hi! How are you? What are you doing here?", null,
                    new MessageButton("Hi there! I'm ona very important quest, that concerns puppies!", gentleResponse),
                    new MessageButton("None of your business!", rudeResponse));
            }
            else
            {
                PopUp.Instance.Register("So did you though about my offer? I can upgrade your battery by 10, and I can assist you in battle, but I will drain some of your enegry as we travel.", null,
                    new MessageButton("Not yet, I need some more time", LetMeThink),
                    new MessageButton("Sure, hop on!", GentleResponse_2),
                    new MessageButton("NO! Why whould I want that?", rudeResponse));
            }
        }
        else
        {
            PopUp.Instance.Register("It't none of my business");
        }
    }

    public void gentleResponse()
    {
        PopUp.Instance.Register("Oh really? That is so cool! I love puppies! Can I join you? You will need to carry me though... But I can upgrade your battery by 10, and I can assist you in battle!", null,
                new MessageButton("Sure, hop on!", GentleResponse_2),
                new MessageButton("Hmm... Let me think abou it.", LetMeThink),
                new MessageButton("NO! Why whould I want that?", rudeResponse));
    }

    private void GentleResponse_2()
    {
        PopUp.Instance.Register("Wow! That is awesome! Thank you very much!");
        stats.AddCompanion(companion);
    }

    private void LetMeThink()
    {
        PopUp.Instance.Register("OK, ket me know when you make up your mind.");
        talkedBefore = true;
    }

    public void rudeResponse()
    {
        PopUp.Instance.Register("Well that wasn't very nice but OK, as you wish!");
        wantToTalk = false;
    }

    public void RudeResponse_2()
    {
        PopUp.Instance.Register("As you wish. It seems like we won't get along anyway. And it is none of my busness after all.");
        wantToTalk = false;
    }

    public void puppy()
    {
        PopUp.Instance.Register("Oh really? I head the rummors too, but honestly dont belive it. But I will move away for you ;)", null);
        gameObject.SetActive(false);
    }
}
