using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racer : MonoBehaviour
{

    [SerializeField] Bike bikeStats;

    float topSpeed = 0f;

    void Start()
    {
        topSpeed = bikeStats.GetTopSpeed();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * -topSpeed);
    }



}
