using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private int mapWidth = 300;
    private int mapHeight = 300;
    private float noiseScale = 60;
    private int octaves = 4;
    private float persistance = 0.5f;
    private float lacunarity = 2.0f;

    public void createMap() {
        float[,] noiseMap = PerlinNoise.GenerateNoiseMap(mapWidth, mapHeight, noiseScale, octaves, persistance, lacunarity);

        // draw to screen
        // MapDisplay display = FindObjectOfType<MapDisplay> ();
        // display.DrawNoiseMap(noiseMap);

        // create terrian with blocks
        PlaceBlocks display = FindObjectOfType<PlaceBlocks> ();
        display.CreateBlockTerrian(noiseMap);
    }

    void Start()
    { 
        createMap();
    }    

    // Update the map when values in the inspector are changed
    // private void OnValidate() 
    // {
    //     Debug.Log("changed");
    //     createMap();
    // }
}
