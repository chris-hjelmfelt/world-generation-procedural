using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural : MonoBehaviour
{
    public Transform airPrefab;
    public Transform stonePrefab;
    public Transform waterPrefab;
    private int chunkSize = 120;
    private int mainSurface = 40;
    private float frequency = 0.05f;
    private float amplitude = 8.0f;
    private float seaLevel = 43;
	
    void Start()
    {       
        for (int l = 0; l < chunkSize; l++)
        {
          var x = l * 3;
          for (int w = 0; w < chunkSize; w++)
          {   
            var z = w * 3;      	           
            var xOffset = Mathf.Sin((float)x * frequency) * amplitude; 
            var zOffset = Mathf.Sin((float)z * frequency) * amplitude;
            var surface = mainSurface + xOffset + zOffset;                   
            //Debug.Log(surface);

            for (int h = 0; h < chunkSize/2; h++)
            {     
              Transform blockType = airPrefab;    // 0 = air, 1 = stone, 2 = water
              if (h < surface){
                blockType = stonePrefab;
              }
              else if (h < seaLevel) {
                blockType = waterPrefab;
              } 
              Instantiate(blockType, new Vector3(l * 1F, h * 1F, w * 1F), Quaternion.identity);
            }
          }
        }
    }	
}
