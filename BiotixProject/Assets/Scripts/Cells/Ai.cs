using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Ai : GenericSingletonClass<Ai>
{

    [SerializeField] List<Cell> cells;
    [SerializeField] List<Cell> otherCells;
    [SerializeField] CellColorGroup botGroup;
    [SerializeField] PathToCell pathTo;
    [SerializeField] CellColorGroup group;
    [SerializeField] Text countText;

    public Transform canvas;
    [SerializeField] Transform circle;
    private void Awake()
    {
        cells = FindObjectsOfType<Cell>().ToList();
        for (int i = 0; i < cells.Count; i++)
        {
            if (cells[i].Group != botGroup)
            {
                otherCells.Add(cells[i]);
                cells.RemoveAt(i--);
            }

        }
    }

    void Start()
    {
        FindTargetAndFrom();
    }

    public void CheckCell()
    {

    }

    public void FindTargetAndFrom()
    {
        Cell cell = otherCells[Random.Range(0, otherCells.Count)];
        Cell cellfrom = cells[Random.Range(0, cells.Count)];

        var t = Instantiate(pathTo, canvas, circle);
        var value = cellfrom.CurCount / 2;
        Debug.Log(value);
        cellfrom.CurCount -= value;
        t.Set(cellfrom.transform, cell, cellfrom.CurCount, group);
        countText.text = cellfrom.CurCount.ToString();

        Debug.Log(cell);
    }

}

