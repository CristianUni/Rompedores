using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarPiedra : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.tag.Equals("PiedraF"))
        {
            player.isChoquePiedraF=true;
        }else if (col.tag.Equals("PiedraR"))
        {
            player.isChoquePiedraR = true;
        }
        else if (col.tag.Equals("PiedraL"))
        {
            player.isChoquePiedraL = true;
        }
        else if (col.tag.Equals("PiedraB"))
        {
            player.isChoquePiedraB = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        Debug.Log("Saliò");
        if (col.tag.Equals("PiedraF"))
        {
            player.isChoquePiedraF = false;
        }
        else if (col.tag.Equals("PiedraR"))
        {
            player.isChoquePiedraR = false;
        }
        else if (col.tag.Equals("PiedraL"))
        {
            player.isChoquePiedraL = false;
        }
        else if (col.tag.Equals("PiedraB"))
        {
            player.isChoquePiedraB = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
