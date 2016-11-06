using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class FieldDrop : BaseDrop
{
    private GameObject currentCard = null;

    override public void OnMouseUpAsButton()
    {
        //TODO: extra logic for non-minions based cards and field movement

        //unoccupied
        if (null == currentCard)
        {

            DragDropManager.Callback(this);
            if (this.Target != null)
            {
                //access the game object that would be dropped
                currentCard = this.Target.gameObject;
                currentCard.transform.SetParent(this.transform);

                //load and summons the minion
                DuelCard duelCard = currentCard.GetComponent<DuelCard>();
                if (null != duelCard)
                {
                    //TODO: Event for OnSummon
                    //summon the monster
                    duelCard.Summon();
                    duelCard.gameObject.transform.position = this.transform.position;

                    //TODO: Event for AfterSummon
                }
                DragDropManager.CompleteCallback();
            }
        }
    }

    #region Properties

    public bool IsOccupied { get { return (null != currentCard); } }
    public GameObject Occupant { get { return currentCard; } }

    #endregion

}
