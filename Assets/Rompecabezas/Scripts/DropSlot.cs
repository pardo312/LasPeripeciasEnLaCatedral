using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public GameObject item;

    // Update is called once per frame
    void Update()
    {
        if (item != null && item.transform.parent != transform)
        {
            item = null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        bool drop = false;
        if (eventData.pointerDrag != null)
        {
            Image imagen = eventData.pointerDrag.GetComponent<Image>();
            //Debug.Log("Nombre" + imagen.name);
            Image slot = eventData.pointerEnter.GetComponent<Image>();
            //Debug.Log("NombreSlot:" + slot.name);
            drop = removeLetters(imagen.name) == removeLetters(slot.name);
        }

        if (!item && drop)
        {
            item = DragHandler.itemDragging;
            item.transform.SetParent(transform);
            item.transform.position = transform.position;
        }
    }

    private string removeLetters(string cadena)
    {
        return Regex.Replace(cadena, "[^0-9.]", "");
    }
}
