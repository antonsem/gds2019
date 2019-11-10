using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtraTools;

public class Baddy : MonoBehaviour, IInteratable
{
    [SerializeField]
    private Enemy enemy;
    [SerializeField]
    private GameObject visual;
    [SerializeField]
    private Sprite img;
    [SerializeField]
    bool small = false;
    [SerializeField]
    private PlayerStats stats;
    [SerializeField]
    bool big = false;

    Enemy backup;
    private AudioSource audio;
    private void Start()
    {
         backup = enemy;
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
        if (big)
        {
            PopUp.Instance.Register("HAHAH!!! YOU WANT TO CHALLANGE ME?!?!?", img, new MessageButton("YES!", DoFight), new MessageButton("NO I change my mind.", null));
        }
        else
        if (small)
        { PopUp.Instance.Register("Dont even try to get close !! I will smash you!!.. or at least your wheels..!", img, new MessageButton("Ok little one try it!", DoFight), new MessageButton("Ok you look scaaaaary I am leaving", null)); }
        else
        {
            PopUp.Instance.Register("What do you want ?? Civilians have no access here! Go away.", img, new MessageButton("Ok I am leaving take it easy.", null), new MessageButton("LEt me pass!", letmePass));
        }
        }

    private void letmePass()
    {
        PopUp.Instance.Register("You? No way get out! Or I will crush you!", img, new MessageButton("Ok I am leaving take it easy.", null), new MessageButton("TRY IT!!!", DoFight));
    }
    private void DoFight()
    {
        CombatManager.enemy = enemy;
        CombatManager.enemyVisual = visual;
        TemporarySceneSwitcher.Instance.SwitchToCombat();
        CombatManager.Instance.Fight(dest);
    }
    void dest()
    {
        enemy = backup;
        gameObject.SetActive(false);
    }
}
