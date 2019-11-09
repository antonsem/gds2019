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
    private List<Attack> attacks;
    private float rotationSpeed = 25;
    [SerializeField]
    private bool canMove = true;

    public float Energy { get => energy; set => energy = value; }
    public float MaxEnergy { get => maxEnergy; set => maxEnergy = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public List<Attack> Attacks { get => attacks; set => attacks = value; }

    public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }
    public bool CanMove { get => canMove; set => canMove = value; }

}
