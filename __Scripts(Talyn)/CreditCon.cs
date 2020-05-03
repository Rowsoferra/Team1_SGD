using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditCon : MonoBehaviour
{
    public Vector3 dir = new Vector3(15, 30, 45);
    public float lifeTime = 6f;
    public float fadeTime = 4f;
    public float birthTime;


    private void Awake()
    {
        birthTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(dir * Time.deltaTime);
        float u = (Time.time - (birthTime + lifeTime)) / fadeTime;
        if(u >= 1)
        {
            Destroy(this.gameObject);
            return;
        }
    }
}
