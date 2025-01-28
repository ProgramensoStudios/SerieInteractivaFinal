using System;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;


[RequireComponent(typeof(InputData))]
public class DisplayInputData : MonoBehaviour
{
    [SerializeField] public StartDissolveAnim dissolveAnim;
    [SerializeField] private DissolveTextures dissolveTextures;
    private InputData _inputData;
    [SerializeField] private MoveManager moveManager;

    [SerializeField]
    private bool isWatchingSeries;

    
    private void Start()
    {
        _inputData = GetComponent<InputData>();
    }

    public void Update()
    {
        if (!_inputData._rightController.TryGetFeatureValue(CommonUsages.primaryButton, out var rightPrimBtn))return;
        {
            if (isWatchingSeries) return;
            if (rightPrimBtn && dissolveAnim.isControllerGrabbed)
            {
                Debug.Log(rightPrimBtn);
                StartCoroutine(dissolveTextures.DissolveMaterials());
            }

        }
        
       /* if (_inputData._rightController.TryGetFeatureValue(CommonUsages.primary2DAxis, out var right2DAxis))
        {
            if (dissolveTextures.dissolveCorEnded)
            {
                moveManager.StartMovement();
            }
        }*/
    }
   
}
