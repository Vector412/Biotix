
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GameManager : GenericSingletonClass<GameManager>
{
    [SerializeField] List<Cell> cells;
    [SerializeField] CellColorGroup botGroup;
    [SerializeField] CellColorGroup playerGroup;

    void Start()
    {
        cells = FindObjectsOfType<Cell>().ToList();
    }

    public void CheckList()
    {
        var cellsBot = cells.Where(n => n.Group == botGroup).Count();
        var cellsPlayer = cells.Where(n => n.Group == playerGroup).Count();
        if (cellsBot == 0)
        {
            Debug.Log("You win");
        }
        else if (cellsPlayer == 0)
        {
            Debug.Log("You lose");
        }
    }
}
