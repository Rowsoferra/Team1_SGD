using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverCon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("QuitOut");
    }

    IEnumerator QuitOut()
    {
        yield return new WaitForSecondsRealtime(14);
        Application.Quit();
        print("App Quit");
    }
}
