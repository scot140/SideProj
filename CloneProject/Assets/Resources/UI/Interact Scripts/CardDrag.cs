using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class CardDrag : BaseDrag
{
    override public void OnBeginDrag(PointerEventData pData)
    {
        DragDropManager.Register(this);
        //stop raycasts for other UI events to trigger
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    override public void Execute()
    {
        DragDropManager.Unregister(this);
        //enable raycasts
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }

    public void Update()
    {
        if (DragDropManager.IsDragged(this))
        {
            this.transform.position = Input.mousePosition;
        }
    }
}
