using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowSubtitle : MonoBehaviour
{
    public Subs subs;
    private Coroutine subCor;
    [SerializeField] private TextMeshProUGUI tmp;

    public void StartSubs()
    {
        if (subCor != null)
        {
            StopCoroutine(subCor);
        }
        subCor = StartCoroutine(Subtitles1(subs.duration, subs.subtitles));
    }

    private IEnumerator Subtitles1(IReadOnlyList<float> duration, IReadOnlyList<string> subtitles)
    {
        for (var indexSubtitle = 0; indexSubtitle < subtitles.Count; indexSubtitle++)
        {
            tmp.fontStyle = subs.textType[indexSubtitle] switch
            {
                TextType.Italic => FontStyles.Italic,
                TextType.Normal => FontStyles.Normal,
                TextType.Bold => FontStyles.Bold,
                _ => throw new ArgumentOutOfRangeException()
            };
            tmp.text = subtitles[indexSubtitle];
            yield return new WaitForSeconds(duration[indexSubtitle]);
            tmp.text = "";
        }
    }
    
    [System.Serializable]
    public struct Subs
    {
        public float[] duration;
        public string[] subtitles;
        public TextType[] textType;
    }

    public enum TextType
    {
        Italic,
        Normal,
        Bold,
    }
}