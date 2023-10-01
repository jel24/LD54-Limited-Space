using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Space : MonoBehaviour
{

    [SerializeField] ParticleSystem particles;
    [SerializeField] ParticleSystem invalid;
    [SerializeField] SpaceType spaceType = SpaceType.DockSpace;
    [SerializeField] public bool canBePickedUp = true;
    [SerializeField] Occupant occupant;
    bool invalidPlacement = false;




    [SerializeField] TextMeshPro text;
    public void Activate()
    {
        if (particles) particles.Play();
    }

    public void Deactivate()
    {
        if (particles) particles.Stop();

    }

    private void Update()
    {
        if (occupant)
        {
            if (occupant.IsPlacing())
            {
                OnTriggerExit(occupant.GetComponentInChildren<Collider>());
            }
        }
        if (!invalidPlacement)
        {
            if (invalid) invalid.Stop();
        }
    }

    public Occupant GetOccupant()
    {
        return occupant;
    }

    void OnTriggerEnter(Collider other)
    {
        Occupant tempOccupant = other.GetComponentInParent<Occupant>();

        if (!occupant && !tempOccupant.IsPlacing()) // First entry. Default placement.
        {
            occupant = tempOccupant;
        }

        if (occupant != tempOccupant && occupant) // New entry.
        {
            Debug.Log("Second occupant.");
            Debug.Log("First occupant " + occupant + ", second occupant " + tempOccupant.name);
            invalidPlacement = true;
            if (invalid) invalid.Play();
        }
    }


    void OnTriggerStay(Collider other) // Case where ghost piece gets placed.
    {
        Occupant tempOccupant = other.GetComponentInParent<Occupant>();

        if (!occupant && tempOccupant.IsPlacing())
        {
            //Debug.Log("Waiting for placement.");
        } else if (!occupant && !tempOccupant.IsPlacing()) 
        {
            occupant = tempOccupant;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Occupant tempOccupant = other.GetComponentInParent<Occupant>();
        if (tempOccupant == occupant)
        {
            occupant = null;
        }

        invalidPlacement = false;
        Debug.Log("Collider left");
    }

    public bool IsPlacementValid()
    {
        return !invalidPlacement;
    }

    public SpaceType GetSpaceType()
    {
        return spaceType;
    }

}
