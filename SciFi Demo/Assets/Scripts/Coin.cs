using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private AudioClip coinSound = null;
    //private AudioSource coinSound = null;

    // Start is called before the first frame update
    void Start()
    {
        //coinSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // onTriggerEnter        
        // checar se o jogador está na area
        // checar se tecla E pressionada
        // coletar moeda
        // tocar som de moeda
        // destruir moeda
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")        {
        
                Player player = other.GetComponent<Player>();
                if(player != null)
                {
                    player.hasCoin = true;
                    //coinSound.Play();
                    AudioSource.PlayClipAtPoint(coinSound, transform.position, 1f);

                    UIManager uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();
                    if(uimanager != null)
                    {
                        uimanager.CollectedCoin();
                    }

                    Destroy(this.gameObject);
                }
            
        }
    }
}
