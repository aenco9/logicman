using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Autores: Ruben, 
// Codigo para controlar el movimiento del personaje principal del minijuego

public class personajeMinijuego : MonoBehaviour
{
    public float velocidadMovimiento = 3f; // Velocidad con la que se mueve el personaje
    public static bool enter = false;
    private Renderer rend;
    private Rigidbody2D rigidbody;
    public TrailRenderer trail0;
    public TrailRenderer trail1;

    // La combinacion de los booleanos la direccion de movimiento
    private bool a = false;
    private bool b = false;
    public static bool s = true;
    private bool valorJug = true; //rojo o azul? true = rojo
    public static Color color1 = new Color(1f,1f,1.058f,1f); //rojo
    public static Color color0 = new Color(.157f,1.247f,3f,1f); //azul
    // constructor del color rgb donde (r,g,b,aplha)
    //                        (max 1,max 3.18, max 3, max 1)

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

    void cambiarColor(){
        if(valorJug){
               // rend.material.color = color1;
                trail1.emitting = true;
                trail0.emitting = false;
            }else{
               // rend.material.color = color0;
                trail1.emitting = false;
                trail0.emitting = true;
            }
    }

    public bool getValorJug(){
        return valorJug;
    }

    public void not(){
        valorJug = !valorJug;
        cambiarColor();
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rend = GetComponent<Renderer> ();
        trail0 = transform.GetChild(0).GetComponent<TrailRenderer>();
        trail1 = transform.GetChild(1).GetComponent<TrailRenderer>();
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
            transform.localScale = new Vector3(-1.5f,1.5f,1);
        }else if(Input.GetKeyDown("left")){
            a = false;
            b = true;
            s = false;
            transform.localScale = new Vector3(1.5f,1.5f,1);
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
            transform.localScale = new Vector3(-1.5f,1.5f,1);
        }else if(Input.GetKeyDown(KeyCode.A)){
            a = false;
            b = true;
            s = false;
            transform.localScale = new Vector3(1.5f,1.5f,1);
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
