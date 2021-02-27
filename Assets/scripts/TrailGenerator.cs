using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailGenerator
{
    public bool firstTrail=true;
    public int numberOfPaths;
    List<string> animalTypes = new List<string>{"bear", "fox","deer"};
    public string currentAnimal="deer";
    public string GeneratePath(){
        string direction = "center";
        int intDirection = Random.Range(1,4);
        switch(intDirection){
            case 1:
            direction = "left";
            break;
            case 2:
            direction = "center";
            break;
            case 3:
            direction = "right";
            break;
            default:
            break;
        }
        //Debug.Log(direction);
        return direction;

    }

    public void GeneratePathLength(){
        numberOfPaths = Random.Range(3,6);
        Debug.Log(numberOfPaths);
    }
    public void GenerateAnimal(){
        int intAnimal = Random.Range(0,animalTypes.Count);
        currentAnimal= animalTypes[intAnimal];
        //Debug.Log(animalTypes[intAnimal]);
        
    }

}
