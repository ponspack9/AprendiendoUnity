using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controlador_de_jugador : MonoBehaviour
{
    private Rigidbody fisicasDelJugador;

    private float movimientoEjeX;
    private float movimientoEjeY;

    public float speed = 10f;



    // Start se llama cuando empieza el objeto
    void Start()
    {
        fisicasDelJugador = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movimientoEjeX = movementVector.x; 
        movimientoEjeY = movementVector.y;
    }

    private void FixedUpdate() {
        Vector3 movement = new Vector3 (movimientoEjeX, 0.0f, movimientoEjeY);
        fisicasDelJugador.AddForce(movement*speed);
    }
}
