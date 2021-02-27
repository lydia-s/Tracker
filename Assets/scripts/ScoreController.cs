using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour
{
    public Text scoreText;
    public static int scoreCount=0;
    void Start()
    {
        scoreText.text = scoreCount.ToString();
        StartCoroutine(UpdateScore());
        
    }
    IEnumerator UpdateScore(){
        yield return new WaitForSeconds(0.5f);
        scoreText.text = scoreCount.ToString();
    }


}
