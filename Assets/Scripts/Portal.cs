using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    bool gano;
    float tiempo;
    CambiarNivel cambiar;

    private void Start()
    {
        gano = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entro a portal");
        cambiar= GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CambiarNivel>();
        player.isVictoria = true;
        int intentos= Int32.Parse(GameObject.FindGameObjectWithTag("Intentos").GetComponent<Text>().text);

        string nombreEscena = SceneManager.GetActiveScene().name;
        switch (nombreEscena)
        {
            case "Nivel1":
                GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>().nivel1 = intentos;
                break;
            case "Nivel2":
                GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>().nivel2 = intentos;
                break;
            case "Nivel3":
                GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>().nivel3 = intentos;
                break;
            case "Nivel4":
                GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>().nivel4 = intentos;
                break;
            case "Nivel5":
                GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>().nivel5 = intentos;
                break;
            default:
                Debug.Log("Default");
                break;
        }
        
        gano = true;
    }

    private void Update()
    {
        if (gano)
        {
            DropItem.cantItems = 0;
            tiempo += Time.deltaTime;
            if (tiempo % 60 >= 3)
            {
                tiempo = 0;
                gano = false;
                cambiar.cambiar = true;
            }
        }
    }
}
