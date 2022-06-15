using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resultados : MonoBehaviour
{
    public Text desc;
    public Text nivel1;
    public Text nivel2;
    public Text nivel3;
    public Text nivel4;
    public Text nivel5;


    void Start()
    {
        Datos mydatos = GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>();
        desc.text = mydatos.nombre + desc.text;
        nivel1.text =  CalcularGrado(mydatos.nivel1+1) + nivel1.text + (mydatos.nivel1+1);
        nivel2.text = CalcularGrado(mydatos.nivel2+1) + nivel2.text + (mydatos.nivel2+1);
        nivel3.text = CalcularGrado(mydatos.nivel3+1) + nivel3.text + (mydatos.nivel3+1);
        nivel4.text = CalcularGrado(mydatos.nivel4 + 1) + nivel4.text + (mydatos.nivel4 + 1);
        nivel5.text = CalcularGrado(mydatos.nivel5 + 1) + nivel5.text + (mydatos.nivel5 + 1);
    }

    public string CalcularGrado(int taps)
    {
        if (taps ==1 )
        {
            return "Excelente";
        }else if (taps>1 && taps<=3)
        {
            return "Bueno";
        }else if (taps>3 && taps<=10)
        {
            return "Regular";
        }
        else
        {
            return "Malo";
        }
    }
}
