using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Occupant : MonoBehaviour
{

    [SerializeField] ParticleSystem placementParticles;



    bool isPlacing = false;


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

}
