using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ReodenamientoDrop : MonoBehaviour
{
    public static List<GameObject> slots;
    GameObject padre;
    void Start()
    {
        slots = new List<GameObject>();

        padre = gameObject;
        for (int i=0;i< padre.transform.childCount;i++)
        {
            GameObject hijo = padre.transform.GetChild(i).gameObject;
            slots.Add(hijo);
        }
    }


    public static void reordenar()
    {

        for (int i = 0; i < slots.Count - 1; i++)
        {
            if (slots[i].GetComponent<ItemInfo>().itemId == 0 && slots[i + 1].GetComponent<ItemInfo>().itemId != 0)
            {
                GameObject aux = slots[i];
                GameObject aux2 = slots[i + 1];
                aux.GetComponent<Image>().sprite = aux2.GetComponent<Image>().sprite;

                aux.GetComponent<ItemInfo>().itemId = aux2.GetComponent<ItemInfo>().itemId;
                aux.GetComponent<ItemInfo>().name = aux2.GetComponent<ItemInfo>().name;

                aux2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Assets/Plugins/CW/LeanGUI/Examples/Textures/Round10.png");

                aux2.GetComponent<ItemInfo>().itemId = 0;
                aux2.GetComponent<ItemInfo>().name = "";
            }
        }
    }

    public static bool estaOrden()
    {
        for (int i = 0; i < slots.Count-1; i++)
        {
            if (slots[i].GetComponent<ItemInfo>().itemId == 0 && slots[i+1].GetComponent<ItemInfo>().itemId !=0)
            {
                return false;
            }
        }
        return true;
    }
}
