using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UICard : MonoBehaviour
{
    //display card text
    public Text CardTitle;
    public Text CardEffect;
    public Text CardHealthText;
    public Text CardAttackText;
    public Text CardManaText;

    //images to display
    public RawImage CardBack;
    public Image CardIcon;
    public RawImage CardHealthImage;
    public RawImage CardAttackImage;
    public RawImage CardManaImage;

    public void DisplayInfo(ref CardInfo info)
    {
        //update text
        if (null == CardTitle)
            CardTitle.text = info.cardName;
        if (null == CardHealthText)
            CardHealthText.text = info.HealthPoint.ToString();
        if (null == CardAttackText)
            CardAttackText.text = info.AttackPower.ToString();
        if (null == CardManaText)
            CardManaText.text = info.ManaCost.ToString();
    }

    public void SetActive(bool value)
    {
        this.gameObject.SetActive(value);
    }
}
