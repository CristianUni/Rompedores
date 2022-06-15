using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarNivel : MonoBehaviour
{
    public string escena;
    public Color colorTransicion = Color.black;
    public bool cambiar;
    public bool Cambiar
    {
        set { cambiar = value; }
    }
    void Start()
    {
        cambiar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(cambiar != false)
        {
            Initiate.Fade(escena,colorTransicion,0.5f);
        }
    }

    void CambiarNiveles(int indice)
    {
        SceneManager.LoadScene(indice);
    }
}
