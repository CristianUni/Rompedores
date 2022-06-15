using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intentos : MonoBehaviour
{
    public int intentos;
    public Text labelIntentos;

    private void Start()
    {
        intentos = 0;
    }

    public void AumentarIntentos()
    {
        intentos++;
        labelIntentos.text = intentos+"";
    }
}
