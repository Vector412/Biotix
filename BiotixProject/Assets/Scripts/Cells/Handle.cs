
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Handle : GenericSingletonClass<Handle>, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [SerializeField] List<Cell> cells = new List<Cell>();
    [SerializeField] Transform cursor;
    [SerializeField] CellColorGroup currentGroup;
    [SerializeField] PathToCell path;
    [SerializeField] Sprite circle;
    [SerializeField] Transform canvas;

    public Vector3 CursorPosition => cursor.position;
    public Cell SelectCell;
    public bool isSend { get; set; }
    public bool IsDrag { get; private set; }
    public CellColorGroup CurrentGroup { get => currentGroup; set => currentGroup = value; }

  
    public void OnBeginDrag(PointerEventData eventData)
    {
        IsDrag = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
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
                if (item == SelectCell) continue;
                var t = Instantiate(path, canvas, circle);
                var value = item.CurCount / 2;
                item.CurCount -= value;
                t.Set(item.transform, SelectCell, value, CurrentGroup);
                value.ToString();
            }
        }
        foreach (var cel in cells)
        {
            cel.IsSelect = false;
            cel.CellDeactive();
        }
        IsDrag = false;
        cells.Clear();
    }
}
