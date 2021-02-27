using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.InputSystem;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI dialogue;
    public GameObject dialogueBox;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText());

    }
    void Update(){
        if(Mouse.current.rightButton.wasPressedThisFrame){
                dialogueBox.SetActive(false);
            }
    }

    IEnumerator ShowText(){
        yield return new WaitForSeconds(0.5f);
        dialogue.text = "I saw a "+ TrailMonobehaviour.roamingAnimal + " around here. Follow the footprints.";  
        yield return new WaitForSeconds(1f);
        dialogue.text += "\n Right click to close";

    }
}
