using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    public GameObject UI;
    public GameObject question1;
    public GameObject question2;
    public GameObject question3;
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

        if (isShowing)
        {
            if(questionNum == 1)
            {
                questionUI.SetActive(true);
                isShowing = false;

                titleText.text = "Quelle quantité de nourriture est gaspillée chaque année dans le monde ?";
                tick1.GetComponentInChildren<Text>().text = "1 millier de tonnes";
                tick2.GetComponentInChildren<Text>().text = "1 million de tonnes";
                tick3.GetComponentInChildren<Text>().text = "1 millliard de tonnes";
            }
            else if(questionNum == 2)
            {
                questionUI.SetActive(true);
                isShowing = false;

                titleText.text = "Les océans sont égalements appelés les poumons de la planète car:";
                tick1.GetComponentInChildren<Text>().text = "Le flot des vagues ressemble au rythme de la respiration humaine";
                tick2.GetComponentInChildren<Text>().text = "La moitie? de l'oxyge?ne sur terre est produite par une plante qu’on trouve dans l’océan appelée le plancton.";
                tick3.GetComponentInChildren<Text>().text = "Les oce?ans fournissent de l'oxyge?ne aux créatures qui y vivent";
            }
            else if(questionNum == 3)
            {
                questionUI.SetActive(true);
                isShowing = false;

                titleText.text = "Au rythme actuel, d’ici 2050, Il y aura plus de plastiques dans les océans que de poissons.";
                tick2.GetComponentInChildren<Text>().text = "Vrai";
                tick3.GetComponentInChildren<Text>().text = "Faux";
                tick1.gameObject.SetActive(false);
            }            
        }

        if (count == 3)
        {
            exitMenu.SetActive(true);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ConfirmBtnClick()
    {
        if(questionNum == 1)
        {
            if (!tick1.isOn && !tick2.isOn && tick3.isOn)
            {
                questionUI.SetActive(false);
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
            if (tick2.isOn && !tick3.isOn)
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

        tick1.isOn = false;
        tick2.isOn = false;
        tick3.isOn = false;
    }

    public void OkBtnClick()
    {
        dialogBox.SetActive(false);
    }

    public void NextBtnClick()
    {
        SceneManager.LoadScene("Level2");
    }
}
