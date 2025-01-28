using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class QueueActions : MonoBehaviour
{
    [SerializeField] private VideoPlayer thisEp;
    [SerializeField] private VideoPlayer otherOptionThisEp;
    [SerializeField] private VideoPlayer nextEpOp1;
    [SerializeField] private VideoPlayer nextEpOp2;
    private int option;
    [SerializeField] private ShowSubtitle subsOp1;
    [SerializeField] private ShowSubtitle subsOp2;
    
    public void PressBtn(int op)
    {
        Debug.Log("Action Queque");
        option = op;
        if (thisEp.isPlaying || otherOptionThisEp.isPlaying)
        {
            StartCoroutine(WaitForThisEpToEnd());
        }
    }

    private IEnumerator WaitForThisEpToEnd()
    {
        yield return new WaitUntil(() => !thisEp.isPlaying && !otherOptionThisEp.isPlaying);
        thisEp.enabled = false;
        otherOptionThisEp.enabled = false;
        switch (option)
        {
            case 1:
                nextEpOp1.enabled = true;
                subsOp1.StartSubs();
                break;
            case 2:
                nextEpOp2.enabled = true;
                subsOp2.StartSubs();
                break;
        }
    }
}