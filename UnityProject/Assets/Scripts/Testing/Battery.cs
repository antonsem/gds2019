using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtraTools;

public class Battery : MonoBehaviour, ITrigger
{
    [SerializeField]
    private float AdditionalCapacity = 5f;
    [SerializeField]
    private PlayerStats playerStats;
    [SerializeField]
    private Sprite img;
    public bool Additional = false;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Trigger()
    {
        if (Additional)
        {
            PopUp.Instance.Register("You found the additional BATTERY!! This bad boy gives you additional capacity of " + AdditionalCapacity + " Energy!!", img);
            
            playerStats.MaxEnergy += AdditionalCapacity;

        }
        else
        {
            PopUp.Instance.Register("You found the BATTERY!! You recharged " + AdditionalCapacity + "  Eneregy!!", img);
        }

        if (audioSource != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
            StartCoroutine(destroyDelay(audioSource.clip.length));
        }
        else
        {
            StartCoroutine(destroyDelay(0));
        }
        playerStats.Energy += AdditionalCapacity;
        
      
    }
    IEnumerator destroyDelay(float sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(transform.gameObject);
    }
}
