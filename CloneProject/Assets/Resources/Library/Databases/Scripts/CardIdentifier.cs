

public class CardIdentifier
{
    //private members identifying 
    private string cardID;

    public CardIdentifier(string _id)
    {
        cardID = _id;
    }

    public CardIdentifier(string _faction, string _cardNum, string _cardType)
    {
        cardID = _faction + '-' + _cardType + '-' + _cardNum;
    }

    public string FactionID { get { return ID.Split('-')[0]; } }
    public string TypeID { get { return ID.Split('-')[1]; } }
    public string CardNumber { get { return ID.Split('-')[2]; } }
    public string ID { get { return cardID; } }
    public string UniqueID { get { string[] str = ID.Split('-'); return str[1] + '-' + str[2]; } }

}

