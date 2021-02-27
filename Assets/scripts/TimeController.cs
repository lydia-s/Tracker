using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimeController : MonoBehaviour
{
    public float timeRemaining = 10f;
    public Text timer;
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timer.text = Mathf.RoundToInt(timeRemaining).ToString();
            
        }else{
            Debug.Log("GameOver");
            SceneManager.LoadScene("GameOver");
            ScoreController.scoreCount=0;
            
        }
    }
}
