using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Transform prefab;
    public Transform canvas;
    // Start is called before the first frame update
    void Start()
    {
        CreateObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateObject()
    {
     Transform transform = Instantiate(prefab);
     transform.localPosition = canvas.localPosition;
    }
}
