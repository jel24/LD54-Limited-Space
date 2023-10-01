using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum SpaceType { 
    DockSpace,
    BoatSpace
}



public class SpaceManager : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] Camera mainCamera;
    [SerializeField] Vector3 offsetVector;
    [SerializeField] Transform dockParent;
    [SerializeField] Transform boatParent;
    [SerializeField] Transform placementParent;
    [SerializeField] TriggeredEvent refreshBoatEvent;
    [SerializeField] TriggeredEvent pickupEvent;
    [SerializeField] TriggeredEvent placementEvent;

    Space[] spaces;

    Space activeSpace;

    Occupant placementPiece;

    // Start is called before the first frame update
    void Start()
    {
        spaces = GetComponentsInChildren<Space>();
    }

    // Update is called once per frame
    void Update()
    {
        Space newSpace = CheckForSpace();
        if (newSpace != activeSpace)
        {
            if (activeSpace)
            {
                activeSpace.Deactivate();
            } 
            if (newSpace)
            {
                newSpace.Activate();
                if (placementPiece)
                {
                    placementPiece.transform.position = newSpace.transform.position + offsetVector;

                }
            }
            activeSpace = newSpace;
        }
    }


    Space CheckForSpace()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Ray ray = mainCamera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray: ray, hitInfo: out RaycastHit hit, 100f, layerMask) && hit.collider)
        {
            Space hitSpace = hit.collider.gameObject.GetComponent<Space>();
            if (hitSpace)
            {
                if (hitSpace.canBePickedUp) return hitSpace;
            }
            return null;
        } else
        {
            return null;
        }
    }

    public void Click(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Clicked!");
            if (activeSpace)
            {
                Debug.Log("Active space found.");

                Occupant o = activeSpace.GetOccupant();
                if (!placementPiece) // If there is no placement piece, check to see if there's something to pick up.
                {
                    Debug.Log("No placement piece.");

                    if (o && activeSpace.canBePickedUp)
                    {
                        placementPiece = o;
                        o.Placement();
                        pickupEvent.Trigger();
                    }
                }
                else if (!o) // If there is a placement piece, place it.
                {
                    Debug.Log("Placement piece.");

                    bool validPlacement = true;

                    foreach (Space s in spaces)
                    {
                        if (!s.IsPlacementValid())
                        {
                            Debug.Log(s.name + " is not a valid placement space.");
                            validPlacement = false;
                        }
                    }

                    if (validPlacement)
                    {
                        placementEvent.Trigger();
                        if (activeSpace.GetSpaceType() == SpaceType.BoatSpace)
                        {
                            placementPiece.transform.parent = boatParent;
                        }
                        else
                        {
                            placementPiece.transform.parent = dockParent;
                        }
                        placementPiece.PlacementComplete();
                        placementPiece = null;

                        refreshBoatEvent.Trigger();
                    }
                        else
                    {
                        Debug.Log("Placement invalid.");
                    }

                    
                }
            }
        }

    }
}
