using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public void createMap() {
        float[,] noiseMap = PerlinNoise.GenerateNoiseMap(mapWidth, mapHeight, noiseScale);

        // draw to screen
        MapDisplay display = FindObjectOfType<MapDisplay> ();
        display.DrawNoiseMap(noiseMap);
    }

    void Start()
    { 
        createMap();
    }    

    // Update the map when values in the inspector are changed
    private void OnValidate() 
    {
        Debug.Log("changed");
        createMap();
    }
}
