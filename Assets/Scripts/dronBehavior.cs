using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dronBehavior : MonoBehaviour
{
    public float salud;
    // Start is called before the first frame update
    void Start()
    {
        salud = 100;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        salud -= 20;
        Debug.Log(salud);
    }


    // Update is called once per frame
    void Update()
    {
        if (salud <= 0)
        {
            Destroy(gameObject);
            //y suena BOOM
        }
    }
}
