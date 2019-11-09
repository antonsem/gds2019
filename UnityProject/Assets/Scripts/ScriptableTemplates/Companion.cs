using UnityEngine;

[CreateAssetMenu(fileName = "Companion", menuName = "GDS/Companion")]
public class Companion : ScriptableObject
{
    [SerializeField]
    private string _name = "Companion";
    [SerializeField]
    private Sprite image;

    [SerializeField]
    private float energyConsupmtion = 1;

    public string Name { get => _name; }
    public float EnergyConsumption { get => energyConsupmtion; set => energyConsupmtion = value; }
    public Sprite Image { get => image; }
}
