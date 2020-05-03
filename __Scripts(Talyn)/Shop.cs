using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Image quitPanel;
    public Image purchasingPanel;
    public Text purchasingText;
    public Button shieldButton;
    public Button spreadButton;
    public Button backupButton;


    private void Start()
    {
        quitPanel.gameObject.SetActive(false);
        purchasingPanel.gameObject.SetActive(false);
        purchasingText.text = "";
        shieldButton.interactable = true;
        spreadButton.interactable = true;
        backupButton.interactable = true;
    }

    public void OnReturnClick()
    {
        SceneManager.LoadScene("Level");
    }

    public void OnExitClick()
    {
        quitPanel.gameObject.SetActive(true);
    }

    public void Yes()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void No()
    {
        quitPanel.gameObject.SetActive(false);
    }

    public void ShieldButton()
    {
        if (Hero.cred >= 40)
        {
            //Hero.cred -= 1200;
            Hero._shieldLevel ++;
            shieldButton.interactable = false;
            purchasingPanel.gameObject.SetActive(true);
            purchasingText.text = "Shield Purchased!";
            StartCoroutine("GetRid");
            print("shield purchased");
        }
        else
        {
            purchasingPanel.gameObject.SetActive(true);
            purchasingText.text = "Not enough Credits";
            StartCoroutine("GetRid");
            print("not enough credits");
        }
    }

    public void SpreadButton()
    {
        if (Hero.cred >= 40)
        {
            //Hero.cred -= 6400;
            spreadButton.interactable = false;
            purchasingPanel.gameObject.SetActive(true);
            purchasingText.text = "Spreadgun Purchased!";
            StartCoroutine("GetRid");
            print("spread purchased");
        }
        else
        {
            purchasingPanel.gameObject.SetActive(true);
            purchasingText.text = "Not enough Credits";
            StartCoroutine("GetRid");
            print("not enough credits");
        }
    }

    public void BackupButton()
    {
        if (Hero.cred >= 40)
        {
            //Hero.cred -= 10000;
            backupButton.interactable = false;
            purchasingPanel.gameObject.SetActive(true);
            purchasingText.text = "Backup Standing By!";
            StartCoroutine("GetRid");
            print("backup purchased");
        }
        else
        {
            purchasingPanel.gameObject.SetActive(true);
            purchasingText.text = "Not enough Credits";
            StartCoroutine("GetRid");
            print("not enough credits");
        }
    }

    IEnumerator GetRid()
    {
        yield return new WaitForSeconds(3);
        purchasingPanel.gameObject.SetActive(false);
    }
}
