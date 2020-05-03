using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]
    public float speed = 10f;   //speed in m/s
    public float fireRate = .3f;    //seconds/shot
    public float health = 5;
    public GameObject creditPrefab;

    [Header("Set Dynamically")]
    public static int des;  //how many enemies you have destroyed
    public Text enDes;
    public Text creds;

    private BoundsCheck bndCheck;


    void Start()
    {
        GameObject enDesO = GameObject.Find("enDesText");
        enDes = enDesO.GetComponent<Text>();
        enDes.text = "Enemies Destroyed: ";        
    }

    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }

    //This is a Property (method acting as a field)
    public Vector3 pos
    {
        get
        {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if(bndCheck != null && bndCheck.offDown)    //checks if enemy moves offscreen
        {         
            Destroy(gameObject);    //and if it is, destroy it            
        }
    }

    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject otherGO = coll.gameObject;

        if(otherGO.tag == "ProjectileHero")
        {            
            SoundCon apScript = Camera.main.GetComponent<SoundCon>();
            apScript.Destroyed();
            Destroy(otherGO);
            Destroy(gameObject);
            des++;
            enDes.text = "Enemies Destroyed " + des.ToString();
            print("Score increased");

            int cd = Random.Range(1, 10);
            if(cd < 4)
            {
                DropCredits();
            }            
        }
        else
        {
            print("Enemy hit by non-ProjectileHero: " + otherGO.name);
        }
    }

    public void DropCredits()
    {
        GameObject credit = Instantiate<GameObject>(creditPrefab);
        credit.transform.position = transform.position;
    }
}
