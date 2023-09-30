using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "Bike", menuName = "ScriptableObjects/Bike", order = 1)]
public class Bike : ScriptableObject
{

    [SerializeField] float topSpeed = 90f;
    [SerializeField] float shield = 0f;
    [SerializeField] float traction = 45f;
    [SerializeField] float durability = 100f;
    [SerializeField] float boost = 2f;
    [SerializeField] float cooling = 5f;


    [SerializeField] int heatMaximum = 100;
    float heat = 0;

    
    public float GetTopSpeed()
    {
        return topSpeed;
    }

    public float GetShield()
    {
        return shield;
    }

    public float GetTraction()
    {
        return traction;
    }

    public float GetDurability()
    {
        return durability;
    }

    public float GetBoost()
    {
        return boost;
    }

    public float GetCooling()
    {
        return cooling;
    }
}
