using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour, IInteratable
{
    public void Interact()
    {
        ExtraTools.PopUp.Instance.Register(string.Format("A very interesting {0}!", name), null, 
            new ExtraTools.MessageButton("OK! :D", null), 
            new ExtraTools.MessageButton("But is it though?", Answer));
    }

    private void Answer()
    {
        ExtraTools.PopUp.Instance.Register("But of course it is!");
    }
}
