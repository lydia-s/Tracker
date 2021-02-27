using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    
    public float moveSpeed = 3.0f;
    public GameObject player;
    public GameObject playerSprite;
    Vector2 movement;
    public InputAction wasd;
    public InputAction attack;
    public InputAction mouse;
    Vector2 playerStill = new Vector2(0f,0f);
    bool playerIsResting = true;
    public CharacterController controller;
    bool playerWalksBack=false;

    void Start(){

        
        controller = this.GetComponent<CharacterController>();
        
        
    }

    void OnEnable(){
        wasd.Enable();
        mouse.Enable();
    }
    void OnDisable(){
        wasd.Disable();
        mouse.Disable();
    }
    //change sprite animation
    void TurnSprite(){
        

    if(wasd.ReadValue<Vector2>() == playerStill){
            player.GetComponent<Transform>().rotation = Quaternion.Euler(0,0,0);
            if(playerWalksBack){
                playerSprite.GetComponent<Animator>().Play("back_rest");

            }else{
                playerSprite.GetComponent<Animator>().Play("front_rest");
            }
            return;
        }
        else if(Keyboard.current.wKey.IsPressed() || Keyboard.current.sKey.IsPressed())
        {
            player.GetComponent<Transform>().rotation = Quaternion.Euler(0,0,0);
            if(Keyboard.current.sKey.IsPressed()){
                playerSprite.GetComponent<Animator>().Play("front_walk");
                playerWalksBack = false;
                
            }else{
                playerSprite.GetComponent<Animator>().Play("back_walk");
                playerWalksBack=true;
            }
        }
        else if(Keyboard.current.dKey.IsPressed() || Keyboard.current.aKey.IsPressed())
        {
            playerWalksBack=false;
            playerSprite.GetComponent<Animator>().Play("side_walk");
            if(Keyboard.current.aKey.IsPressed()){
                playerSprite.GetComponent<Transform>().rotation = Quaternion.Euler(0,180,0);
            }else{
                playerSprite.GetComponent<Transform>().rotation = Quaternion.Euler(0,0,0);
            }
            
        }
    }



    void Update(){
        
        
        TurnSprite();
        Vector2 inputVector = wasd.ReadValue<Vector2>();
        controller.Move(inputVector *Time.deltaTime *moveSpeed);
        }

    
   
    
}
