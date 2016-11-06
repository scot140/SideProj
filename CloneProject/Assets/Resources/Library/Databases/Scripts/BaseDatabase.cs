using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//abstract base class for loading and storing various informatin


public class BaseDatabase<KeyType, StoreType>
{

    //the database dictionary
    private Dictionary<KeyType, StoreType> database;

    //public access
    public Dictionary<KeyType, StoreType> Storage { get { return database; } }


    public BaseDatabase()
    {
        database = new Dictionary<KeyType, StoreType>();
    }

    //provide a way to add an entry
   public bool AddEntry(KeyType _key, StoreType _val)
    {
        if (null == _key || null == _val)
        {
            return false;
        }

        if (database.ContainsKey(_key))
            return false;

        database[_key] = _val;
        return true;
    }

    //provide a way to add an entry
    public bool AddEntry(KeyType _key, ref StoreType _val)
    {
        if (null == _key || null == _val)
        {
            return false;
        }

        if (database.ContainsKey(_key))
            return false;

        database[_key] = _val;
        return true;
    }

}
