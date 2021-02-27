using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.name.Contains(TrailMonobehaviour.correctPath)){
            SceneManager.LoadScene("Trail");
        }else{
            SceneManager.LoadScene("GameOver");
            ScoreController.scoreCount=0;
        }
        
    }
    
}
