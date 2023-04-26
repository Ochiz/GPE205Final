using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
[System.Serializable]
public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    public KeyCode sprintKey;
    public KeyCode shootKey;
    public KeyCode optionsKey;
    public KeyCode playerTwomoveForwardKey;
    public KeyCode playerTwomoveBackwardKey;
    public KeyCode playerTworotateClockwiseKey;
    public KeyCode playerTworotateCounterClockwiseKey;
    public KeyCode playerTwosprintKey;
    public KeyCode playerTwoshootKey;
   
    private float progressToExtraLife;
    
    
    // Start is called before the first frame update
    public override void Start()
    {
        //null check
        if(GameManager.instance != null)
        {
            if(GameManager.instance.players != null)
            {
                GameManager.instance.players.Add(this);
            }
        }
        pawn.GetComponent<HudValues>().lifeHud.text = "Lives: " + playerLives.ToString();
        pawn.GetComponent<HudValues>().scoreHud.text = "Score: " + playerScore.ToString();
        progressToExtraLife = 0;
        // Run the Start() function from the parent (base) class
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        // Process our Keyboard Inputs
        ProcessInputs();

        // Run the Update() function from the parent (base) class
        base.Update();
    }
    //function called when destroyed
    public void OnDestroy()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.players != null)
            {
                GameManager.instance.players.Remove(this);
            }
        }
    }
    public override void Player2Controls()
    {
        moveForwardKey = playerTwomoveForwardKey;
        moveBackwardKey = playerTwomoveBackwardKey;
        rotateClockwiseKey = playerTworotateClockwiseKey;
        rotateCounterClockwiseKey = playerTworotateCounterClockwiseKey;
        sprintKey = playerTwosprintKey;
        shootKey = playerTwoshootKey;
    }
    //function to check player inputs
    public override void ProcessInputs()
    {
        if (Input.GetKey(moveForwardKey))
        {
            if (Input.GetKey(sprintKey))
            {
                pawn.MoveForward(true);
            }
            else
            {
                pawn.MoveForward(false);
            }
        }

        if (Input.GetKey(moveBackwardKey))
        {
            pawn.MoveBackward();
        }

        if (Input.GetKey(rotateClockwiseKey))
        {
            pawn.RotateClockwise();
        }

        if (Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
        }
        if (Input.GetKeyDown(shootKey))
        {
            pawn.Shoot();
        }
        if (Input.GetKeyDown(optionsKey))
        {
            if(GameManager.instance != null)
            {
                if(GameManager.instance.GamePlayScreenStateObject.activeSelf == true)
                {
                    GameManager.instance.DoOptionsState();
                }
                else
                {
                    GameManager.instance.ActivateGamePlayScreen();
                }
            }
        }
    }
    public override void AddToScore(float scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        pawn.GetComponent<HudValues>().scoreHud.text = "Score: " + playerScore.ToString();
        progressToExtraLife = progressToExtraLife + scoreToAdd;
        if(progressToExtraLife >= scoreToExtraLife)
        {
            playerLives += 1;
            pawn.GetComponent<HudValues>().lifeHud.text = "Lives: " + playerLives.ToString();
            progressToExtraLife = 0;
        }
    }
}