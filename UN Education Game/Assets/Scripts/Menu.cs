using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject UI;
    public Button level1Btn;
    public Button level2Btn;
        
    void Start()
    {
        UI.transform.localScale = new Vector3(Screen.width / 1366f, Screen.height / 768f, 1);
    }

    
    void Update()
    {
        UI.transform.localScale = new Vector3(Screen.width / 1366f, Screen.height / 768f, 1);
    }

    public void Level1BtnClick()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level2BtnClick()
    {
        SceneManager.LoadScene("Level2");
    }
}
