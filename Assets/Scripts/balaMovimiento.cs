using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Determina el movimiento de la vala asignandole
 * una velocidad despues de ser creada
 * Autor: Alejandro Enriquez Coronado
 */

public class BalaMovimiento : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 20f;
    public Rigidbody2D rigidbody;
    private Animator anim;
    void Start()
    {
        //Se le asigna la velocidad inicial e identifica el animator
        rigidbody.velocity = transform.right * speed;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //cuando detecta una colision, asigna el parámetro booleano de animacion y destruye el objeto en 0.2s
        anim.SetBool("choque", true);
        Destroy(gameObject, 0.2f);
    }
}
