using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class TurnTvOn : MonoBehaviour
{
    private Coroutine turnOnSelectionCanvas;
    private Coroutine lightsOff;

    [Header("Episodes Sets")]
    [SerializeField] private VideoPlayer firstEp;
    [SerializeField] private VideoPlayer secondEp;

    [Header("Lights Settings")]
    public Light lights;
    [SerializeField] private float lightTransitionDuration;
    [SerializeField] private Color startCol;
    [SerializeField] private Color endCol;

    [Header("UI Settings")]
    [SerializeField] private GameObject uiCanvas;
    [SerializeField] private GameObject firstDecisionUI;
    [SerializeField] private float uiShowTimeBeforeEnd;

    [Header("Subtitle Settings")] 
    [SerializeField] private ShowSubtitle showSubtitles;

    public bool canTurnLightsOn;
    public bool canWatchFirstEp;

    private void OnEnable()
    {
        // Suscribir eventos
        firstEp.loopPointReached += OnFirstEpisodeFinished;
    }

    private void OnDisable()
    {
        // Desuscribir eventos
        firstEp.loopPointReached -= OnFirstEpisodeFinished;
    }

    public void StartWatching()
    {
        if (!canWatchFirstEp) return;
        firstEp.enabled = true;
        firstEp.Play();
        if (!canTurnLightsOn) return;
        if (lightsOff != null)
        {
            StopCoroutine(lightsOff);
        }
        lightsOff = StartCoroutine(TransitionLights(startCol, endCol));
        canTurnLightsOn = false;
        canWatchFirstEp = false;
    }

    private void OnFirstEpisodeFinished(VideoPlayer vp)
    {
        firstEp.enabled = false;
        secondEp.enabled = true;
        secondEp.Play();
        showSubtitles.StartSubs();
        
        if (turnOnSelectionCanvas != null)
        {
            StopCoroutine(turnOnSelectionCanvas);
        }
        turnOnSelectionCanvas = StartCoroutine(HandleEpisodeUI(secondEp));
    }
    

    private IEnumerator HandleEpisodeUI(VideoPlayer videoPlayer)
    {
        // Calcular el tiempo para mostrar la UI
        double totalDuration = videoPlayer.length;
        double timeToShowUI = totalDuration - uiShowTimeBeforeEnd;

        if (timeToShowUI > 0)
        {
            yield return new WaitForSeconds((float)timeToShowUI);
        }

        // decision 2 ep canvas btn on, 
        uiCanvas.SetActive(true);
        firstDecisionUI.SetActive(false);
    }

    private IEnumerator TransitionLights(Color startColor, Color endColor)
    {
        float elapsedTime = 0f;

        while (elapsedTime < lightTransitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float lerpFactor = elapsedTime / lightTransitionDuration;

            Color currentColor = Color.Lerp(startColor, endColor, lerpFactor);
            lights.color = currentColor;

            yield return null;
        }

        lights.color = endColor;
    }
}
