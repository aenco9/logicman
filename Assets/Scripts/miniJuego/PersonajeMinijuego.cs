using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Autores: Ruben Sanchez Mayen, Octavio Andrick Sanchez Perusquia
// Descripcion: Controlador del Jugador en el minijuego. 

public class PersonajeMinijuego : MonoBehaviour
{
    public float velocidadMovimiento= 3f; //Velocidad por defecto
    private Rigidbody2D rigidbody;
    private int direccion = 0; //Direccion del jugador
    public bool valorJug = true; //Que nave tiene el jugador? Son 2
    public bool bloquearInput = true;
    public Animator explosion; //Controlar animacion de explosion
    public AudioSource boost; //Sonido de boost
    public AudioSource boom; //Sonido Explosion
    public AudioSource compuerta; //Sonido compuerta
    private int vidas;

    //Retardar la aparición del propulsor
    IEnumerator PrenderPropulsor(){
        yield return new WaitForSeconds(.2f);
        transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = true;
    }

    //Actualizar a la nave correcta
    void CambiarNave(){
        if(valorJug){ //Nave 1
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(PrenderPropulsor()); //Prender con retardo el propulsor
            //La nave no puede disparar
            transform.GetChild(1).GetComponent<Disparo>().enabled = false;
        }else{ //Nave 2
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
            transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;
            //La nave puede disparar
            transform.GetChild(1).GetComponent<Disparo>().enabled = true;
        }
    }

    //Controlador de not
    public void Not(){ 
        valorJug = !valorJug;
        CambiarNave();
        compuerta.Play();
    }

    //Controlador de and
    public void And(bool resultado, float yPos){
        bloquearInput = true;
        //Cambiar nave
        valorJug = resultado;
        CambiarNave();
        //Mover nave
        transform.position = new Vector3(transform.position.x,yPos,transform.position.z);
        compuerta.Play();
    }

    //Controlador or
    public void Or(bool resultado, float yPos){
        bloquearInput = true;
        //Cambiar nave
        valorJug = resultado;
        CambiarNave();
        //Mover nave
        transform.position = new Vector3(transform.position.x,yPos,transform.position.z);
        compuerta.Play();
    }

    //Rotar la nave segun su direccion
    void Rotar(){
        //Derecha
        if(direccion == 1)
            transform.rotation = new Quaternion(0,180,0,1);
        else if(direccion == 2)
            transform.rotation = new Quaternion(0,0,0,1);
    }

    //Eliminar jugador
    void Eliminar(){
        transform.GetChild(0).gameObject.active = false;
        transform.GetChild(1).gameObject.active = false;
        transform.GetChild(2).gameObject.active = false;
    }

    //Reiniciar Nivel
    private IEnumerator WaitForSceneLoad()
    {
        //Espera 3 segundos y reinicia la escena
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator Flasher()
    {
        //Cada que recibe da�o, cambia el color dos veces
        for (int i = 0; i < 2; i++)
        {
            transform.GetChild(0).GetComponent<Renderer>().material.color = Color.black;
            transform.GetChild(1).GetComponent<Renderer>().material.color = Color.black;
            yield return new WaitForSeconds(.05f);
            transform.GetChild(0).GetComponent<Renderer>().material.color = Color.white;
            transform.GetChild(1).GetComponent<Renderer>().material.color = Color.white;
            yield return new WaitForSeconds(.05f);
        }
    }

    //Detectar colisiones con enemigos y balas
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si la colision es por una bala de la torreta o dron la nave explota
        if (collision.collider.name == "drone-1" || collision.collider.name == "disparoVerde(Clone)"){
            vidas -= 1;
            StartCoroutine(Flasher());
            if (vidas == 0)
            {
                explosion.SetBool("explota", true);
                direccion = 0;
                bloquearInput = true;
                GetComponent<BoxCollider2D>().enabled = false;
                boom.Play();
                StartCoroutine(WaitForSceneLoad());
                Eliminar();
            }
        }
    }

    public int GetVidas(){
        return vidas;
    }

    void Start()
    {
        vidas = 10;
        rigidbody = GetComponent<Rigidbody2D>();
        CambiarNave();
    }

    // La nave siempre avanza a una direccion, el usuario establece cual.
    void Update()
    {
        //Pausa
        if (!MenuPausa.estaPausado && !bloquearInput)
        {
            if (direccion == 1) //Derecha
                rigidbody.velocity = new Vector2(velocidadMovimiento, 0);
            else if(direccion == 2) //Izquierda
                rigidbody.velocity = new Vector2(-velocidadMovimiento, 0);
            else if (direccion == 3) //Arriba
                rigidbody.velocity = new Vector2(0, velocidadMovimiento);
            else if (direccion == 4) //Abajo
                rigidbody.velocity = new Vector2(0, -velocidadMovimiento);
            else //Sin movimiento
                rigidbody.velocity = new Vector2(0, 0);

            //Input Flechas
            if (Input.GetKeyDown("right"))
            {
                direccion = 1; //Cambiar direccion de la nave
            }
            else if (Input.GetKeyDown("left"))
            {
                direccion = 2; //Cambiar direccion de la nave
            }
            else if (Input.GetKeyDown("up"))
                direccion = 3; //Cambiar direccion de la nave
            else if (Input.GetKeyDown("down"))
                direccion = 4; //Cambiar direccion de la nave
            //Input WASD
            else if (Input.GetKeyDown(KeyCode.D))
            {
                direccion = 1; //Cambiar direccion de la nave
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                direccion = 2; //Cambiar direccion de la nave
            }
            else if (Input.GetKeyDown(KeyCode.W))
                direccion = 3; //Cambiar direccion de la nave
            else if (Input.GetKeyDown(KeyCode.S))
                direccion = 4; //Cambiar direccion de la nave
            // Habilidades del usuario al hacer click
            if (Input.GetButton("Fire1") && valorJug)
                rigidbody.velocity = rigidbody.velocity * new Vector2(2,2);
            //Solo suene una vez
            if (Input.GetButtonDown("Fire1") && valorJug) 
                boost.Play();

            //Rotar la nave a la direccion correcta
            Rotar();
        }
    }
}
