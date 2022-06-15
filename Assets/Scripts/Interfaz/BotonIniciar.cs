using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonIniciar : MonoBehaviour
{
    public InputField texto;
    public GameObject notif;
    public void ValidacionNombre()
    {
        string nombre = texto.text;
        if (nombre != "")
        {
            GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>().nombre=nombre;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CambiarNivel>().cambiar=true;
        }
        else
        {
            notif.GetComponent<LeanPulse>().Pulse();
        }
    }
}
