using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Autores: Ruben Sanchez Mayen, Octavio Andrick Sanchez Perusquia
// Descripcion: Controlador del Jugador en el minijuego. 

public class PersonajeMinijuego : MonoBehaviour
{
    public float velocidadMovimiento = 3f; //Velocidad con la que se mueve el personaje
    private Rigidbody2D rigidbody;
    private int direccion = 0; //Direccion del jugador
    public bool valorJug = true; //Que nave tiene el jugador? Son 2

    //Retardar la aparición del propulsor
    IEnumerator PrenderPropulsor(){
        yield return new WaitForSeconds(.1f);
        transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = true;
    }

    //Actualizar a la nave correcta
    void CambiarNave(){
        if(valorJug){ //Nave 1
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(PrenderPropulsor()); //Prender con retardo el propulsor
        }else{ //Nave 2
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
            transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    //Controlador de compuerta not
    public void Not(){ 
        valorJug = !valorJug;
        CambiarNave();
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // La nave siempre avanza a una direccion, el usuario establece cual.
    void Update()
    {
        //Pausa
        if (!MenuPausa.estaPausado)
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

            //Input WASD
            if (Input.GetKeyDown("right"))
            {
                direccion = 1; //Cambiar direccion de la nave
                transform.localScale = new Vector3(1, 1, 1); //Cambiar la posicion de la nave
            }
            else if (Input.GetKeyDown("left"))
            {
                direccion = 2; //Cambiar direccion de la nave
                transform.localScale = new Vector3(-1, 1, 1); //Cambiar la posicion de la nave
            }
            else if (Input.GetKeyDown("up"))
                direccion = 3; //Cambiar direccion de la nave
            else if (Input.GetKeyDown("down"))
                direccion = 4; //Cambiar direccion de la nave
            //Input FLECHAS
            else if (Input.GetKeyDown(KeyCode.D))
            {
                direccion = 1; //Cambiar direccion de la nave
                transform.localScale = new Vector3(1, 1, 1); //Cambiar la posicion de la nave
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                direccion = 2; //Cambiar direccion de la nave
                transform.localScale = new Vector3(-1, 1, 1); //Cambiar la posicion de la nave
            }
            else if (Input.GetKeyDown(KeyCode.W))
                direccion = 3; //Cambiar direccion de la nave
            else if (Input.GetKeyDown(KeyCode.S))
                direccion = 4; //Cambiar direccion de la nave
        }
    }
}
