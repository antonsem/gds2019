using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button creditsButton;
    [SerializeField]
    private Button exitButton;
    [SerializeField]
    private GameObject credits;

    private void Awake()
    {
        playButton.onClick.AddListener(OnPlay);
        creditsButton.onClick.AddListener(OnCredits);
        exitButton.onClick.AddListener(OnExit);
    }

    private void OnPlay()
    {
        this.gameObject.SetActive(false);
        TemporarySceneSwitcher.Instance.SwitchToGame();
    }

    private void OnCredits()
    {
        credits.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void OnExit()
    {
        Application.Quit();
    }
}
