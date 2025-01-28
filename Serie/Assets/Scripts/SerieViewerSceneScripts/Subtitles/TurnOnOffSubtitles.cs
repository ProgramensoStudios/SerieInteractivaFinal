using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnOffSubtitles : MonoBehaviour
{
    [SerializeField] private GameObject subs;
    [SerializeField] private bool on;

    public void TurnOnOff()
    {
        switch (on)
        {
            case true:
                subs.SetActive(false);
                on = false;
                break;
            case false:
                subs.SetActive(true);
                on = true;
                break;
        }
    }
}
