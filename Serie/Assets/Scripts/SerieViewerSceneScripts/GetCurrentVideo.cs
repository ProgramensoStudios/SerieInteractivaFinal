using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GetCurrentVideo : MonoBehaviour
{
   [SerializeField] public VideoPlayer currentEp;

   public void SetCurrentEp(VideoPlayer ep)
   {
      currentEp = ep;
   }
}
