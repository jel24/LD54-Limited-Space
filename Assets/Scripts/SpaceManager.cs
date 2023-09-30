using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceManager : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] Camera mainCamera;
    [SerializeField] Vector3 offsetVector;

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
            return hit.collider.gameObject.GetComponent<Space>();
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

                    if (o)
                    {
                        placementPiece = o;
                        o.Placement();
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
                        placementPiece.PlacementComplete();
                        placementPiece = null;

                    }
                    else
                    {
                        Debug.Log("Placement invalid.");
                    }

                    
                }
            }
            if (activeSpace && !placementPiece)
            {

            }
        }

    }
}
