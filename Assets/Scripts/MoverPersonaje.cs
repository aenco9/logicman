using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Script que controla la salud, movimiento
 * y animaciones del sprite principal
 * Autor: Alejandro Enriquez Coronado
 */

public class MoverPersonaje : MonoBehaviour
{
    public float maxVelocidadX = 10;
    public float maxVelocidadY = 10;
    public float salud = 100;
    private Animator anim; //Variable para asignar el objeto que cambia la animaci�n
    private SpriteRenderer sprRenderer;
    public bool enPiso = true; //Variable booleana que dice si el collider est� siendo presionado por el piso
    private Rigidbody2D rigidbody;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;
    public Renderer rend;
    private BoxCollider2D caja;
    private Scene scene;

    // METODOS
    // Start is called before the first frame update
    void Start()
    {
        //Determina los objetos iniciales y la salud
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprRenderer = GetComponent<SpriteRenderer>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        salud = 100;
        caja = GetComponent<BoxCollider2D>();
        scene = SceneManager.GetActiveScene();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si la colision es en la parte de abajo, lo permite saltar
        Vector2 direction = collision.GetContact(0).normal;
        if(direction.y == 1){
            enPiso = true; //Cuando se acciona el collider de trigger, queda en true
        }else if (direction.y == -1)
        {
            enPiso = false;
        }
        //Si la colision es por una bala de la torreta o dron, disminuye la salud
        if (collision.collider.name == "drone-1" || collision.collider.name == "disparoVerde(Clone)")
        {
            salud -= 20;
            StartCoroutine(Flasher());
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        //Se utiliza por si no se detecto a la perfeccion la colision con el lado de abajo
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

    IEnumerator Flasher()
    {
        //Cada que recibe da�o, cambia el color dos veces
        for (int i = 0; i < 2; i++)
        {
            rend.material.color = Color.black;
            yield return new WaitForSeconds(.05f);
            rend.material.color = Color.white;
            yield return new WaitForSeconds(.05f);
        }
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        enPiso = false; //Al saltar se desactiva
    }

    private IEnumerator WaitForSceneLoad()
    {
        //Espera 3 segundos y reinicia la escena
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(scene.name);
    }

    // Update is called once per frame
    void Update()
    {
        float movHorizontal = Input.GetAxis("Horizontal"); //Controles del personaje con el teclado
        rigidbody.velocity = new Vector2(movHorizontal * maxVelocidadX, rigidbody.velocity.y);
        float movVertical = Input.GetAxis("Jump");      // [0, 1]

        if (movVertical > 0 && enPiso) //Si se ha precionado espacio y el jugador est� en el piso, puede brincar
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, movVertical * maxVelocidadY);
            anim.SetBool(name: "saltando", true);
        }

        if (rigidbody.velocity.x > 0) //Cambiar la direcci�n del sprite dependiendo de la velocidad
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

        if (Mathf.Abs(rigidbody.velocity.x) > 0) //Fijar la variable moviendo para las condiciones de transici�n de las animaciones
        {
            anim.SetBool(name: "corriendo", true);
        }
        else
        {
            anim.SetBool(name: "corriendo", false);
        }
        if (Mathf.Abs(rigidbody.velocity.y) > 0.5) //Si la velocidad en Y es mayor a 0.5, cambia a brincando. En 0 ocurr�an saltos con muy poca altura.
        {
            anim.SetBool(name: "saltando", true);
        }
        else
        {
            anim.SetBool(name: "saltando", false);
        }

        if (salud <= 0)
        {
            //Si se acaba la salud, explota y vuelve a cargar la escena
            anim.SetBool(name: "explotando", true);
            audioSource.PlayOneShot(clip, volume);
            rend.enabled = false;
            caja.enabled = false;
            StartCoroutine(WaitForSceneLoad());
        }
    }
}