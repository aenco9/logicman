using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dronBehavior : MonoBehaviour
{
    public float salud;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;
    public Collider2D caja;
    public Renderer rend;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        caja= GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        rend.enabled = true;
        salud = 100;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.collider.name);
        if (collision.collider.name == "disparo(Clone)")
        {
            salud -= 20;
            StartCoroutine(Flasher());
            //Debug.Log(rend.material.color);
        }


    }


    IEnumerator Flasher()
    {
        for (int i = 0; i < 2; i++)
        {
            rend.material.color = Color.black;
            yield return new WaitForSeconds(.05f);
            rend.material.color = Color.white;
            yield return new WaitForSeconds(.05f);
        }
    }


        // Update is called once per frame
        void Update()
    {
        if (salud <= 0)
        {
            
            audioSource.PlayOneShot(clip, volume);
            anim.SetBool("explotando", true);
            //rend.enabled = false;
            caja.enabled = false;
            Destroy(gameObject,clip.length);
            //y suena BOOM

        }
    }

   
}

