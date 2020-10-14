using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GameManager : GenericSingletonClass<GameManager>
{
    public List<Cell> cells;
    public List<Cell> cellsBot;
   
    [SerializeField] CellColorGroup colorGroup;
   
    void Start()
    {
        cells = FindObjectsOfType<Cell>().ToList();
        for (int i = 0; i < cells.Count; i++)
        {
            if (cells[i].Group == null)
            {
                cells.RemoveAt(i--);
            }
        }
    }

    public void CheckList()
    {
        Debug.Log("Ya");
        for (int i = 0; i < cells.Count; i++)
        {
            if (cells[i].Group != colorGroup)
            {
                cellsBot.Add(cells[i]);
                cells.RemoveAt(i--);
            }
        }
        if (cells.Count == 0)
        {
            Debug.Log("You lose");
        }
        else
        {
            Debug.Log("You win");
        }
    }

 
}
