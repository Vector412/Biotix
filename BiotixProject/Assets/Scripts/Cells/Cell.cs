using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cell : MonoBehaviour, IPointerEnterHandler, /*IPointerClickHandler*/  IPointerExitHandler
{
    [SerializeField] int countCell;
    public int currentCountCell { get; set; }
    [SerializeField] Text countText;
    [SerializeField] CellColorGroup colorGroup;
    [SerializeField] Image imageColor;
    [SerializeField] Image enCircle;



    bool isFull;
    public bool isSelect { get; set; }

    public Action WaitDirection = delegate { };

    [SerializeField] float delay;


    public int Count
    {
        get => countCell;
        set
        {
            countCell = value;
            ChangeCount();
        }
    }

    private void Start()
    {

        if (colorGroup != null)
        {
            imageColor.color = colorGroup.GroupColor;
            Debug.Log(imageColor.color);
        }
        else
        {
            imageColor.color = Color.white;
            Debug.Log("null");
        }



        isFull = true;

        currentCountCell = countCell;
        countText.text = currentCountCell.ToString();
    }


    public void Select()
    {
        enCircle.gameObject.SetActive(true);
    }
    public void ChangeCount()
    {
        countText.text = Count.ToString();
    }

    public CellColorGroup Group
    {
        get => colorGroup;
        set
        {
            if (colorGroup != null)
            {
                imageColor.color = colorGroup.GroupColor;
                Debug.Log(imageColor.color);
            }
            else
            {
                imageColor.color = Color.white;
                Debug.Log("null");
            }
        }
    }

    public void Add(int count, CellColorGroup group)
    {
      
        if (Group == group)
        {
            Count += count;
        }
        else
        {
            Count -= count;
            if (Count < 0)
            {
                imageColor.color = group.GroupColor;
                colorGroup = group;
                Group = group;
                Debug.Log(group.name);
               
                Count *= -1;
            }
            if (Count == 0)
            {
                Group = null;
                imageColor.color = Color.white;
            }
        }
      
    }



 /*  public void OnPointerClick(PointerEventData eventData)
    {
        Handle.Instance.SelectCell = this;
        if (Handle.Instance.CurrentGroup == Group)
        {
            if (Handle.Instance.AddCell(this))
            {
                Handle.Instance.isSend = true;
            }
            else
            {
                Debug.Log("пустить струю в свою ячейку");
                Handle.Instance.Dependences();
            }
        }
        else
        {
            if (Handle.Instance.isSend)
            {
                Debug.Log("send");
               
                Handle.Instance.isSend = false;
                Handle.Instance.SelectCell = this;
                Handle.Instance.Dependences();
            }
        }

    }*/


  
   public void OnPointerEnter(PointerEventData eventData)
    {
        Handle.Instance.SelectCell = this;
        if (Handle.Instance.IsDrag)
        {
            if (Handle.Instance.CurrentGroup == Group)
            {
                if (Handle.Instance.AddCell(this))
                {
                    Handle.Instance.isSend = true;
                }
            }
            else
            {
                if (Handle.Instance.isSend)
                {
                    Handle.Instance.isSend = false;
                    Handle.Instance.SelectCell = this;
                }
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Handle.Instance.SelectCell == this)
        {
            Handle.Instance.SelectCell = null;
        }
    }
}
