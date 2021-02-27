using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MakePersistant : MonoBehaviour
{
    /*
     * This class is to keep game objects when scenes change
     */
    public static MakePersistant instance;

    private void Awake()
    {
        //Debug.Log("Object initialised");

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this )
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);


    }
    void Update(){
        if(SceneManager.GetActiveScene().name!="Trail"){
            Destroy(gameObject);
        }
    }

}