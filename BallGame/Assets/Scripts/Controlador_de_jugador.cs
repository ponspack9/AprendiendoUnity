using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador_de_jugador : MonoBehaviour
{
    private Rigidbody fisicasDelJugador;

    private float movimientoEjeX;

    // Crear variable para el movimiento en el eje Y


    public float speed = 9.9f;

    // Start se llama cuando empieza el objeto
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x; 
        movementY = movementVector.y;
    }

    // Update se llama cada fotograma del juego
    void Update()
    {
        
    }
}
