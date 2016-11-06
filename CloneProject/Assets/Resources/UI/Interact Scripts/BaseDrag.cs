using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

abstract public class BaseDrag : BaseInteract, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    #region BaseInteract

    override public InteractID GetInteractID()
    {
        return InteractID.IDRAG;
    }

    override public void OnMouseUpAsButton()
    { }
    override public void Execute()
    { }

    #endregion


    //mandatory override
    virtual public void OnDrag(PointerEventData pData)
    { }

    //optional overrides
    virtual public void OnBeginDrag(PointerEventData pData)
    {
    }
    virtual public void OnEndDrag(PointerEventData pData)
    {
    }
}
