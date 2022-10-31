using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField]
    private float sensitivity = 1f;
    //private float rotMin = -10f;
    //private float rotMax = 30f;    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * -1;        
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x += mouseY * sensitivity;
        //print(newRotation.x);
        //newRotation.x += Mathf.Clamp(mouseY * sensitivity, rotMin, rotMax);
        //newRotation.x =  Mathf.Clamp(newRotation.x, rotMin, rotMax);
        
        //transform.localEulerAngles = newRotation;  
        transform.localEulerAngles = new Vector3(newRotation.x, 0, 0);
    }
}
