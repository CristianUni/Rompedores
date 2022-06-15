using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviarDatos : MonoBehaviour
{
    public GameObject botonEnviar;
    public void Enviar()
    {
        botonEnviar.SetActive(false);
        Datos mydatos = GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>();

        mydatos.nivel1 = mydatos.nivel1 - 1;
        mydatos.nivel2 = mydatos.nivel2 - 1;
        mydatos.nivel3 = mydatos.nivel3 - 1;
        mydatos.nivel4 = mydatos.nivel4 - 1;
        mydatos.nivel5 = mydatos.nivel5 - 1;

        ManejoInfo subir = new ManejoInfo();
        subir.SubirDatos(mydatos,() =>
        {

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CambiarNivel>().cambiar = true;
        });
        botonEnviar.SetActive(true);

    }
}
