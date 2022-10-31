using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField]
    private float speed = 3.5f;
    private float grativy = 9.8f;

    //[SerializeField]
    //private GameObject tiro = null;
    [SerializeField]
    private GameObject hitmarker = null;
    [SerializeField]
    private AudioSource shootsound = null;

    [SerializeField]
    private int municao = 0;
    private int maxMunicao = 500;
    private bool isRecharging = false;

    private UIManager uiManager;

    public bool hasCoin = false;

    [SerializeField]
    private GameObject weapon = null;

    // Variavel para armazenar a particula para que ela dê play ao atirar
    [SerializeField]private ParticleSystem particula = null;

    //Variavel para movimento com Input System
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        //esconder mouse
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;      

        //municao = maxMunicao;  

        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetMouseButtonDown(0))
        if(Input.GetMouseButtonDown(0) && municao > 0)
        {
           Shoot();
        }
        else
        {
            //tiro.SetActive(false);
            //shootsound.Stop();
        }

        //aparecer o mouse quando apertar esc
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;            
        }

        if(Input.GetKeyDown(KeyCode.R) && isRecharging == false)
        {
            isRecharging = true;
            StartCoroutine(Recharge());
        }

        calculateMovement();
        //calculateInputMovement();
    }

    void calculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        //Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        Vector3 velocity = direction * speed;
        
        velocity.y -= grativy;
        velocity = transform.transform.TransformDirection(velocity);

        controller.Move(velocity * Time.deltaTime);
        //controller.Move(direction);

    }

    void calculateInputMovement()
    {
        Vector3 direction = new Vector3(movement.x, 0, movement.z);
        Vector3 velocity = direction * speed;
        
        velocity.y -= grativy;
        velocity = transform.transform.TransformDirection(velocity);

        controller.Move(velocity * Time.deltaTime);
    }

    public void InputMove(InputAction.CallbackContext value)
    {
        movement = value.ReadValue<Vector3>();
    }

    void Shoot()
    {
            // Ray rayOrigin = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2f, Screen.height/2f,0));

            // if(Physics.Raycast(rayOrigin, Mathf.Infinity))
            // {
            //    Debug.Log("Raycast Hit Something!");
            // }

            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
            RaycastHit hitInfo;

            //tiro.SetActive(true);
            particula.Play();
            municao--;

            uiManager.UpdateMunicao(municao);

            //se ainda não tiver tocando, vai tocar
            if(shootsound.isPlaying == false)
            {
                shootsound.Play();
            }             

            if(Physics.Raycast(rayOrigin, out hitInfo))
            {
               Debug.Log("Hit: " + hitInfo.transform.name);
               GameObject hm = Instantiate(hitmarker, hitInfo.point, Quaternion.LookRotation(hitInfo.normal)); //Quaternion.identity               
               Destroy(hm, 1f);
            }   

            //check hit crate
            Destroyable crate = hitInfo.transform.GetComponent<Destroyable>();
            if(crate != null)
            {
                crate.DestroyCrate();
            }
            //destroy crate
                                 

    }

    IEnumerator Recharge()
    {
        yield return new WaitForSeconds(1.5f);
        municao = maxMunicao;
        uiManager.UpdateMunicao(maxMunicao);

        isRecharging = false;
    }

    public void EnableWeapon()
    {
        weapon.SetActive(true);
    }

    
}
