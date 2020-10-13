using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GameManager : MonoBehaviour
{
    public List<Cell> cells;
    [SerializeField] CellColorGroup colorGroup;
    Cell cell;
    // Start is called before the first frame update
    void Start()
    {
        cells = FindObjectsOfType<Cell>().ToList();
        cell = FindObjectOfType<Cell>();
        cell.ChangeColor += CheckList;
    }

  
    public void CheckList()
    {
        Debug.Log("Ya");
        for (int i = 0; i < cells.Count; i++)
        {
            if (cells[i].Group != colorGroup)
            {
                cells[i] = null;
            }

        }
    }

 
}
