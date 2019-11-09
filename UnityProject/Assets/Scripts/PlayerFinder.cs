using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerFinder : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera vCam;
    private Transform _player;
    private Transform player
    {
        get
        {
            if (!_player)
                _player = FindObjectOfType<Player>()?.transform;

            return _player;
        }
    }

    private void Update()
    {
        if (!vCam.Follow)
            vCam.Follow = player;
        if (!vCam.LookAt)
            vCam.LookAt = player;
    }
}
