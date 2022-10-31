using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject creditPanel = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        //Editor da Unity
        UnityEditor.EditorApplication.isPlaying = false;
        //Compilado
        //Application.Quit();
    }

    public void ShowCredit()
    {
        creditPanel.SetActive(true);
    }

    public void BackMenu()
    {
        creditPanel.SetActive(false);
    }
}
