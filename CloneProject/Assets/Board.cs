using UnityEngine;
using System.Collections;

//THis is a standard board with rows and columns that have no missing tiles
public class Board : MonoBehaviour
{

    public Tile[] m_TileList;
    public int Width;
    public int Height;

    // Use this for initialization
    void Start()
    {
        TileConnection();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void TileConnection()
    {
        //Getting the count of the tiles
        int TileCount = transform.childCount;

        //Creating an array to keep track of the tiles
        m_TileList = new Tile[TileCount];

        //Grabbing all of the positions
        for (int TileIndex = 0; TileIndex < TileCount; TileIndex++)
        {
            Transform ChildTransform = transform.GetChild(TileIndex);
               
            //Grabbing a reference to the Child components tile
            Tile child = m_TileList[TileIndex] = ChildTransform.GetComponent<Tile>();

            //assigning the Tile index
            child.TileIndex = TileIndex;

            AdjacenciesGenerator(child);
        }

    }

    void AdjacenciesGenerator(Tile NosyNeighbor)
    {
        //Give the tile their neighbors
        UpperNeighbors(NosyNeighbor);
        SameRowNeighbors(NosyNeighbor);
        BottomNeighbors(NosyNeighbor);

        //make sure that all neighbors are valid
        ValidateNeighbor(NosyNeighbor);
    }

    void UpperNeighbors(Tile NosyNeighbor)
    {
        //Upper left Neighbor
        NosyNeighbor.Nieghbor[Tile.UPPERLEFT] = NosyNeighbor.TileIndex - (Width + 1);
        //Upper Neighbor
        NosyNeighbor.Nieghbor[Tile.UPPER] = NosyNeighbor.TileIndex - (Width);
        //Upper Right Neighbor
        NosyNeighbor.Nieghbor[Tile.UPPERRIGHT] = NosyNeighbor.TileIndex - (Width - 1);
    }

    void SameRowNeighbors(Tile NosyNeighbor)
    {
        //Left Neightbor
        NosyNeighbor.Nieghbor[Tile.LEFT] = NosyNeighbor.TileIndex - 1;
        //Right Neighbor
        NosyNeighbor.Nieghbor[Tile.RIGHT] = NosyNeighbor.TileIndex + 1;
    }

    void BottomNeighbors(Tile NosyNeighbor)
    {
        //Bottom Left Neighbor
        NosyNeighbor.Nieghbor[Tile.BOTTOMLEFT] = NosyNeighbor.TileIndex + (Width - 1);
        //Bottom Neighbor
        NosyNeighbor.Nieghbor[Tile.BOTTOM] = NosyNeighbor.TileIndex + (Width);
        //Bottome Right Neighbor
        NosyNeighbor.Nieghbor[Tile.BOTTOMRIGHT] = NosyNeighbor.TileIndex + (Width + 1);
    }

    //Set all invalid tiles to neagtive one (-1)
    void ValidateNeighbor(Tile NosyNeighbor)
    {

        //Left Side
        if (NosyNeighbor.TileIndex % Width == 0)
        {
            NosyNeighbor.Nieghbor[Tile.LEFT] = -1;
            NosyNeighbor.Nieghbor[Tile.UPPERLEFT] = -1;
            NosyNeighbor.Nieghbor[Tile.BOTTOMLEFT] = -1;
        }

        //Upper
        if (NosyNeighbor.TileIndex < Width)
        {
            NosyNeighbor.Nieghbor[Tile.UPPER] = -1;
            NosyNeighbor.Nieghbor[Tile.UPPERLEFT] = -1;
            NosyNeighbor.Nieghbor[Tile.UPPERRIGHT] = -1;
        }

        //Right side
        if ((NosyNeighbor.TileIndex + 1) % Width == 0)
        {
            NosyNeighbor.Nieghbor[Tile.RIGHT] = -1;
            NosyNeighbor.Nieghbor[Tile.UPPERRIGHT] = -1;
            NosyNeighbor.Nieghbor[Tile.BOTTOMRIGHT] = -1;
        }

        //Bottom
        //Finding the last row
        int lastRow = (Width * Height) - Width;
        lastRow = lastRow - 1;

        if (NosyNeighbor.TileIndex > lastRow)
        {
            NosyNeighbor.Nieghbor[Tile.BOTTOM] = -1;
            NosyNeighbor.Nieghbor[Tile.BOTTOMLEFT] = -1;
            NosyNeighbor.Nieghbor[Tile.BOTTOMRIGHT] = -1;
        }
    }
}
