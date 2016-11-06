using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CardDrag))]
[RequireComponent(typeof(CanvasGroup))]
public class DuelCard : MonoBehaviour
{
    //source object of card visual data
    public SpriteDatabase spriteDatabase;
    //debugging -- id for card to generate
    public string cardID;

    //card stats and other information
    private CardInfo cardInfo;
    //two visual objects of the current card
    public FieldCard fieldCard;
    public UICard uiCard;


    public void Start()
    {
        cardInfo = new CardInfo();
        uiCard.SetActive(true);
        fieldCard.SetActive(false);
    }


    public bool Summon()
    {
        //temporary: set the card information
        VisualInfo info = spriteDatabase.Get(cardID);
        if (null == info)
            return false;

        fieldCard.SetVisuals(ref info);

        //turn on field visual items
        uiCard.SetActive(false);
        fieldCard.SetActive(true);

        return true;
    }

    public CardInfo Info { get { return cardInfo; } }
}
