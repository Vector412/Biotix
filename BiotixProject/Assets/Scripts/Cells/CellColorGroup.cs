using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellColorGroup : MonoBehaviour
{
    [SerializeField] Color groupColor;
    [SerializeField] float speed = 1 ;

    public Color GroupColor { get => groupColor; set => groupColor = value; }
    public float Speed { get => speed; set => speed = value; }

}
