using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Autores: Ruben, 
// Codigo para controlar el movimiento del personaje principal del minijuego

public class personajeMinijuego : MonoBehaviour
{
    public float velocidadMovimiento = 3f; // Velocidad con la que se mueve el personaje
    Renderer rend;
    Rigidbody2D rigidbody;
    TrailRenderer trailRend;
    // La combinacion de los booleanos la direccion de movimiento
    private bool a = false;
    private bool b = false;
    private bool s = true;
    private bool valorJug = true;
    private Color color1 = new Color(10f,1f,1.2f,1);
    private Color color0 = new Color(.5f,2f,10f,1);

    public static void detenerJug(){
        Time.timeScale = 0;
    }

    public static void reanudarJug(){
        Time.timeScale = 1;
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rend = GetComponent<Renderer> ();
        trailRend = GetComponent<TrailRenderer>();
        trailRend.material.color = color1;
    }

    // El personaje siempre avanza a una direccion, el usuario establece cual. Se empieza hacia la derecha. Se para con espacio
    void Update()
    {   if(!s){
            reanudarJug();
            if(!a && !b) // 00
                rigidbody.velocity = new Vector2(velocidadMovimiento,0);
            else if(!a && b) // 01
                rigidbody.velocity = new Vector2(-velocidadMovimiento,0);
            else if(a && !b) // 10
                rigidbody.velocity = new Vector2(0,velocidadMovimiento);
            else // 11
                rigidbody.velocity = new Vector2(0,-velocidadMovimiento);
        }else
            detenerJug();
        
        if(Input.GetKeyDown("right")){
            a = false;
            b = false;
            s = false;
        }else if(Input.GetKeyDown("left")){
            a = false;
            b = true;
            s = false;
        }else if(Input.GetKeyDown("up")){
            a = true;
            b = false;
            s = false;
        }else if(Input.GetKeyDown("down")){
            a = true;
            b = true;
            s = false;
        }else if(Input.GetKeyDown(KeyCode.Space))
            s = !s;
        else if(Input.GetKeyDown(KeyCode.S))
            valorJug = !valorJug;

        if(valorJug){
            rend.material.color = color1;
            trailRend.material.color = color1;
        }else{
           rend.material.color = color0;
           trailRend.material.color = color0;
        }
    }
}
