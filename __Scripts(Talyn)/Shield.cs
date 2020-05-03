using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float rotationsPerSec = .1f;

    [Header("Set Dynamically")]
    public int levelShown = 0;

    //This will not show in the inspector
    Material mat;


    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //Read current shield level from Hero Singleton
        int currLevel = Mathf.FloorToInt(Hero.S.shieldLevel);

        //If this is different from levelShown
        if(levelShown != currLevel)
        {
            levelShown = currLevel;

            //Adjust texture offset to show level
            mat.mainTextureOffset = new Vector2(.2f * levelShown, 0);

            //Rotate the shield in a time based way each frame
            float rZ = -(rotationsPerSec * Time.time * 360) % 360f;
            transform.rotation = Quaternion.Euler(0, 0, rZ);
        }
    }
}
