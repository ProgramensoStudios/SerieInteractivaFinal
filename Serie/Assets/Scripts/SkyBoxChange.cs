using System.Collections;
using UnityEngine;

public class SkyBoxChange : MonoBehaviour
{
    [SerializeField] private Material skyboxMaterial; // Asume que usa Skybox/Panoramic
    [SerializeField] private float transitionDuration = 2.0f;
    [SerializeField] private Color whiteCol;

    private Coroutine currentTransition;

    private void Start()
    {
        if (skyboxMaterial != null)
        {
            RenderSettings.skybox = skyboxMaterial;
            skyboxMaterial.SetColor("_Tint", Color.black); // Inicializa el tint en negro
        }
    }

    [ContextMenu("Start Tint Transition")]
    public void StartTintTransition()
    {
        if (skyboxMaterial != null)
        {
            
                StartTint(Color.black, whiteCol); // De negro a #D9D9D9
            
           
            
        }
    }

    private void StartTint(Color startColor, Color endColor)
    {
        if (currentTransition != null)
        {
            StopCoroutine(currentTransition);
        }
        currentTransition = StartCoroutine(TransitionTint(startColor, endColor));
    }

    private IEnumerator TransitionTint(Color startColor, Color endColor)
    {
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float lerpFactor = elapsedTime / transitionDuration;

            // Interpolar el tint del SkyBox
            Color currentColor = Color.Lerp(startColor, endColor, lerpFactor);
            skyboxMaterial.SetColor("_Tint", currentColor);

            yield return null;
        }

        // Asegura que el color final se establezca correctamente
        skyboxMaterial.SetColor("_Tint", endColor);
        currentTransition = null;
    }
}