using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Text municaoText;

    [SerializeField]
    private GameObject coin;

    public void UpdateMunicao(int count)
    {
        municaoText.text = "Munição: " + count;
    }

    public void CollectedCoin()
    {
        coin.SetActive(true);
    }

    public void RemoveCoin()
    {
        coin.SetActive(false);
    }

}
