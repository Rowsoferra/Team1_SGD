using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartCon : MonoBehaviour
{
    public Image helpPanel;


    private void Start()
    {
        helpPanel.gameObject.SetActive(false);
    }

    public void OnPlayClick()
    {
        SceneManager.LoadScene("Level");
    }

    public void OnExitClick()
    {
        Application.Quit();
        print("Quit attempted");
    }

    public void OnHelpClick()
    {
        helpPanel.gameObject.SetActive(true);
    }

    public void OnBackClick()
    {
        helpPanel.gameObject.SetActive(false);
    }
}
