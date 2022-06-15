using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    ItemInfo myInfo;
    ItemInfo dropInfo;
    public static int cantItems;
    public void OnDrop(PointerEventData eventData)
    {
        myInfo = gameObject.GetComponent<ItemInfo>();
        dropInfo = DragHandler.itemBeingDraged.GetComponent<ItemInfo>();

        Image dropSprite = DragHandler.itemBeingDraged.GetComponent<Image>();
        gameObject.GetComponent<Image>().sprite = dropSprite.sprite;

        myInfo.itemId = dropInfo.itemId;
        myInfo.name = dropInfo.name;

        Destroy(DragHandler.itemBeingDraged);
        DragHandler.itemBeingDraged = null;

        cantItems++;
        while (ReodenamientoDrop.estaOrden() == false)
        {
            ReodenamientoDrop.reordenar();
        }
 
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.GetComponent<ItemInfo>().itemId!=0 && BotonChange.EsPlay==true)
        {
            gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Assets/Plugins/CW/LeanGUI/Examples/Textures/Round10.png");

            gameObject.GetComponent<ItemInfo>().itemId = 0;
            gameObject.GetComponent<ItemInfo>().name = "";

            while (ReodenamientoDrop.estaOrden() == false)
            {
                ReodenamientoDrop.reordenar();
            }
            cantItems--;
        }

    }
}
