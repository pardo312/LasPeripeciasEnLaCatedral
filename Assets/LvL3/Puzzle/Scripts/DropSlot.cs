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
    DragAndDropManager dragAndDropManager;

    private void Start()
    {
        dragAndDropManager = GameObject.FindGameObjectWithTag("DragAndDropManager").GetComponent<DragAndDropManager>();
    }

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
        if (!item)
        {
            item = DragHandler.itemDragging;
            item.transform.SetParent(transform);
            item.transform.position = transform.position;

            if(item.tag == gameObject.tag)
            {
                item.GetComponent<DragHandler>().enabled = false;
                dragAndDropManager.AddFinishedItem();
            }
        }
    }
}
