using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Space : MonoBehaviour
{

    [SerializeField] ParticleSystem particles;
    [SerializeField] ParticleSystem invalid;

    Occupant occupant;
    bool invalidPlacement = false;

    [SerializeField] TextMeshPro text;
    public void Activate()
    {
        particles.Play();
    }

    public void Deactivate()
    {
        particles.Stop();

    }

    private void Update()
    {
        if (occupant)
        {
            if (occupant.IsPlacing())
            {
                OnTriggerExit(occupant.GetComponentInChildren<Collider>());
            } else
            {
                text.text = occupant.name;
            }


        }
        if (invalidPlacement)
        {
        } else
        {
            if (invalid) invalid.Stop();
        }
    }

    public Occupant GetOccupant()
    {
        Debug.Log(occupant);
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
            Debug.Log("Waiting for placement.");
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
            text.text = "--";
        }
        invalidPlacement = false;

    }

    public bool IsPlacementValid()
    {
        return !invalidPlacement;
    }

}
