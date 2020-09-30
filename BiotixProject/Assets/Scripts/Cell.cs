using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] int countCell;
    public int currentCountCell { get; set; }
    [SerializeField] Text countText;

    bool isFull;

    [SerializeField] float delay;



    private void Start()
    {

        InputManager.Instance.Activate += MigrateCountCell;
        InputManager.Instance.Activate += CheckCount;
        isFull = true;
        currentCountCell = countCell;
        countText.text = currentCountCell.ToString();
    }

    public void MigrateCountCell()
    {
        if (currentCountCell > 0)
        {
            currentCountCell -= 10;
            isFull = false;
            countText.text = currentCountCell.ToString();
        }
        CheckCount();
        
    }

    void CheckCount()
    {
        if (currentCountCell == countCell)
        {
           
            if (isFull)
                StopCoroutine(AddCount());
        }
        else
        {
            if (!isFull)
            {
                StartCoroutine(AddCount());
            }
          
        }
    }

    IEnumerator AddCount()
    {

        while (currentCountCell < countCell)
        {
            yield return new WaitForSeconds(delay);
            Count();
            countText.text = currentCountCell.ToString();
        }
        isFull = true;

    }

    void Count()
    {
        currentCountCell += 1;
    }



}
