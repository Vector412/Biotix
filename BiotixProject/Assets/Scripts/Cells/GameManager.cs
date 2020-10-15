
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Advertisements;
public class GameManager : GenericSingletonClass<GameManager>
{
    [SerializeField] List<Cell> cells;
    [SerializeField] CellColorGroup botGroup;
    [SerializeField] CellColorGroup playerGroup;

    void Start()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("3864627", false);
        }
        cells = FindObjectsOfType<Cell>().ToList();
    }

    public void CheckList()
    {
        var cellsBot = cells.Where(n => n.Group == botGroup).Count();
        var cellsPlayer = cells.Where(n => n.Group == playerGroup).Count();
        if (cellsBot == 0)
        {
            Debug.Log("You win");
            ShowAds();

        }
        else if (cellsPlayer == 0)
        {
            ShowAds();
            Debug.Log("You lose");
        }
    }

    public void ShowAds()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("video");
        }
    }
}
