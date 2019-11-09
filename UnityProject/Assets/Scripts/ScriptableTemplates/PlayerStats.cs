using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "GDS/Player Stats")]
public class PlayerStats : ScriptableObject
{
    [SerializeField]
    private float maxEnergy = 100;
    [SerializeField]
    private float energy = 100;
    [SerializeField]
    private float moveSpeed = 1;
    [SerializeField]
    private float rotationSpeed = 25;
    [SerializeField]
    private bool canMove = true;
    [SerializeField]
    private float energyDrainingSpeed = 1;

    public float Energy
    {
        get => energy;
        set
        {
            if (value <= 0)
                Events.Instance.gameOver.Invoke();

            energy = Mathf.Clamp(value, 0, MaxEnergy);
        }
    }
    public float MaxEnergy { get => maxEnergy; set => maxEnergy = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }
    public bool CanMove { get => canMove; set => canMove = value; }
    public float EnergyDrainingSpeed { get => energyDrainingSpeed; set => energyDrainingSpeed = value; }
}
