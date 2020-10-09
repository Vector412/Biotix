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
    [SerializeField] PathToCell path;
    public Transform canvas;


    Cell cell;

    public Cell SelectCell;
    public bool isSend { get; set; }
    public bool IsDrag { get; private set; }
    public CellColorGroup CurrentGroup { get => currentGroup; set => currentGroup = value; }

    public void Start()
    {

        Vector3 CursorPosition = cursor.position;
        Cell cell = GetComponent<Cell>();
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
        cursor.transform.position = eventData.pointerCurrentRaycast.screenPosition;
    }

    public bool AddCell(Cell cell)
    {
        if (!cells.Contains(cell))
        {
            Debug.Log("add");
            cells.Add(cell);
            Debug.Log(cells.Count);
            return true;

        }
        Debug.Log("ect");

        return false;

    }

    public void Dependences() 
    {
        Debug.Log("1111");
        if (SelectCell && cells.Count >= 1)
        {
            foreach (var item in cells)
            {
                Debug.Log("/2");
                if (item == SelectCell) continue;
                var t = Instantiate(path, canvas);
                var value = item.Count / 2;
                item.Count -= value;
                t.Set(item.transform, SelectCell, value, CurrentGroup);
                Debug.Log("Create dependences");
            }
        }
        cells.Clear();

    }

















}
