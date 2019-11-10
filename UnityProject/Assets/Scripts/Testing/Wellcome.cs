using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtraTools;

public class Wellcome : MonoBehaviour, ITrigger
{
    public Sprite img;
    public void Trigger()
    {
        StartCoroutine(message());
    }

    IEnumerator message()
    {
        yield return new WaitForSeconds(2);
        PopUp.Instance.Register("Zony: I couldn't believe my circruits first too, but its seems like the rumor is true. There is a lost puppy somewhere there in the forest, and if I find it i will be famous. The guy with the puppy. I am going for the ADVANTURE!",img);
        Destroy(transform.gameObject);
    }
}
