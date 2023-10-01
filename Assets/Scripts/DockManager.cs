using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockManager : MonoBehaviour
{

    [SerializeField] TriggeredEvent victoryEvent;

    private void Start()
    {
        InvokeRepeating("CheckVictory", 1f, 3f);
    }


    // Update is called once per frame
    void CheckVictory()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("Victory!");

            victoryEvent.Trigger();
        }
    }
}
