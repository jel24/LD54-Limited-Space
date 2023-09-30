using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum ResourceType { 
    food,
    fishing,
    goods,
    crew,
    weapons,
    lumber,
    speed
}


public class Occupant : MonoBehaviour
{

    [SerializeField] ParticleSystem placementParticles;
    [SerializeField] ResourceType resource; 
    [SerializeField] int statBonus;
    [SerializeField] TextMeshPro label;

    bool isPlacing = false;

    void Start()
    {
        label.text = " +" + statBonus;
    }

    public void Placement()
    {
        placementParticles.Play();
        isPlacing = true;
        Cursor.visible = false;

    }

    public void PlacementComplete()
    {
        placementParticles.Stop();
        isPlacing = false;
        Cursor.visible = true;

    }

    public bool IsPlacing()
    {
        return isPlacing;
    }

    public void AddToInventory()
    {

    }

    public ResourceType GetResourceType()
    {
        return resource;
    }

    public int GetResourceBonus()
    {
        return statBonus;
    }

}
