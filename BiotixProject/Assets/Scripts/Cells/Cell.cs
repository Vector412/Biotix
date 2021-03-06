﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Cell : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler,  IPointerExitHandler
{
    [SerializeField] int currentCountCell;
    [SerializeField] int count;
    [SerializeField] Text countText;
    [SerializeField] CellColorGroup colorGroup;
    [SerializeField] Image imageColor;
    [SerializeField] LineRenderer line;
    [SerializeField] GameObject active;
    [SerializeField] UnityEvent OnChangeGroup;

    private bool isAddStarted;
    private bool isMinusStarted;
    public bool IsSelect { get; set; }

    public int CurCount
    {
        get => currentCountCell;
        set
        {
            currentCountCell = value;
            ChangeCount();
        }
    }

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }
    private void Start()
    {
        if (colorGroup != null)
        {
            imageColor.color = colorGroup.GroupColor;
        }
        else
        {
            imageColor.color = Color.white;
        }

        countText.text = currentCountCell.ToString();
        OnChangeGroup.AddListener(Ai.Instance.CheckCellInList);
        OnChangeGroup.AddListener(GameManager.Instance.CheckList);
        
    }

    IEnumerator AddCount()
    {
        isAddStarted = true;
        while (currentCountCell < count)
        {
            CurCount++;
            yield return new WaitForSeconds(1f);
            if (currentCountCell == count)
            {
                StopCoroutine(AddCount());
                isAddStarted = false;
            }
        }
    }
    IEnumerator MinusCount()
    {
        isMinusStarted = true;
        while (currentCountCell > count)
        {
            CurCount--;
            yield return new WaitForSeconds(1f);
            if (currentCountCell == count)
            {
                StopCoroutine(MinusCount());
                isMinusStarted = false;
            }
        }
    }

    private void Check()
    {
        if (currentCountCell < count && !isAddStarted && colorGroup)
        {
            StartCoroutine(AddCount());
            isAddStarted = true;
        }
        else if (currentCountCell > count && !isMinusStarted && colorGroup)
        {
            StartCoroutine(MinusCount());
            isMinusStarted = true;
        }
    }

    public void Add(int count, CellColorGroup group)
    {
      
        if (Group == group)
        {
            CurCount += count;
        }
        else
        {
            CurCount -= count;
            if (CurCount < 0)
            {
                imageColor.color = group.GroupColor;
                colorGroup = group;
                CurCount *= -1;
                OnChangeGroup.Invoke();

            }
            else if (CurCount == 0)
            {
                Group = null;
                imageColor.color = Color.white;
            }
        }
    }

    public Vector3 FromScreenToWorld(Vector3 pos)
    {
        var t = Camera.main.ScreenToWorldPoint(pos);
        t.z = 0;
        return t;
    }

    private void LateUpdate()
    {
        Check();
        if (IsSelect)
        {
            var pathFrom = FromScreenToWorld(transform.position);
            var pathTo = FromScreenToWorld(Handle.Instance.CursorPosition);
            line.SetPosition(0, pathFrom);
            line.SetPosition(1, pathTo);
        }
    }

    public void CellActive()
    {
        line.enabled = true;
        IsSelect = true;
        ActiveCell(true); ;
    }
    public void CellDeactive()
    {
        line.enabled = false;
        ActiveCell(false); ;
    }

    public void ActiveCell(bool isActive)
    {
        active.gameObject.SetActive(isActive);
    }

    public void ChangeCount()
    {
        countText.text = CurCount.ToString();
    }

    public CellColorGroup Group
    {
        get => colorGroup;
        set
        {
            if (colorGroup != null)
            {
                imageColor.color = colorGroup.GroupColor;
            }
            else
            {
                imageColor.color = Color.white;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Handle.Instance.SelectCell = this;
        if (Handle.Instance.CurrentGroup == Group)
        {
            if (Handle.Instance.AddCell(this))
            {
                Handle.Instance.isSend = true;
                ActiveCell(true);
            }
            else
            {
                Handle.Instance.Dependences();
            }
        }
        else
        {
            if (Handle.Instance.isSend)
            {
                Handle.Instance.isSend = false;
                Handle.Instance.SelectCell = this;
                Handle.Instance.Dependences();
            }
        }

    }

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
                    CellActive();
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
