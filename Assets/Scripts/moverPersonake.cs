using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverPersonake : MonoBehaviour
{
    public float maxVelocidadX = 10;
    public float maxVelocidadY = 10;
    private Animator anim; //Variable para asignar el objeto que cambia la animación
    private SpriteRenderer sprRenderer;
    public bool enPiso = true; //Variable booleana que dice si el collider está siendo presionado por el piso
    private Rigidbody2D rigidbody;
    

    // METODOS
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        enPiso = true; //Cuando se acciona el collider de trigger, queda en true
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        enPiso = false; //Al saltar se desactiva
    }



    // Update is called once per frame
    void Update()
    {
        float movHorizontal = Input.GetAxis("Horizontal"); //Controles del personaje con el teclado
        rigidbody.velocity = new Vector2(movHorizontal * maxVelocidadX, rigidbody.velocity.y);
        float movVertical = Input.GetAxis("Jump");      // [0, 1]
        if (movVertical > 0 && enPiso) //Si se ha precionado espacio y el jugador está en el piso, puede brincar
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, movVertical * maxVelocidadY);
            anim.SetBool(name: "saltando", true);
        }

        if (rigidbody.velocity.x > 0) //Cambiar la dirección del sprite dependiendo de la velocidad
        {
            sprRenderer.flipX = false;
        }
        else if (rigidbody.velocity.x < 0)
        {
            sprRenderer.flipX = true;
        }
        if (Mathf.Abs(rigidbody.velocity.x) > 0) //Fijar la variable moviendo para las condiciones de transición de las animaciones
        {
            anim.SetBool(name: "corriendo", true);

        }
        else
        {
            anim.SetBool(name: "corriendo", false);
        }
        if (Mathf.Abs(rigidbody.velocity.y) > 0.5) //Si la velocidad en Y es mayor a 0.5, cambia a brincando. En 0 ocurrían saltos con muy poca altura.
        {
            anim.SetBool(name: "saltando", true);

        }
        else
        {
            anim.SetBool(name: "saltando", false);
        }
       // Debug.Log(enPiso);
    }
}
