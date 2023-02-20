using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBlocks : MonoBehaviour
{
    public Transform airPrefab;
    public Transform stonePrefab;
    public Transform waterPrefab;
    private int mainSurface = 1;    
    private float amplitude = 20;
	
    public void CreateBlockTerrian(float[,] noiseMap) 
    {  
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);
        float seaLevel = Mathf.Floor(mainSurface + amplitude/2);

        for (int l = 0; l < height; l++)
        {
          for (int w = 0; w < width; w++)
          {  
            var surface = mainSurface + noiseMap[l,w] * amplitude;                 
            //Debug.Log(noiseMap[l,w]);

            for (int h = 0; h < (mainSurface + amplitude); h++)
            {     
                Transform blockType = airPrefab;    // 0 = air, 1 = stone, 2 = water
                if (h < surface){
                  blockType = stonePrefab;
                }
                else if (h < seaLevel) {
                  blockType = waterPrefab;
                } 

                if (blockType != airPrefab) {
                  Instantiate(blockType, new Vector3(l * 1F, h * 1F, w * 1F), Quaternion.identity);
                }
            }
          }
        }
    }	
}
