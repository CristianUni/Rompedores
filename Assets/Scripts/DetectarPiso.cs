using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarPiso : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("Piso"))
        {
            player.caer = false;
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.tag.Equals("Piso"))
        {
            player.caer = false;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag.Equals("Piso"))
        {
            player.caer = true;
        }
    }
}
