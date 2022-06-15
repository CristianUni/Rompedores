using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstrellasCuestionario : MonoBehaviour
{
    public GameObject groupRadio1;
    public GameObject groupRadio2;
    public GameObject groupRadio3;

    public int preg1;
    public int preg2;
    public int preg3;
    void Start()
    {
        preg1 = 0;
        preg2 = 0;
        preg3 = 0;
    }

    public void CalcularEstrellas()
    {
        for (int i=0; i< groupRadio1.transform.childCount;i++)
        {
            if (groupRadio1.transform.GetChild(i).gameObject.GetComponent<LeanToggle>().On)
            {
                preg1++;
            }
            if (groupRadio2.transform.GetChild(i).gameObject.GetComponent<LeanToggle>().On)
            {
                preg2++;
            }
            if (groupRadio3.transform.GetChild(i).gameObject.GetComponent<LeanToggle>().On)
            {
                preg3++;
            }
        }

        GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>().preg1 = preg1;
        GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>().preg2 = preg2;
        GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>().preg3 = preg3;
        preg1 = 0;
        preg2 = 0;
        preg3 = 0;

        
        
    }
}
