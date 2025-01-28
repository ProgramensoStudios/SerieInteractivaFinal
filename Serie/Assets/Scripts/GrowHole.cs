using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrowHole : MonoBehaviour
{
    public static int SizeID = Shader.PropertyToID("_Size");
    [SerializeField] private float sizeValue;
    public static int OpacityID = Shader.PropertyToID("_Opacity");
    [SerializeField] private float opacityValue;
    [SerializeField] private float duration;

    [SerializeField] private Material sun;
    public static int AlphaId = Shader.PropertyToID("_Alpha");
    [SerializeField] private float alpha;
    [SerializeField] private SkyBoxChange changer;
    [SerializeField] private MeshRenderer vortexFloor;
    [SerializeField] private GameObject houses;
    


    public IEnumerator StartGrowing()
    {
        var elapsedTime = 0f;
        var initialSizeValue = 0f;
        var targetSizeValue = 3f;
        var initialOpacityValue = 0f;
        var targetOpacityValue = 1f;
        var targetAlpha = 0;
        var initialAlpha = 1;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            sizeValue = Mathf.Lerp(initialSizeValue, targetSizeValue, elapsedTime / duration);
            opacityValue = Mathf.Lerp(initialOpacityValue, targetOpacityValue, elapsedTime / duration);
            alpha = Mathf.Lerp(initialAlpha, targetAlpha, elapsedTime/ duration);
            
            sun.SetFloat(AlphaId, alpha);

            yield return null;
        }

       
        sizeValue = targetSizeValue;
        opacityValue = targetOpacityValue;
        alpha = targetAlpha;

        sun.SetFloat(AlphaId, alpha);
        changer.StartTintTransition();
        vortexFloor.enabled = false;
        houses.SetActive(true);
    }
}
