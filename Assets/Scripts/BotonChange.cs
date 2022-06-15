using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonChange : MonoBehaviour
{
    static GameObject botonPlay;
    static GameObject botonStop;
    static GameObject muro;
    private static bool esPlay;
    public static bool EsPlay
    {
        get { return esPlay; }
        set
        {
            esPlay = value;
            cambiarEstadoBtn();
        }
    }
    public static void cambiarEstadoBtn()
    {
        if (esPlay!=true)
        {
            botonPlay.SetActive(false);
            botonStop.SetActive(true);
            muro.SetActive(true);
        }
        else
        {

            botonPlay.SetActive(true);
            botonStop.SetActive(false);
            muro.SetActive(false);
        }
    }
    void Start()
    {
        esPlay = true;
        botonPlay = GameObject.FindGameObjectWithTag("Play");
        botonStop = GameObject.FindGameObjectWithTag("Stop");
        muro = GameObject.FindGameObjectWithTag("MuroGUI");
        muro.SetActive(false);
        botonPlay.SetActive(true);
        botonStop.SetActive(false);
    }

    // Update is called once per frame

}
