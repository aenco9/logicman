using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controla los movimientos del dron, sus animaciones 
 * y salud
 * Autor: Alejandro Enriquez Coronado
 */

public class DronBehavior : MonoBehaviour
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
        //Establece los parametros iniciales y la salud completa
        rend = GetComponent<Renderer>();
        caja= GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        salud = 100;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Cada que choca con un disparo de logicman, se reduce la salud por 20
        if (collision.collider.name == "disparo(Clone)")
        {
            salud -= 20;
            //Tambien se ejecuta la animacion para saber que le diste
            StartCoroutine(Flasher());
        }
    }


    IEnumerator Flasher()
    {
        //Hace al sprite cambiar de color rapidamente dos veces
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
        //Cuando se le acaba la salud, suena boom y desaparece el objeto
        if (salud <= 0)
        {
            audioSource.PlayOneShot(clip, volume);
            anim.SetBool("explotando", true);
            caja.enabled = false;
            Destroy(gameObject,clip.length);
        }
    }

   
}

