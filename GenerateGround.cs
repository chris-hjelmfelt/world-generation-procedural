using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGround : MonoBehaviour
{
    public Transform prefab;
    public int chunkSize = 20;
    public int maxHeight = 3;
    private bool[,,] blocks;

    // Start is called before the first frame update
    void Start()
    {      
        blocks = new bool[chunkSize, chunkSize, maxHeight];
        int half = chunkSize/2;
        for (int h = 0; h < maxHeight; h++)
        {
          for (int w = -half; w < half; w++)
          {
            for (int l = -half; l < half; l++)
            {
              bool shouldPlace = placeBlock(l+half, w+half, h);
              if (shouldPlace){
                Instantiate(prefab, new Vector3(l * 1F, h * 1F, w * 1F), Quaternion.identity);
              }
            }
          }
        }
    }    

    // Update is called once per frame
    void Update()
    {
        
    }

    // Decide whether to place a block here
    bool placeBlock(int l,int w,int h) 
    {      
      //Debug.Log(blocks.GetLength(0) + " " + blocks.GetLength(1) + " " + blocks.GetLength(2) );
      //Debug.Log(l + " " + w + " " + h);

      if ( h == 0 ) { 
        blocks[l, w, 0] = true;    
        return true; 
      }
      
      int rand = Random.Range(0, 100);
      if ( blocks[l, w, h-1] == false ) { blocks[l,w,h] = false; return false; }  // make overhangs and blank spaces rare

      int totalRange = 5;  
      if( l == 0  ) { totalRange = totalRange + 20; }
      // See if it's touching on this side
      else if ( blocks[l-1, w, h] == true) { 
        // See if the block next to it is an edge 
        if (( l < chunkSize -1 && blocks[l+1, w, h-1] == false) || ( w > 0 && blocks[l, w-1 , h-1] == false) || (w < chunkSize -1 && blocks[l, w+1 , h-1] == false)){
          totalRange = totalRange + 10; 
        } else { totalRange = totalRange + 60; }
      }  
      if( l == chunkSize -1 ) { totalRange = totalRange + 20; }
      else if ( blocks[l+1, w, h] == true) { 
        if (( l > 0 && blocks[l-1, w, h-1] == false) || ( w > 0 && blocks[l, w-1 , h-1] == false) || (w < chunkSize -1 && blocks[l, w+1 , h-1] == false)){
          totalRange = totalRange + 10; 
        } else { totalRange = totalRange + 60; }
       }
      if( w == 0) { totalRange = totalRange + 20; }
      else if ( blocks[l, w-1, h] == true) { 
        if (( l > 0 && blocks[l-1, w, h-1] == false) || ( l < chunkSize -1 && blocks[l+1, w, h-1] == false) || (w < chunkSize -1 && blocks[l, w+1 , h-1] == false)){
          totalRange = totalRange + 10; 
        } else { totalRange = totalRange + 60; }
       }
      if( w == chunkSize -1) { totalRange = totalRange + 20; }
      else if ( blocks[l, w+1, h] == true) { 
        if (( l > 0 && blocks[l-1, w, h-1] == false) || ( l < chunkSize -1 && blocks[l+1, w, h-1] == false) || ( w > 0 && blocks[l, w-1 , h-1] == false)){
          totalRange = totalRange + 10; 
        } else { totalRange = totalRange + 60; }
       }

      rand = Random.Range(0, 100);
      if ( rand < totalRange ){
          blocks[l,w,h] = true;
          return true;    // place a block here        
      }

      blocks[l,w,h] = false;
      return false;
    }
}
