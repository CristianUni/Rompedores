 using UnityEngine;
using System.Collections;

/* Example script to apply trauma to the camera or any game object */
public class TraumaInducer : MonoBehaviour 
{
    [Tooltip("Maximum stress the effect can inflict upon objects Range([0,1])")]
    public float MaximumStress = 0.6f;
    [Tooltip("Maximum distance in which objects are affected by this TraumaInducer")]
    public float Range = 45;
    public GameObject target;
    public static float time=0;
    public static bool roca;
    int cont = 0; 
    private void Start()
    {
        roca = false;
        if (target == null) target = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        Roca();
    }

    public void Roca()
    {
        if (roca)
        {   
            time += Time.deltaTime;
            if (cont == 3)
            {
                roca = false;
                cont = 0;
            }
            else if(time%60 > 0.62)
            {
               Shake();
               time = 0;

               cont++;
            } 

        }
    }

    public void Shake()
    {
        var receiver = target.GetComponent<StressReceiver>();
        float distance = Vector3.Distance(transform.position, target.transform.position);
        /* Apply stress to the object, adjusted for the distance */
        if (distance <= Range)
        {
            float distance01 = Mathf.Clamp01(distance / Range);
            float stress = (1 - Mathf.Pow(distance01, 2)) * MaximumStress;
            receiver.InduceStress(stress);
        }
    }
}