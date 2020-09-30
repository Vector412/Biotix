using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandleScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler//IPointerEnterHandler
{
    [SerializeField] Text LogText;
    int touch;
    bool one, two;

    private void Start()
    {
        touch = 0;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Global touch!");

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("No Global touch!");

        //InputManager.Instance.InputKey(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        LogText.transform.position = eventData.position;
    }

    /*  public void OnPointerEnter(PointerEventData eventData)
      {
          Debug.Log(gameObject);
      }*/

    private void OnMouseDown()
    {

        touch++;
        Debug.Log(touch);

        if (touch == 2 && gameObject)

        {
            Debug.Log(touch);
            var twoGameObj = this.gameObject;
            Cell cell2 = twoGameObj.GetComponent<Cell>();
            if (cell2.currentCountCell > 0)
            {
                Debug.Log(cell2.currentCountCell);
                cell2.currentCountCell += 10;
            }
        }
        else if (gameObject)
        {
            var mainGameobj = this.gameObject;
            Cell cell1 = mainGameobj.GetComponent<Cell>();
            if (cell1.currentCountCell > 0)
            {
                Debug.Log(cell1.currentCountCell);
                cell1.MigrateCountCell();
            }
        }
    }
}
