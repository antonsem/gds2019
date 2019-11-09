using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour, IInteratable
{
    public void Interact()
    {
        Debug.LogFormat("A very interesting {0}!", name);
    }
}
