using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    [SerializeField]
    private GameObject caixaDestruida = null;

    public void DestroyCrate()
    {
        Instantiate(caixaDestruida, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
