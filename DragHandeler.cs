﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;

    /* -------------------------------------------*/
    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponentInParent<GridLayoutGroup>().enabled = false;
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    /* -------------------------------------------*/
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    /* -------------------------------------------*/
    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponentInParent<GridLayoutGroup>().enabled = true;
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent != startParent)
        {
            transform.position = startPosition;

        }

    }
}
