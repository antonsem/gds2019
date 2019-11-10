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

    private AudioSource audio;
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
        PopUp.Instance.Register("Come at me bruh!", null, new MessageButton("Nah...", null), new MessageButton("You asked for it bruh!", DoFight));
    }
    private void DoFight()
    {
        CombatManager.enemy = enemy;
        CombatManager.enemyVisual = visual;
        TemporarySceneSwitcher.Instance.SwitchToCombat();
        CombatManager.Instance.Fight(Lose);
    }

    public void Lose()
    {
        Destroy(gameObject);
    }
}
