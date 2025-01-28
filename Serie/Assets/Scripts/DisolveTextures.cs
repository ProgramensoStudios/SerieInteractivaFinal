using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DissolveTextures : MonoBehaviour
{
    [SerializeField] private Material[] dissolveColors;
    [SerializeField] private Material[] dissolveTextures;
    [SerializeField] private float dissolveTime = 2f;
    [SerializeField] public bool dissolveCorEnded;
    [SerializeField] private GameObject livingroom;
    [SerializeField] private MoveManager moveManager;
    private static readonly int AlphaClipping = Shader.PropertyToID("_AlphaClipping");

    private void Start()
    {
        dissolveCorEnded = false;
        List<Material> allMaterials = new List<Material>();
        foreach (var mat in allMaterials)
        {
            if (mat.HasProperty("_AlphaClipping"))
            {
                mat.SetFloat(AlphaClipping, 0);
            }
        }
    }

    public IEnumerator DissolveMaterials()
    {
        float elapsedTime = 0f;
        
        List<Material> allMaterials = new List<Material>();
        allMaterials.AddRange(dissolveColors);
        allMaterials.AddRange(dissolveTextures);

       
        while (elapsedTime < dissolveTime)
        {
            elapsedTime += Time.deltaTime;
            float alphaValue = Mathf.Clamp01(elapsedTime / dissolveTime);

            foreach (var mat in allMaterials)
            {
                if (mat.HasProperty("_AlphaClipping"))
                {
                    mat.SetFloat("_AlphaClipping", alphaValue);
                }
            }

            yield return null;
        }
        
        foreach (var mat in allMaterials)
        {
            if (mat.HasProperty("_AlphaClipping"))
            {
                mat.SetFloat("_AlphaClipping", 1f);
            }
        }

        dissolveCorEnded = true;
        moveManager.StartMovement();
        Debug.Log("<color=blue>COR ENDED</color>" + dissolveCorEnded);
        livingroom.SetActive(false);
    }
}
