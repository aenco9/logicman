using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dronBehavior : MonoBehaviour
{
    public float salud;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;
    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        salud = 100;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.collider.name);
        if (collision.collider.name == "disparo(Clone)")
        {
            salud -= 20;
            //Debug.Log(salud);
        }


    }


    // Update is called once per frame
    void Update()
    {
        if (salud <= 0)
        {
            //
            audioSource.PlayOneShot(clip, volume);
            rend.enabled = false;
            Destroy(gameObject,clip.length);
            //y suena BOOM

        }
    }

   
}

