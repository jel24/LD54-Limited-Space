using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Occupant : MonoBehaviour
{

    [SerializeField] ParticleSystem placementParticles;


    bool isPlacing = false;

    public void Placement()
    {
        placementParticles.Play();
        isPlacing = true;

    }

    public void PlacementComplete()
    {
        placementParticles.Stop();
        isPlacing = false;
    }

    public bool IsPlacing()
    {
        return isPlacing;
    }

}
