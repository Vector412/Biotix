using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckObject : MonoBehaviour,  IPointerUpHandler
{
    public void OnPointerUp(PointerEventData eventData)
    {
        if (gameObject.CompareTag("Grey"))
        {
            Debug.Log("Yes");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
