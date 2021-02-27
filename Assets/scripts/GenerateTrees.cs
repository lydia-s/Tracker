using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateTrees : MonoBehaviour
{
    public List<GameObject> trees = new List<GameObject>();
    float height;
    float width;
    int numTrees = 10;
    // Start is called before the first frame update
    void Start()
    {
        height = (gameObject.GetComponent<RectTransform>().rect.height/2f)-20f;
        width = (gameObject.GetComponent<RectTransform>().rect.width/2f)-20f;
        SpawnTrees();
        
    }
    void SpawnTrees(){
        float tempHeight;
        float tempWidth;
        int randTree;
        GameObject treeType;
        for(int i = numTrees; i>0;i--){
            randTree = Random.Range(0,2);
            treeType = trees.ElementAt(randTree);
            tempHeight = Random.Range(-height, height);
            tempWidth = Random.Range(-width, width);
            GameObject treeObj = Instantiate(treeType, new Vector3(0, 0, 0), Quaternion.identity);
            treeObj.transform.SetParent(gameObject.transform);
            treeObj.transform.localPosition = new Vector3(tempWidth, tempHeight, 0);

        }

    }
    // GameObject GetItemByIndex(int index){
        
    //     int count=0;
    //     foreach(GameObject go in trees){
    //         if(count==index){
    //             return go;

    //         }
    //         count++;
    //     }
    //     return default;

    // }


}
