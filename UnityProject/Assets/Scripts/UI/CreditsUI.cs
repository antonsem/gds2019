using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreditsUI : MonoBehaviour
{
    [SerializeField]
    private Button backButton;
    [SerializeField]
    private GameObject menu;

    private void Awake()
    {
        backButton.onClick.AddListener(OnBack);
    }

    private void OnBack()
    {
        menu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
