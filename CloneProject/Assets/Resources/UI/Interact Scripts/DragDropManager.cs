
public class DragDropManager
{
    static BaseInteract interactTarget = null;

    static public void Register(BaseInteract src)
    {
        if (null == interactTarget && src.GetInteractID() == BaseInteract.InteractID.IDRAG)
            interactTarget = src;
    }

    static public void Unregister(BaseInteract src)
    {
        if (src == interactTarget)
            interactTarget = null;
    }

    static public void Callback(BaseInteract src)
    {
        if (interactTarget != null && src.GetInteractID() == BaseInteract.InteractID.IDROP)
            src.Target = interactTarget.transform;
    }

    static public void CompleteCallback()
    {
        interactTarget.Execute();
        interactTarget = null;
    }

    static public bool IsDragged(BaseInteract src)
    {
        return interactTarget == src;
    }
}
