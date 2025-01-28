using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDissolveAnim : MonoBehaviour
{
   #region Variables

   [SerializeField] private DissolveTextures dissolveTextures;
   [SerializeField] public bool isControllerGrabbed;
   [SerializeField] private Float floating;
   #endregion


   public void Pick()
   {
      Debug.Log("<color=green>Grabbed</color>");
      isControllerGrabbed = true;
   }

   public void LetGo()
   {
      Debug.Log("<color=red>Not Grabbed</color>");
      isControllerGrabbed = false;
      floating.useGravity = true;
   }
}
