using ExtraTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour , ITrigger
{

    [SerializeField]
    private PlayerStats playerStats;
    [SerializeField]
    private Sprite img;

    bool called = false;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Trigger()
    {
        if (!called)
        {
            called = true;
            if (audioSource != null)
            {
                audioSource.PlayOneShot(audioSource.clip);
                StartCoroutine(destroyDelay(audioSource.clip.length));
                GetComponent<BoxCollider>().enabled = false;
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(destroyDelay(0));
            }
          
          
                PopUp.Instance.Register("I found the ACCESS CARD!! Sweet.", img);



            playerStats.card = true;
        }

    }
    IEnumerator destroyDelay(float sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(transform.gameObject);
    }
}
