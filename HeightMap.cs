using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightMap : MonoBehaviour
{
    private int[] allValues;

    // Start is called before the first frame update
    void Start()
    {     
        /* 
        // This method of procedural generation uses the Diamond Square algorithm
        // It needs to be expanded so it can dynamically 
        // build the map for any array of points of 2N + 1
        */

        int heightMin = 2;
        int heightMax = 12;        
        int change = 0;
        int average = 0;

        allValues = new int[25];


        // Step1 fill corners
         /*
          0   1   2   3   4
          ^               ^
          5   6   7   8   9

          10  11  12  13  14

          15  16  17  18  19

          20  21  22  23  24
          ^               ^
        */
        // set them to a random number between min and max
        allValues[0] = Random.Range(heightMin, heightMax); 
        allValues[4] = Random.Range(heightMin, heightMax); 
        allValues[20] = Random.Range(heightMin, heightMax);
        allValues[24] = Random.Range(heightMin, heightMax); 


        // Step2 fill center
        // 12
        // use the average of the corner values, plus a random value
        average = (allValues[0] + allValues[4] + allValues[20] + allValues[24])/4;
        change = Random.Range(-2, 2);
        allValues[12] = average + change;


        //step3 fill outer middle
        /*
          0   1   2   3   4
                  ^
          5   6   7   8   9

          10  11  12  13  14
          ^               ^
          15  16  17  18  19

          20  21  22  23  24
                  ^
        */
        // 
        average = (allValues[0] + allValues[4] + allValues[12])/3;        
        change = Random.Range(-2, 2);
        allValues[2] = average + change;

        average = (allValues[0] + allValues[20] + allValues[12])/3;        
        change = Random.Range(-2, 2);
        allValues[10] = average + change;

        average = (allValues[4] + allValues[24] + allValues[12])/3;        
        change = Random.Range(-2, 2);
        allValues[14] = average + change;

        average = (allValues[20] + allValues[24] + allValues[12])/3;        
        change = Random.Range(-2, 2);
        allValues[22] = average + change;


        // Step4 fill inner corners
        /*
          0   1   2   3   4
          
          5   6   7   8   9
              ^       ^
          10  11  12  13  14

          15  16  17  18  19
              ^        ^
          20  21  22  23  24

        */
        // use the average of the two nearest corners and the center, plus a random value
        average = (allValues[0] + allValues[2] + allValues[10] + allValues[12])/4;        
        change = Random.Range(-2, 2);
        allValues[6] = average + change;

        average = (allValues[2] + allValues[4] + allValues[12] + allValues[14])/4;        
        change = Random.Range(-2, 2);
        allValues[8] = average + change;

        average = (allValues[10] + allValues[12] + allValues[20] + allValues[22])/4;        
        change = Random.Range(-2, 2);
        allValues[16] = average + change;

        average = (allValues[12] + allValues[14] + allValues[22] + allValues[24])/4;        
        change = Random.Range(-2, 2);
        allValues[18] = average + change;


        // Step 5   Fill in the remaining
        /*
          0   1   2   3   4
              ^       ^
          5   6   7   8   9
          ^       ^       ^
          10  11  12  13  14
              ^       ^ 
          15  16  17  18  19
          ^       ^       ^
          20  21  22  23  24
              ^        ^
        */
        // Take the average of the 3 or 4 surrounding
        average = (allValues[0] + allValues[2] + allValues[6])/3;        
        change = Random.Range(-2, 2);
        allValues[1] = average + change;

        average = (allValues[2] + allValues[4] + allValues[8])/3;        
        change = Random.Range(-2, 2);
        allValues[3] = average + change;

        average = (allValues[0] + allValues[6] + allValues[10])/3;        
        change = Random.Range(-2, 2);
        allValues[5] = average + change;

        average = (allValues[2] + allValues[6] + allValues[8] + allValues[12])/4;        
        change = Random.Range(-2, 2);
        allValues[7] = average + change;

        average = (allValues[4] + allValues[8] + allValues[14])/3;        
        change = Random.Range(-2, 2);
        allValues[9] = average + change;

        average = (allValues[6] + allValues[10] + allValues[12] + allValues[16])/4;        
        change = Random.Range(-2, 2);
        allValues[11] = average + change;

        average = (allValues[8] + allValues[12] + allValues[14] + allValues[18])/4;        
        change = Random.Range(-2, 2);
        allValues[13] = average + change;

        average = (allValues[10] + allValues[16] + allValues[20])/3;        
        change = Random.Range(-2, 2);
        allValues[15] = average + change;

        average = (allValues[12] + allValues[16] + allValues[18] + allValues[22])/4;        
        change = Random.Range(-2, 2);
        allValues[17] = average + change;

        average = (allValues[14] + allValues[18] + allValues[24])/3;        
        change = Random.Range(-2, 2);
        allValues[19] = average + change;

        average = (allValues[16] + allValues[20] + allValues[22])/3;        
        change = Random.Range(-2, 2);
        allValues[21] = average + change;

        average = (allValues[18] + allValues[22] + allValues[24])/3;        
        change = Random.Range(-2, 2);
        allValues[23] = average + change;

        // Show the height map
        displayMap();
    }    

    // Update is called once per frame
    void Update()
    {
        
    }


    void displayMap(){
      // For now just print values
      for (int i=0; i < 25; i+=5) {
        Debug.Log(allValues[0+i] + " " + allValues[1+i] + " " + allValues[2+i] + " " + allValues[3+i] + " " + allValues[4+i]);
      }
  
    }
   
}
