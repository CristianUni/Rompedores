using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private float tiempo;
    private float tiempo3;
    private float tiempo2;
    private float tiempo4;
    private bool isAdelante;
    private bool isIzquierda;
    private bool isDerecha;
    private bool isAtras;
    public static bool isGolpe;
    public static bool caer;
    public static bool isVictoria;
    public static bool isChoquePiedraF;
    public static bool isChoquePiedraR;
    public static bool isChoquePiedraB;
    public static bool isChoquePiedraL;
    private bool isNoPasar;
    private Vector3 posicionInicial;

    void Start()
    {
        tiempo = 0;
        tiempo2 = 0;
        tiempo3 = 0;
        tiempo4 = 0;
        posicionInicial = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Adelante();
        Izquierda();
        Derecha();
        Atras();
        Golpe();
        Caer();
        Victoria();
        ChoquePiedra();
    }
    void Adelante()
    {
        if (isAdelante)
        {
            tiempo += Time.deltaTime;
            gameObject.transform.Translate(0, 0, 1f * Time.deltaTime);
            gameObject.GetComponent<Animator>().SetBool("isRun", true);
            if (tiempo % 60 >= 2)
            {
                isAdelante = false;
                tiempo = 0;
                gameObject.GetComponent<Animator>().SetBool("isRun", false);
            }
        }

    }

    void Izquierda()
    {
        if (isIzquierda)
        {
            tiempo += Time.deltaTime;
            gameObject.transform.Translate(-1f * Time.deltaTime, 0, 0);
            gameObject.GetComponent<Animator>().SetBool("isRun", true);
            if (tiempo % 60 >= 2)
            {
                isIzquierda = false;
                tiempo = 0;
                gameObject.GetComponent<Animator>().SetBool("isRun", false);
            }
        }
    }

    void Derecha()
    {
        if (isDerecha)
        {
            tiempo += Time.deltaTime;
            gameObject.transform.Translate(1f * Time.deltaTime, 0, 0);
            gameObject.GetComponent<Animator>().SetBool("isRun", true);
            if (tiempo % 60 >= 2)
            {
                isDerecha = false;
                tiempo = 0;
                gameObject.GetComponent<Animator>().SetBool("isRun", false);
            }
        }
    }

    void Atras()
    {
        if (isAtras)
        {
            tiempo += Time.deltaTime;
            gameObject.transform.Translate(0, 0, -1f * Time.deltaTime);
            gameObject.GetComponent<Animator>().SetBool("isRun", true);
            if (tiempo % 60 >= 2)
            {
                isAtras = false;
                tiempo = 0;
                gameObject.GetComponent<Animator>().SetBool("isRun", false);
            }
        }
    }
    void Golpe()
    {
        if (isGolpe)
        {
            tiempo3 += Time.deltaTime;
            gameObject.GetComponent<Animator>().SetBool("isPunch", true);
            if (tiempo3 % 60 >= 2)
            {
                isGolpe = false;
                tiempo3 = 0;
                gameObject.GetComponent<Animator>().SetBool("isPunch", false);
                if (ParticulaRoca.estaEnRoca)
                {
                    Roca();
                }
            }
        }
    }

    void Roca()
    {
            GameObject rocas = ParticulaRoca.roca;
            GameObject colisiones = ParticulaRoca.collisiones;
            rocas.GetComponent<ParticulaRoca>().stopParticula();
            rocas.SetActive(false);
            colisiones.SetActive(false);
            isChoquePiedraF = false;
            isChoquePiedraL = false;
            isChoquePiedraR = false;
            isChoquePiedraB = false;

    }
    void ChoquePiedra()
    {
        if (isNoPasar)
        {
            tiempo2 += Time.deltaTime;
            gameObject.GetComponent<Animator>().SetBool("isGetHit", true);
            if (tiempo2 % 60 >= 0.5)
            {
                isNoPasar = false;
                tiempo2 = 0;
                gameObject.GetComponent<Animator>().SetBool("isGetHit", false);
            }
        }
    }
    void Victoria()
    {
        if (isVictoria)
        {
            StopCoroutine("recorrerTarjetas");
            tiempo += Time.deltaTime;
            gameObject.GetComponent<Animator>().SetBool("isVictory", true);
            if (tiempo % 60 >= 4)
            {
                isVictoria = false;
                tiempo = 0;
                gameObject.GetComponent<Animator>().SetBool("isVictory", false);
            }
        }
    }

    bool ComprobarChoque(int id)
    {
        if (isChoquePiedraF && id == 5) return true;
        if (isChoquePiedraR && id == 4) return true;
        if (isChoquePiedraL && id == 3) return true;
        if (isChoquePiedraB && id == 2) return true;

        return false;
    }

    public IEnumerator recorrerTarjetas()
    {
        Debug.Log("Cantidad: "+ DropItem.cantItems);
        if (DropItem.cantItems > 0)
        {
            BotonChange.EsPlay = false;
        }
        List<GameObject> tarjetas = ReodenamientoDrop.slots;
        for (int i = 0; i < DropItem.cantItems; i++)
        {
            int id = tarjetas[i].GetComponent<ItemInfo>().itemId;
            
            if (ComprobarChoque(id)) {
                isNoPasar = true;
            }
            else
            {
                acciones(id);
            }
            /*if (i==DropItem.cantItems-1)
            {
                detener();
            }*/
            yield return new WaitForSeconds(2.3f);

        }
        BotonChange.EsPlay = true;
    }

    void acciones(int i)
    {
        switch (i)
        {
            case 1:
                isGolpe = true;
                break;
            case 2:
                isAtras = true;
                break;
            case 3:
                isDerecha = true;
                break;
            case 4:
                isIzquierda = true;
                break;
            case 5:
                isAdelante = true;
                break;
            default:
                Debug.Log("Default");
                break;
        }
    }

    public void empezar()
    {
        StartCoroutine("recorrerTarjetas");
    }

    public void detener()
    {
        BotonChange.EsPlay = true;
        StopCoroutine("recorrerTarjetas");
        detenerMovimiento();
        gameObject.transform.position = posicionInicial;
    }

    void detenerMovimiento()
    {
        isAdelante = false;
        isIzquierda = false;
        isDerecha = false;
        isAtras = false;
        isGolpe = false;
        caer = false;
        isVictoria = false;
        isChoquePiedraF = false;
        isChoquePiedraL = false;
        isChoquePiedraR = false;
        isChoquePiedraB = false;
        gameObject.GetComponent<Animator>().SetBool("isRun", false);
        gameObject.GetComponent<Animator>().SetBool("isPunch", false);
        gameObject.GetComponent<Animator>().SetBool("isCaer", false);
        gameObject.GetComponent<Animator>().SetBool("isVictory", false);
        gameObject.GetComponent<Animator>().SetBool("isGetHit", false);
        if (ParticulaRoca.roca!=null) ParticulaRoca.roca.SetActive(true);
        if (ParticulaRoca.collisiones != null) ParticulaRoca.collisiones.SetActive(true);
        TraumaInducer.roca = false;
        tiempo = 0;
        tiempo2 = 0;
        tiempo3 = 0;
        tiempo4 = 0;
    }

    public void Caer()
    {
        if (caer)
        {
            Debug.Log("1- "+tiempo4);
            tiempo4 += Time.deltaTime;
            gameObject.transform.Translate(0, -14f * Time.deltaTime, 0);
            gameObject.GetComponent<Animator>().SetBool("isCaer", true);
            Debug.Log("2- " + tiempo4);
            if (tiempo4 % 60 >= 2.5)
            {
                caer = false;
                tiempo4 = 0;
                gameObject.GetComponent<Animator>().SetBool("isCaer", false);
                detener();  
                
            }
        }
    }
}
