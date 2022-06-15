using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        player.isVictoria = true;
        Destroy(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0.0f, 60f*Time.deltaTime, 0.0f, Space.Self);
    }
}
