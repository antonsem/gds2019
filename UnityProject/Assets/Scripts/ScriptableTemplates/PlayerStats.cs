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
    [SerializeField]
    private float energyConsumption = 1;
    [SerializeField]
    private float baseEnergyConsumption = 1;
    [SerializeField]
    private List<Companion> companions = new List<Companion>();

    public float Energy
    {
        get => energy;
        set
        {
            if (value <= 0)
                Events.Instance.gameOver.Invoke();

            energy = Mathf.Clamp(value, 0, MaxEnergy);

            Events.Instance.energyUpdated.Invoke(energy);
        }
    }
    public float MaxEnergy { get => maxEnergy; set => maxEnergy = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public List<Attack> Attacks { get => attacks; set => attacks = value; }

    public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }
    public bool CanMove { get => canMove; set => canMove = value; }
    public float EnergyConsumption { get => energyConsumption; set => energyConsumption = value; }
    public float BaseEnergyConsumption { get => baseEnergyConsumption; set => baseEnergyConsumption = value; }
    public List<Companion> Companions { get => companions; private set => companions = value; }

    public void AddCompanion(Companion _companion)
    {
        if (!Companions.Contains(_companion))
        {
            Companions.Add(_companion);
            RecalculateEnergyConsuption();
        }
        else
            Debug.LogErrorFormat("Companion {0} is already in the party!", _companion.Name);
    }

    public void RemoveCompanion(Companion _companion)
    {
        if (Companions.Contains(_companion))
        {
            Companions.Remove(_companion);
            RecalculateEnergyConsuption();
        }
        else
            Debug.LogErrorFormat("Compantion {0} is not in the party!");
    }

    private void RecalculateEnergyConsuption()
    {
        float drainingSpeed = BaseEnergyConsumption;

        foreach (Companion comp in Companions)
            drainingSpeed += comp.EnergyConsumption;

        EnergyConsumption = drainingSpeed;
    }

}
