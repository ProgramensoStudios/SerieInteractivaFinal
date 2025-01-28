using TMPro;
using UnityEngine;
using UnityEngine.Video;
using System.Collections;

public class PlayNextEpInstantly : MonoBehaviour
{
    [SerializeField] private VideoPlayer thisChapter;
    [SerializeField] private VideoPlayer nextEp;


    private void OnEnable()
    {
        thisChapter.loopPointReached += NextVid;
    }

    private void OnDisable()
    {
        thisChapter.loopPointReached -= NextVid;
    }

    private void NextVid(VideoPlayer source)
    {
        thisChapter.enabled = false;
        nextEp.enabled = true;
    }
}
