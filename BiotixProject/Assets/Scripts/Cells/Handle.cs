using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Handle : GenericSingletonClass<Handle>, IBeginDragHandler, IDragHandler,IEndDragHandler
{

    public List<Cell> cells = new List<Cell>();
    [SerializeField] Transform cursor;
    [SerializeField] CellColorGroup currentGroup;
    [SerializeField] PathToCell  path;
    [SerializeField] Sprite circle;
     public Transform canvas;

    public Vector3 CursorPosition => cursor.position;

    Cell cell;

    public Cell SelectCell;
    public bool isSend { get; set; }
    public bool IsDrag { get; private set; }
    public CellColorGroup CurrentGroup { get => currentGroup; set => currentGroup = value; }

    public void Start()
    {
        List<Cell> cells = new List<Cell>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Global touch");
        IsDrag = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("No Global touch!");
        Dependences();


    }

    public void OnDrag(PointerEventData eventData)
    {
       cursor.position = eventData.pointerCurrentRaycast.screenPosition;
    }

    public bool AddCell(Cell cell)
    {
        if (!cells.Contains(cell))
        {

            cells.Add(cell);
          
            return true;

        }
      

        return false;

    }

    public void Dependences() 
    {
       
        if (SelectCell && cells.Count >= 1)
        {
            foreach (var item in cells)
            {
                Debug.Log(1);
                if (item == SelectCell) continue;
                var t = Instantiate(path, canvas, circle);
                var value = item.CurCount / 2;
                Debug.Log(value);
                item.CurCount -= value;
                t.Set(item.transform, SelectCell, value, CurrentGroup);
               value.ToString();


            }
        }
    
        foreach (var cel in cells)
        {
            cel.isSelect = false;
            cel.Diselect();
        }
        IsDrag = false;
        cells.Clear();
      
       

    }

















}
