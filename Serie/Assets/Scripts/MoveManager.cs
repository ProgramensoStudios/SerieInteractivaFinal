using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class MoveManager : MonoBehaviour
{
    [SerializeField] private DynamicMoveProvider dynamicMoveProvider;

    #region Variables
    [SerializeField] private float moveSpeed;
    #endregion

    public void StartMovement()
    {
        dynamicMoveProvider.moveSpeed = moveSpeed;
    }
    public void StopMovement()
    {
        dynamicMoveProvider.moveSpeed = 0;
    }
}
