using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VoyageManager : MonoBehaviour
{

    [SerializeField] GameObject boatModel;
    [SerializeField] float totalDistance;
    [SerializeField] Boat boat;
    [SerializeField] Vector3 boatDirection;


    float distanceTraveled;
    Vector3 startPoint;


    void Start()
    {
        startPoint = transform.position;
        StartCoroutine(Day());
    }

    IEnumerator Day()
    {
        while (Vector3.Distance(startPoint, transform.position) < totalDistance / (7 - boat.sails))
        {
            yield return null;
            boatModel.transform.Translate(boatDirection * Time.deltaTime);
        }
        EndOfDay();
    }

    void EndOfDay()
    {

    }


}
