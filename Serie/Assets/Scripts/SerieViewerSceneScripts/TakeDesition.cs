using TMPro;
using UnityEngine;
using UnityEngine.Video;
using System.Collections;

public class TakeDesition : MonoBehaviour
{
    [SerializeField] private GameObject prevButtons;
    [SerializeField] private GameObject nextButtons;

    [SerializeField] private VideoPlayer thisChapter;
    [SerializeField] private string instructionsText;
    [SerializeField] private TMP_Text instructionsTMP;
    
    [SerializeField] private float uiShowTimeBeforeEnd;

    private void OnEnable()
    {
        thisChapter.started += OnVideoStarted;
    }

    private void OnDisable()
    {
        thisChapter.started -= OnVideoStarted;
    }

    private void OnVideoStarted(VideoPlayer source)
    {
        StartCoroutine(HandleEpisodeUI(thisChapter));
    }

    private IEnumerator HandleEpisodeUI(VideoPlayer videoPlayer)
    {
        double totalDuration = videoPlayer.length;
        double timeToShowUI = totalDuration - uiShowTimeBeforeEnd;

        if (timeToShowUI > 0)
        {
            yield return new WaitForSeconds((float)timeToShowUI);
        }
        ChangeUI();
    }

    private void ChangeUI()
    {
        prevButtons.SetActive(false);
        nextButtons.SetActive(true);
        instructionsTMP.text = instructionsText;
    }
}