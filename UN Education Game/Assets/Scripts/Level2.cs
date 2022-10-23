using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Level2 : MonoBehaviour
{
    public GameObject UI;
    public GameObject question1;
    public GameObject question2;
    public GameObject question3;
    public GameObject question4;
    public GameObject questionUI;
    public GameObject dialogBox;
    public GameObject exitMenu;

    public CharacterController player;

    public Text titleText;
    public Toggle tick1;
    public Toggle tick2;
    public Toggle tick3;

    int questionNum = 0;
    int count = 0;
    bool isShowing = false;

    private void Start()
    {
        UI.transform.localScale = new Vector3(Screen.width / 1366f, Screen.height / 768f, 1);
    }

    private void Update()
    {
        UI.transform.localScale = new Vector3(Screen.width / 1366f, Screen.height / 768f, 1);
                
        if (question1.gameObject != null && Vector3.Distance(player.transform.position, question1.transform.position) <= 2.0f)
        {
            questionNum = 1;
            isShowing = true;
            Destroy(question1);
        }
        else if (question2.gameObject != null && Vector3.Distance(player.transform.position, question2.transform.position) <= 2.0f)
        {
            questionNum = 2;
            isShowing = true;
            Destroy(question2);
        }
        else if (question3.gameObject != null && Vector3.Distance(player.transform.position, question3.transform.position) <= 2.0f)
        {
            questionNum = 3;
            isShowing = true;
            Destroy(question3);
        }
        else if (question4.gameObject != null && Vector3.Distance(player.transform.position, question4.transform.position) <= 2.0f)
        {
            questionNum = 4;
            isShowing = true;
            Destroy(question4);
        }

        if (isShowing)
        {
            if(questionNum == 1)
            {
                questionUI.SetActive(true);
                isShowing = false;

                titleText.text = "En 2020, dans le monde, 781 millions de personnes de plus de 15ans ne savent ni lire ni écrire.";
                tick1.gameObject.SetActive(false);
                tick2.GetComponentInChildren<Text>().text = "Vrai";
                tick3.GetComponentInChildren<Text>().text = "Faux";
            }
            else if(questionNum == 2)
            {
                questionUI.SetActive(true);
                isShowing = false;

                titleText.text = "Quel pays a la plus forte densité de médecins au monde par 1000 habitants en 2018 ?";
                tick1.GetComponentInChildren<Text>().text = "La Suède";
                tick2.GetComponentInChildren<Text>().text = "Cuba";
                tick3.GetComponentInChildren<Text>().text = "Le Maroc";
            }
            else if(questionNum == 3)
            {
                questionUI.SetActive(true);
                isShowing = false;

                titleText.text = "Combien de femmes dans le monde sont victimes de violence physique ou sexuelle en 2021 au moins 1 fois dans leur vie ?";
                tick1.GetComponentInChildren<Text>().text = "1 sur 3 (736 mio selon l’ONU)";
                tick2.GetComponentInChildren<Text>().text = "2 sur 3";
                tick3.GetComponentInChildren<Text>().text = "3 sur 3";                
            }    
            else if (questionNum == 4)
            {
                questionUI.SetActive(true);
                isShowing = false;

                titleText.text = "En 2021, 56% des femmes en Jordanie n’ont pas d’activité professionnelle.";
                tick1.gameObject.SetActive(false);
                tick2.GetComponentInChildren<Text>().text = "Vrai";
                tick3.GetComponentInChildren<Text>().text = "Faux, 86% des femmes en Jordanie n’ont pas d’activité professionnelle";
            }
        }

        if (count == 4)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            exitMenu.SetActive(true);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }    

    // UI
    public void ConfirmBtnClick()
    {
        if(questionNum == 1)
        {
            if (tick2.isOn && !tick3.isOn)
            {
                questionUI.SetActive(false);
                tick1.gameObject.SetActive(true);
                count++;
            }
            else
            {
                dialogBox.SetActive(true);
            }
        }
        else if(questionNum == 2)
        {
            if (!tick1.isOn && tick2.isOn && !tick3.isOn)
            {
                questionUI.SetActive(false);
                player.gameObject.SetActive(true);
                count++;      
            }
            else
            {
                dialogBox.SetActive(true);
            }
        }
        else if(questionNum == 3)
        {
            if (tick1.isOn && !tick2.isOn && !tick3.isOn)
            {
                questionUI.SetActive(false);
                player.gameObject.SetActive(true);
                count++;
            }
            else
            {
                dialogBox.SetActive(true);
            }
        }

        else if (questionNum == 4)
        {
            if (!tick2.isOn && tick3.isOn)
            {
                questionUI.SetActive(false);
                player.gameObject.SetActive(true);
                tick1.gameObject.SetActive(true);
                count++;       
            }
            else
            {
                dialogBox.SetActive(true);
            }
        }

        tick1.isOn = false;
        tick2.isOn = false;
        tick3.isOn = false;
    }

    public void OkBtnClick()
    {
        dialogBox.SetActive(false);
    }

    public void ExitBtnClick()
    {
        Application.Quit();
    }
}
