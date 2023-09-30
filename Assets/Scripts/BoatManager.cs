using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatManager : MonoBehaviour
{

    [SerializeField] TriggeredEvent UpdateResourceUIEvent;
    [SerializeField] Boat boat;

    public void UpdateBoat()
    {
        Occupant[] occupants = GetComponentsInChildren<Occupant>();

        boat.food = 0;
        boat.fishing = 0;
        boat.goods = 0;
        boat.crew = 0;
        boat.weapons = 0;
        boat.lumber = 0;
        boat.sails = 0;


        foreach (Occupant o in occupants)
        {
            switch (o.GetResourceType())
            {
                case ResourceType.food:
                    boat.food += o.GetResourceBonus();
                    break;
                case ResourceType.fishing:
                    boat.fishing += o.GetResourceBonus();

                    break;
                case ResourceType.goods:
                    boat.goods += o.GetResourceBonus();

                    break;
                case ResourceType.crew:
                    boat.crew += o.GetResourceBonus();

                    break;
                case ResourceType.weapons:
                    boat.weapons += o.GetResourceBonus();

                    break;
                case ResourceType.lumber:
                    boat.lumber += o.GetResourceBonus();

                    break;
                case ResourceType.speed:
                    boat.sails += o.GetResourceBonus();

                    break;
            }
        }
        UpdateResourceUIEvent.Trigger();
    }

}
