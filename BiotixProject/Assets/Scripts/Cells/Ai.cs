using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Ai : GenericSingletonClass<Ai>
{
    [SerializeField] List<Cell> cells;
    [SerializeField] List<Cell> otherCells;
    [SerializeField] CellColorGroup botGroup;
    [SerializeField] PathToCell pathTo;
    [SerializeField] Transform canvas;
    [SerializeField] Transform circle;

    void Start()
    {
        cells = FindObjectsOfType<Cell>().ToList();
        InvokeRepeating("FindTargetAndFrom", 1f, 5f);
        for (int i = 0; i < cells.Count; i++)
        {
            if (cells[i].Group != botGroup)
            {
                otherCells.Add(cells[i]);
                cells.RemoveAt(i--);
            }
        }
    }

    public void FindTargetAndFrom()
    {
        Cell cell = otherCells[Random.Range(0, otherCells.Count)];
        Cell cellfrom = cells[Random.Range(0, cells.Count)];
        var t = Instantiate(pathTo, canvas, circle);
        var value = cellfrom.CurCount / 2;
        cellfrom.CurCount -= value;
        t.Set(cellfrom.transform, cell, cellfrom.CurCount,botGroup );
    }

    public void CheckCellInList()
    {
        for (int i = 0; i < cells.Count; i++)
        {
            if (cells[i].Group != botGroup)
            {
                otherCells.Add(cells[i]);
                cells.RemoveAt(i--);
            }
        }
        for (int i = 0; i < otherCells.Count; i++)
        {
            if (otherCells[i].Group == botGroup)
            {
                cells.Add(otherCells[i]);
                otherCells.RemoveAt(i--);
            }
        }
    }

}

