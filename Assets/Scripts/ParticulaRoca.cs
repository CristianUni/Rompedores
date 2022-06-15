using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulaRoca : MonoBehaviour
{
    private bool salirPlay;
    private bool salirStop;
    public ParticleSystem efectoParticulas;
    public static bool estaEnRoca;
    public static GameObject roca;
    public static GameObject collisiones;
    void Start()
    {
        salirPlay = false;
        salirStop = false;
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("Player"))
        {
            estaEnRoca = true;
            roca = gameObject;
            collisiones= transform.parent.gameObject.transform.GetChild(1).gameObject;
            Debug.Log("Entró");
        }

    }
    private void OnTriggerStay(Collider col)
    {
        if (col.tag.Equals("Player"))
        {
            if (player.isGolpe == true && salirPlay != true)
            {
                efectoParticulas.Play(true);
                TraumaInducer.roca = true;
                salirPlay = true;
                salirStop = false;
            }
            else if (player.isGolpe == false && salirStop != true)
            {
                efectoParticulas.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                TraumaInducer.roca = false;
                salirStop = true;
                salirPlay = false;
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag.Equals("Player"))
        {
            salirPlay = false;
            salirStop = true;
            estaEnRoca = false;
            TraumaInducer.roca = false;
            TraumaInducer.time = 0;
        }
    }

    public void stopParticula()
    {
        efectoParticulas.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        TraumaInducer.roca = false;
        TraumaInducer.time = 0;
        salirStop = true;
        salirPlay = false;
    }

}
