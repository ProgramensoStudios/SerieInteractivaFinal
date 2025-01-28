using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOtherTimeline : MonoBehaviour
{
    [SerializeField] private GameObject[] timelineVids;

    public void DestroyTimeline()
    {
        for (int indexVid = 0; indexVid == timelineVids.Length; indexVid++)
        {
            timelineVids[indexVid].SetActive(false);
        }
    }
}
