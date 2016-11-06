using UnityEngine;
using System.Collections;

abstract public class BaseInteract : MonoBehaviour
{
    public enum InteractID { IDRAG, IDROP};

    abstract public void OnMouseUpAsButton();
    abstract public InteractID GetInteractID();

    //property access
    private Transform interactTarget = null;
    public Transform Target { get { return interactTarget; } set { interactTarget = value; } }

    virtual public void Execute()
    { }
}
