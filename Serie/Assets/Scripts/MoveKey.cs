using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class MoveKey : MonoBehaviour
{
    private GameObject _listoBtn;
    private GameObject _undoBtn;

    private void Start()
    {
        _listoBtn = GameObject.Find("ListoBtn");
        _undoBtn = GameObject.Find("UndoBtn");
    }

    public void Move()
    {
        _undoBtn.GetComponent<Button>().interactable = false;
        _listoBtn.GetComponent<Button>().interactable = false;
        transform.rotation = Quaternion.Euler(0, 0, 90);
    }
}
