using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaMovimiento : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 20f;
    public Rigidbody2D rigidbody;
    private Animator anim;
    void Start()
    {
        rigidbody.velocity = transform.right * speed;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {

        anim.SetBool("choque", true);
        Destroy(gameObject, 0.2f);
        //Debug.Log("ya");
    }
}
