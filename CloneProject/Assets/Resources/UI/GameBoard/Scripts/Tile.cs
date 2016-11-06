using UnityEngine;
using System.Collections;


[RequireComponent(typeof(FieldDrop))]
public class Tile : MonoBehaviour
{
    //Tiles will mandate a droppable script -- avoids incorrect setup

    #region Tile Neighbor traverse Keywords
    public const int UPPERLEFT = 0;
    public const int UPPER = 1;
    public const int UPPERRIGHT = 2;
    public const int LEFT = 3;
    public const int RIGHT = 4;
    public const int BOTTOMLEFT = 5;
    public const int BOTTOM = 6;
    public const int BOTTOMRIGHT = 7;
    #endregion

    public int[] m_Nieghbor;
    public int m_nTileIndex;
    bool m_bHovered = false;

    public Color OnHover = Color.red;
    public Color Default = Color.white;

    SpriteRenderer render;
    Board m_cBoard = null;

    // Use this for initialization
    void Awake()
    {
        //Assigning the array to hold eight
        m_Nieghbor = new int[8];
    }

    void Start()
    {
        //Grabbing the renderer
        render = GetComponent<SpriteRenderer>();

        if (render == null)
        {
            Debug.Log("Render is null");
        }

        GameObject Board = GameObject.FindGameObjectWithTag("Board");
        m_cBoard = Board.GetComponent<Board>();
    }


    #region Event Handlers

    void OnMouseOver()
    {
        m_bHovered = true;
        NeighborsColorSwitch(m_bHovered);
    }

    void OnMouseExit()
    {
        m_bHovered = false;
        NeighborsColorSwitch(m_bHovered);
    }

    #endregion

    void NeighborsColorSwitch(bool lightsOn)
    {
        ColorSwitch(lightsOn);

        for (int NeighborIndex = 0; NeighborIndex < 8; NeighborIndex++)
        {
            int index = m_Nieghbor[NeighborIndex];

            if (index != -1)
            {
                m_cBoard.m_TileList[index].ColorSwitch(lightsOn);
            }

        }
    }

    void ColorSwitch(bool switchOn)
    {
        render.color = (switchOn) ? OnHover : Default;
    }

    #region Properties


    public int[] Nieghbor
    {
        get
        {
            return m_Nieghbor;
        }

        set
        {
            m_Nieghbor = value;
        }
    }

    public int TileIndex
    {
        get
        {
            return m_nTileIndex;
        }

        set
        {
            m_nTileIndex = value;
        }
    }
    #endregion

}
