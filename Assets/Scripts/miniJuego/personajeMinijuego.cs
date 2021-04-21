using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Autores: Ruben, 
// Codigo para controlar el movimiento del personaje principal del minijuego

public class personajeMinijuego : MonoBehaviour
{
    public float velocidadMovimiento = 3f; // Velocidad con la que se mueve el personaje
    //public static bool enter = false;
    private Rigidbody2D rigidbody;

    // La combinacion de los booleanos la direccion de movimiento
    private bool a = false;
    private bool b = false;
    public static bool s = true; // pausa
    private bool valorJug = true; //rojo o azul? true = rojo

    public void detenerJug(){
        rigidbody.velocity = new Vector2(0,0);
        s = true;
    }

    void stop(){
        Time.timeScale = 0;
    }

    void play(){ 
        Time.timeScale = 1;
    }

    public bool getValorJug(){
        return valorJug;
    }

    void cambiarNave(){
        if(valorJug){
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        }else{
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void not(){
        valorJug = !valorJug;
        cambiarNave();
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // El personaje siempre avanza a una direccion, el usuario establece cual. Se empieza hacia la derecha. Se para con espacio
    void Update()
    {
        if(!s){
            play();
            if(!a && !b) // 00
                rigidbody.velocity = new Vector2(velocidadMovimiento,0);
            else if(!a && b) // 01
                rigidbody.velocity = new Vector2(-velocidadMovimiento,0);
            else if(a && !b) // 10
                rigidbody.velocity = new Vector2(0,velocidadMovimiento);
            else // 11
                rigidbody.velocity = new Vector2(0,-velocidadMovimiento);
        }
        
        if(Input.GetKeyDown("right")){
            a = false;
            b = false;
            s = false;
            transform.localScale = new Vector3(1,1,1);
        }else if(Input.GetKeyDown("left")){
            a = false;
            b = true;
            s = false;
            transform.localScale = new Vector3(-1,1,1);
        }else if(Input.GetKeyDown("up")){
            a = true;
            b = false;
            s = false;
        }else if(Input.GetKeyDown("down")){
            a = true;
            b = true;
            s = false;
        }else if(Input.GetKeyDown(KeyCode.D)){
            a = false;
            b = false;
            s = false;
            transform.localScale = new Vector3(1,1,1);
        }else if(Input.GetKeyDown(KeyCode.A)){
            a = false;
            b = true;
            s = false;
            transform.localScale = new Vector3(-1,1,1);
        }else if(Input.GetKeyDown(KeyCode.W)){
            a = true;
            b = false;
            s = false;
        }else if(Input.GetKeyDown(KeyCode.S)){
            a = true;
            b = true;
            s = false;
        }else if(Input.GetKeyDown(KeyCode.Space)){
            s = !s;
            stop();
        }
    }
}
