using UnityEngine;
using System.Collections;
using System.IO;

public class SpriteDatabase : MonoBehaviour
{
    //database object
    static private BaseDatabase<string, VisualInfo> spriteDatabase = null;
    private const string AnimationFolderPath = "Animantion/Animation/";
    private const string AnimationControllerFolderPath = "Animation/Controllers/";
    private const string SpriteFolderPath = "Animation/Sprites/";

    private bool init = false;

    void Initialize()
    {
        if (!init)
        {
            spriteDatabase = new BaseDatabase<string, VisualInfo>();
            Load("Library/Library.txt");
            init = true;
        }

    }


    //load information
    public bool Load(string _file)
    {
        if (0 == _file.Length)
            return false;

        //create a reader and opne the file
        StreamReader ifs = new StreamReader(Application.dataPath + "/Resources/" + _file);

        //temporary string for reading values
        string line;
        string[] lineParse;
        char[] delims = { '\n', '\r', '-', '\t' };

        //read the first line : ID
        line = ifs.ReadLine();
        //parse until EOF
        while (line != null)
        {
            //line data : ID
            lineParse = line.Split(delims);
            //confirm the size
            if (4 == lineParse.Length)
            {
                VisualInfo visualData = new VisualInfo();
                CardIdentifier cardID = new CardIdentifier(lineParse[0], lineParse[2], lineParse[1]);

                string spritePath = SpriteFolderPath + cardID.FactionID + "/" + cardID.UniqueID;
                string animatorPath = AnimationControllerFolderPath + cardID.FactionID + "/" + cardID.UniqueID + "_0";

                //load visual information
                if (visualData.Load(spritePath, animatorPath))
                {
                    //add into database
                    spriteDatabase.AddEntry(cardID.ID, ref visualData);
                }
            }
            //read the next line
            line = ifs.ReadLine();
        }

        ifs.Close();

        return true;
    }

    public Sprite GetSprite(string _key)
    {
        if (!this.Database.Storage.ContainsKey(_key))
            return null;
        return this.Database.Storage[_key].Sprite;
    }

    public RuntimeAnimatorController GetAnimator(string _key)
    {
        if (!this.Database.Storage.ContainsKey(_key))
            return null;
        return this.Database.Storage[_key].RuntimeAnimatorController;
    }

    public VisualInfo Get(string _key)
    {
        if (!this.Database.Storage.ContainsKey(_key))
            return null;

        return this.Database.Storage[_key];
    }

    public BaseDatabase<string, VisualInfo> Database { get { Initialize(); return spriteDatabase; } }
}
