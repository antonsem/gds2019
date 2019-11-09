using UnityEngine;
using ExtraTools;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private PlayerStats playerStats;

    private void OnEnable()
    {
        Events.Instance.gameOver.AddListener(GameOver);
    }

    private void GameOver()
    {
        playerStats.CanMove = false;

        PopUp.Instance.Register("You died in a very, very horrible way!");
    }
}
