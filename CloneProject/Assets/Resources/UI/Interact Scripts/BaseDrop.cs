using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

abstract public class BaseDrop : BaseInteract, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    #region BaseInteract
    override public InteractID GetInteractID()
    {
        return InteractID.IDROP;
    }

    override public void OnMouseUpAsButton()
    {
        //do nothing
    }
    #endregion

    // overrides
    virtual public void OnDrop(PointerEventData pData)
    {
        //do nothing
    }

    virtual public void OnPointerEnter(PointerEventData pData)
    {
        //do nothing
    }

    virtual public void OnPointerExit(PointerEventData pData)
    {
        //do nothing
    }


}
