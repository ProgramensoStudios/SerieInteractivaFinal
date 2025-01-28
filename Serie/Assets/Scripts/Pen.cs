using System;
using System.Collections.Generic;
using UnityEngine;
public class Pen : MonoBehaviour
{
    public bool isGrabbed = false;
    public Transform tip;
    public Material drawingMaterial;
    public Material tipMaterial;
    public bool canDraw = false;
    private GameObject _pivot;

    public LineRenderer currentDrawing;
    private List<Vector3> positions = new();
    private int index;
    public List<GameObject> drawings;
    private int _drawindex;
   

    private void Start()
    {
        _pivot = GameObject.Find("DrawPivot");
        tipMaterial.color = Color.red;
    }

    public void Draw()
    {
        if(canDraw)
        {
            if (currentDrawing == null)
            {
                index = 0;
                currentDrawing = new GameObject().AddComponent<LineRenderer>();
                drawings.Add(currentDrawing.gameObject);
                currentDrawing.material = drawingMaterial;
                currentDrawing.startColor = currentDrawing.endColor = tipMaterial.color;
                currentDrawing.startWidth = currentDrawing.endWidth = 0.01f;
                currentDrawing.positionCount = 1;
                currentDrawing.SetPosition(0,tip.position);
                currentDrawing.gameObject.transform.parent = _pivot.transform;
                currentDrawing.useWorldSpace = false;
                _drawindex = drawings.Count;
                
            }
            else
            {
                var currentPosition = currentDrawing.GetPosition(index);
                if (Vector3.Distance(currentPosition, tip.position) > 0.01f)
                {
                    index++;
                    currentDrawing.positionCount = index + 1;
                    currentDrawing.SetPosition(index, tip.position);
                }
            }
        }
    }

    public void Pick()
    {
        isGrabbed = true;
    }

    public void Drop()
    {
        isGrabbed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("drawSurface"))
        {
            canDraw = true;
        }
    }

    public void UndoLast()
    {
        _drawindex = drawings.Count;
        GameObject lastDraw = drawings[_drawindex - 1].gameObject;
        drawings.Remove(lastDraw);
        Destroy(lastDraw);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("drawSurface"))
        {
            canDraw = false;
        }
    }
}
