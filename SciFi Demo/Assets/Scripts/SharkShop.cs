using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour
{
    //check colision
    //check if the player
    //check for e key
    //check if has coin
        //remove coin from player
        //update inventory display
        //play win sound
    //debug get out of here!

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {            
                Player player = other.GetComponent<Player>();
                if(player != null)
                {
                    if(player.hasCoin == true)
                    {
                        player.hasCoin = false;
                        UIManager uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();
                        if(uimanager != null)
                        {
                            uimanager.RemoveCoin();
                        }
                        AudioSource audio = GetComponent<AudioSource>();
                        audio.Play();
                        player.EnableWeapon();
                    }
                    else
                    {
                        Debug.Log("Get out of here!");
                    }
                }
               
            
        }    
    }
}
