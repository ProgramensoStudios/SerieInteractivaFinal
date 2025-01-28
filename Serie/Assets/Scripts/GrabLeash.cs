using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabLeash : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject dogObject;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private MoveManager moveManager;
    [SerializeField] private bool isGrabbed;
    #endregion

    public void Pick()
    {
        isGrabbed = true;
        dogObject.transform.SetParent(playerTransform);
        moveManager.StartMovement();
    }

    public void LetGo()
    {
        isGrabbed = false;
        dogObject.transform.SetParent(null);
        moveManager.StopMovement();
    }
}
