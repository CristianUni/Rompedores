using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class Datos : MonoBehaviour
{
    public string nombre;
    public int nivel1;
    public int nivel2;
    public int nivel3;
    public int nivel4;
    public int nivel5;

    public int preg1;
    public int preg2;
    public int preg3;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        nombre = "";
        nivel1 = 0;
        nivel2 = 0;
        nivel3 = 0;
        nivel4 = 0;
        nivel5 = 0;

        preg1 = 0;
        preg2 = 0;
        preg3 = 0;
    }

}
[System.Serializable]
public class ManejoInfo
{
    const string kBaseUrl = "https://script.google.com/macros/s/AKfycbwLH1f9_FZxLmMnG4CdLYqDFzaMP_vh3Ia6wv5Hogsut_jtZdbZeXBogHhhcMCkNusWkw/exec";

    public void SubirDatos(Datos myDatos, System.Action onDone)
    {
        var url = kBaseUrl + $"?nombre={myDatos.nombre}&n1={myDatos.nivel1}&n2={myDatos.nivel2}&n3={myDatos.nivel3}&n4={myDatos.nivel4}&n5={myDatos.nivel5}&q1={myDatos.preg1}&q2={myDatos.preg2}&q3={myDatos.preg3}";
        var request = new UnityWebRequest(url,UnityWebRequest.kHttpVerbGET);
        request.SendWebRequest().completed += op =>
        {
            onDone();
        };
    }
}
