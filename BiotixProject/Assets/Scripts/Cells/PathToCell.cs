using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathToCell : MonoBehaviour
{
    [SerializeField] Transform pathFromCell;
    [SerializeField] Cell pathToCell;
    [SerializeField] CellColorGroup group;
    [SerializeField] int count;

    [SerializeField] float speed;
    float time;

    public Transform PathFrom { get => pathFromCell; set => pathFromCell = value; }
    public Cell PathTo { get => pathToCell; set => pathToCell = value; }
    public int Count { get => count; set => count = value; }


   
    public void Start()
    {
        var pathFrom = FromScreenToWorld(pathFromCell.transform.position);
        var pathTo = FromScreenToWorld(pathToCell.transform.position);
        time = Vector2.Distance(pathFrom, pathTo) / speed;
        StartCoroutine(WaitFromTo());
    }

    public void Set(Transform pathfr, Cell pathTo, int count, CellColorGroup group)
    {
        this.PathFrom = pathfr;
        this.PathTo = pathTo;
        this.Count = count;
        this.group = group;
    }


    public Vector3 FromScreenToWorld(Vector3 pos)
    {
        var posCamera = Camera.main.ScreenToWorldPoint(pos);
        posCamera.z = 0;
        return posCamera;
    }

    IEnumerator WaitFromTo()
    {
        yield return new WaitForSeconds(time);
        Debug.Log("пришло");
        pathToCell.Add(Count, group);


    }
}
