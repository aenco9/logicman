using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverPersonake : MonoBehaviour
{
    public float maxVelocidadX = 10;
    public float maxVelocidadY = 10;
    public float salud = 100;
    private Animator anim; //Variable para asignar el objeto que cambia la animación
    private SpriteRenderer sprRenderer;
    public bool enPiso = true; //Variable booleana que dice si el collider está siendo presionado por el piso
    private Rigidbody2D rigidbody;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;
    public Renderer rend;


    // METODOS
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprRenderer = GetComponent<SpriteRenderer>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        salud = 100;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 direction = collision.GetContact(0).normal;
        if(direction.y == 1){
            enPiso = true; //Cuando se acciona el collider de trigger, queda en true
        }else if (direction.y == -1)
        {
            enPiso = false;
        }
        if (collision.collider.name == "drone-1")
        {
            salud -= 20;
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        Vector2 direction = collision.GetContact(0).normal;
        if (direction.y == 1)
        {
            enPiso = true; //Cuando se acciona el collider de trigger, queda en true
        }
        else if (direction.y == -1)
        {
            enPiso = false;
        }
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
            if (transform.rotation.eulerAngles.y >= 0)
            {
                transform.Rotate(0f, -180f, 0f);
            }



        }
        else if (rigidbody.velocity.x < 0)
        {
            if (transform.rotation.eulerAngles.y < 0)
            {
                transform.Rotate(0f, 180f, 0f);
            }


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
        //Debug.Log(transform.rotation.eulerAngles.y);

        if (salud <= 0)
        {
            //
            audioSource.PlayOneShot(clip, volume);
            rend.enabled = false;
            //y suena BOOM

        }
    }
}