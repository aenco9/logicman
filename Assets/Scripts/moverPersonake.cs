using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverPersonake : MonoBehaviour
{
    public float maxVelocidadX = 10;
    public float maxVelocidadY = 10;

    private Rigidbody2D rigidbody;
    

    // METODOS
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(movHorizontal * maxVelocidadX, rigidbody.velocity.y);
        float movVertical = Input.GetAxis("Jump");      // [0, 1]
        if (movVertical > 0)
        {
            //rigidbody.velocity = new Vector2(rigidbody.velocity.x, movVertical * velocidadY);
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, movVertical * maxVelocidadY);
        }


    }
}
