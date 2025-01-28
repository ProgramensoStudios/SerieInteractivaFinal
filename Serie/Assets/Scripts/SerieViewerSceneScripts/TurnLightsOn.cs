using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TurnLightsOn : MonoBehaviour
{
    private Coroutine lightsOff;
    [Header("Lights Settings")]
    public Light lights;
    [SerializeField] private float lightTransitionDuration;
    [SerializeField] private Color startCol;
    [SerializeField] private Color endCol;
    [SerializeField] private VideoPlayer currentVid;
    [SerializeField] private VideoPlayer creds;

    private void OnEnable()
    {
        currentVid.loopPointReached += LightsOn;
        currentVid.loopPointReached += PlayCredits;
    }

    private void OnDisable()
    {
        currentVid.loopPointReached -= LightsOn;
        currentVid.loopPointReached -= PlayCredits;
    }

    private void LightsOn(VideoPlayer vid)
    {
        if (lightsOff != null)
        {
            StopCoroutine(lightsOff);
        }
        lightsOff = StartCoroutine(TransitionLights(startCol, endCol));
    }

    private void PlayCredits(VideoPlayer vid)
    {
        currentVid.enabled = false;
        creds.enabled = true;
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
