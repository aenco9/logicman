using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaMovimiento : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 20f;
    public Rigidbody2D rigidbody;
    void Start()
    {
        rigidbody.velocity = transform.right * speed;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
