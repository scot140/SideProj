using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(CanvasRenderer))]
[RequireComponent(typeof(HorizontalLayoutGroup))]
public class HandZone : MonoBehaviour
{
    //TODO: IF HAND SIZE IS ALWAYS LIMITED - SWITCH TO ARRAY

    //list of cards
    private ArrayList PlayerHand;


    // Use this for initialization
    void Start ()
    {
        //initialize
        PlayerHand = new ArrayList();
    }


    public int AddCard(ref DuelCard card)
    {
        //TODO: add restrictive functionality for max hand size
        int addIndex = PlayerHand.Count;
        PlayerHand.Add(card);
        return addIndex;
    }

    public int Remove(ref DuelCard card)
    {
        int removeIndex = PlayerHand.IndexOf(card);
        PlayerHand.Remove(card);
        return removeIndex;
    }

    #region Properties

    public bool Empty
    {
        get
        {
#if true
            return PlayerHand.Count == 0;
#else

            if (PlayerHand.Count == 0)
                return true;

            for (int i = 0; i < PlayerHand.Count; ++i)
            {
                if (PlayerHand[i] != null)
                    return false;
            }

            return true;
#endif
        }
    }

#endregion


}
