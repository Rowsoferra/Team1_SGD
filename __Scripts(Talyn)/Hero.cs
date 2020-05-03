using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    static public Hero S; // Singleton

    [Header("Set in Inspector")]
    //These fields control ship movement
    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;
    public float gameRestartDelay = 2f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 40;

    [Header("Set Dynamically")]
    public Text creds;
    [SerializeField]
    public float _shieldLevel = 1;
    
    private GameObject lastTriggerGo = null;    
    public static int cred;
    
   
    void Awake()
    {
        if (S== null)
        {
            S = this; //Set the Singleton
        }        
        else
        {
            Debug.LogError("Hero.Awake() - Attempted to assign second Hero.S!");
        }
    }

    private void Start()
    {
        GameObject credO = GameObject.Find("creditsText");
        creds = credO.GetComponent<Text>();
        creds.text = "Credits: ";
    }

    // Update is called once per frame
    void Update()
    {
        //Pull info from the Input class
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        //Change transform.position based on axes
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

        //Rotate the ship to make it feel more dynamic
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TempFire();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            print("Quit Attempted");
        }
    }

    void TempFire()
    {
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        projGO.transform.position = transform.position;
        Rigidbody rigidB = projGO.GetComponent<Rigidbody>();
        rigidB.velocity = Vector3.up * projectileSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        print("Triggered: " + go.name);

        if(go == lastTriggerGo)
        {
            return;
        }
        lastTriggerGo = go;

        if(go.tag == "Enemy")
        {
            shieldLevel--;
            Destroy(go);
        }
        else if(go.tag == "Credit")
        {
            //this plays a fun noise
            SoundCon apScript = Camera.main.GetComponent<SoundCon>();
            apScript.Credited();
            //this should add credits to your credit count
            cred += 20;
            creds.text = "Credits: " + cred.ToString();
            print("gained 20 credits");
            //this destroys the gameObject
            Destroy(go);
        }
        else
        {
            print("Triggered by non-enemy: " + go.name);
        }
    }

    public float shieldLevel
    {
        get
        {
            return (_shieldLevel);
        }
        set
        {
            _shieldLevel = Mathf.Min(value, 4);

            //If the shield will be set to less than 0
            if(value < 0)
            {
                SoundCon apScript = Camera.main.GetComponent<SoundCon>();
                apScript.Destroyed();
                Destroy(this.gameObject);

                //Tell Main.S to restart game after a delay
                Main.S.DelayedRestart(gameRestartDelay);
            }
        }
    }
}
