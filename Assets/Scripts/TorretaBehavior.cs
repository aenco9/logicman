using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controla el comportamiento de las torretas como animaciones
 * y salud
 * Autor: Alejandro Enriquez Coronado
 */

public class TorretaBehavior : MonoBehaviour
{
    //Variables iniciales configurables
    public float salud =100;
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
        caja = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Cada que detecta una bala de logicman, disminuye su salud
        if (collision.collider.name == "disparo(Clone)")
        {
            salud -= 20;
            StartCoroutine(Flasher());
        }
    }

    IEnumerator Flasher()
    {
        //Cuando recibe daño, cambia el color dos veces rapidamente
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
        //Cuando si salud llega a 0, explota y se destruye el objeto
        if (salud <= 0)
        {
            audioSource.PlayOneShot(clip, volume);
            anim.SetBool("explotando", true);
            caja.enabled = false;
            Destroy(gameObject, clip.length);
        }
    }
}
