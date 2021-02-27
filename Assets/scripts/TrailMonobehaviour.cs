using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TrailMonobehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sprite> tracksSprites = new List<Sprite>();
    public List<GameObject> pathRenderers = new List<GameObject>();
    public List<GameObject> animalObjects = new List<GameObject>();
    public static string correctPath;
    public static string roamingAnimal;
    public static TrailGenerator tGen;
    public GameObject canvas;
    public GameObject textBox;
    void Start()
    {
        if(tGen ==null || SceneManager.GetActiveScene().name=="GameOver"){
            tGen = new TrailGenerator();
        }

        if(tGen.numberOfPaths >0){

            tGen.numberOfPaths--;
        }else{
            Debug.Log("final path");
            if(!tGen.firstTrail){
                SpawnAnimal(roamingAnimal);
                ScoreController.scoreCount++;
            }else{
                tGen.firstTrail=false;
            }
            tGen.GeneratePathLength();
            tGen.GenerateAnimal();
            roamingAnimal = tGen.currentAnimal;
            Debug.Log(roamingAnimal);
            FindNewAnimalTextBox();

        }
        correctPath = tGen.GeneratePath();
        SetAnimalTracks(correctPath);
        
    }
    public void FindNewAnimalTextBox(){
        GameObject textObj = Instantiate(textBox, new Vector3(0, 0, 0), Quaternion.identity);
        //textObj.transform.SetParent(canvas.transform);
        //textObj.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void SetAnimalTracks(string pathDirection){
        GameObject currentPath=null;
        Sprite currentSprite=null;
        List<GameObject> otherPaths = new List<GameObject>();
        foreach(GameObject go in pathRenderers){
            if(go.name.Contains(pathDirection)){
                currentPath = go;
            }else{
                otherPaths.Add(go);
            }
        }
        for(int i=0; i <tracksSprites.Count;i++){
            if(tracksSprites[i].name.Contains(tGen.currentAnimal)){
                currentSprite = tracksSprites[i];//set correct trail we should be following
            }else{
                otherPaths[0].GetComponent<SpriteRenderer>().sprite = tracksSprites[i];//put other footprints on other paths
                otherPaths.Remove(otherPaths[0]);
            }
        }
        currentPath.GetComponent<SpriteRenderer>().sprite = currentSprite;//put correct prints on correct path

    }
     public void SpawnAnimal(string animal){
         
        foreach(GameObject go in animalObjects){
             if(go.name==animal){
                Debug.Log("Spawn animal");
                GameObject animalObj = Instantiate(go, new Vector3(0, 0, 0), Quaternion.identity);
                animalObj.transform.SetParent(canvas.transform);
                animalObj.transform.localPosition = new Vector3(300, 30, 0);
                break;

             }

        }
     }

}
