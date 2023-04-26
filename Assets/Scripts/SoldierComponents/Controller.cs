using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public abstract class Controller : MonoBehaviour
{
    //variable declaration
    public Pawn pawn;
    public AudioClip ShootSFX;
    public AudioClip DmgSFX;
    public int scoreForAIKill;
    public int scoreForPlayerKill;
    public float playerScore;
    public int playerLives;
    public float scoreToExtraLife;
    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
    //functions to be overwritten
    public abstract void ProcessInputs();
    public abstract void AddToScore(float scoreToAdd);
    public abstract void Player2Controls();
}
