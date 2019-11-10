using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectedButtonHolder : MonoBehaviour
{
    [SerializeField]
    private PlayerStats playerStats;
    //private Selectable lastSelected;

    private void OnEnable()
    {
        playerStats.CanMove = false;
        //lastSelected = EventSystem.current.currentSelectedGameObject?.GetComponent<Selectable>();
        //EventSystem.current.SetSelectedGameObject(null);
    }

    private void OnDisable()
    {
        playerStats.CanMove = playerStats.Energy > 0;
        //if (lastSelected)
        //    lastSelected.Select();
    }
}
