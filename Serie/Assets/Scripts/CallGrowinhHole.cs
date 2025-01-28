using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallGrowinhHole : MonoBehaviour
{
    [SerializeField] private GrowHole growHole;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("OBJECT FOND");
            StartCoroutine(growHole.StartGrowing());
        }
    }
}
