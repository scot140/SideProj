using UnityEngine;
using System.Collections;
using System.IO;

public class CardDatabse : MonoBehaviour
{
    //database object
    private BaseDatabase<string, DuelCard> cardDatabase = null;

    // Use this for initialization
    void Start ()
    {
        cardDatabase = new BaseDatabase<string, DuelCard>();
	}

    //load information
    public bool Load(string _file)
    {
        if (0 == _file.Length)
            return false;


        return true;
    }

    public DuelCard Get(string _key)
    {
        return cardDatabase.Storage[_key];
    }
}
