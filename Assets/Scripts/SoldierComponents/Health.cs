using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Health : MonoBehaviour
{
    //variable declaration
    private AudioClip dmg;
    public float currentHealth;
    public float maxHealth;
    public Image healthImage;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        dmg = GetComponent<Pawn>().controller.DmgSFX;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount, Pawn source)
    {
        //first take damage
        currentHealth = currentHealth - amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthImage.fillAmount = currentHealth / maxHealth;
        //play damage sound
        GetComponent<AudioSources>().SFXSource.PlayOneShot(dmg);
        
        
        //check if health is less than 0
        if (currentHealth <= 0) 
        {
            //check what kind of tank for diffferent scores
            if (GetComponent<Pawn>().controller is PlayerController)
            {
                source.controller.AddToScore(source.controller.scoreForPlayerKill);
            }
            else
            {
                source.controller.AddToScore(source.controller.scoreForAIKill);
            }
            //check if pawn is player
            if (GetComponent<Pawn>().controller is PlayerController)
            {
                //check if player has another life
                if (GetComponent<Pawn>().controller.playerLives > 0)
                {
                    currentHealth = maxHealth;
                    GetComponent<Pawn>().controller.playerLives -= 1;
                    GetComponent<Pawn>().GetComponent<HudValues>().lifeHud.text = "Lives: " + GetComponent<Pawn>().controller.playerLives.ToString();
                    
                }
                else
                {   
                    //null check
                    if(GameManager.instance != null)
                    {
                        //check if all players have 0 lives
                        int count = 0;
                        foreach (PlayerController player in GameManager.instance.players)
                        {
                            if(player.playerLives <= 0)
                            {
                                count++;
                            }
                        }
                        //if everyone is dead end game
                        if(count == GameManager.instance.players.Count)
                        {
                            GameManager.instance.DoGameOverState();
                        }
                        else
                        {
                            count = 0;
                        }

                    }
                    Die(source);
                }
            }
            else
            {
                Die(source);
            }
        }
    }
    //heal function
    public void Heal(float amount, Pawn source)
    {
        currentHealth = currentHealth + amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthImage.fillAmount = currentHealth / maxHealth;
    }
    //die function
    public void Die(Pawn source)
    {
        Destroy(gameObject);   
    }
}
