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
    private int  nivel = 1; 
    private int marcador = 0;

    public GameObject barreraNivel1;

    public TextMeshProUGUI marcadorTextoEditor;

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

    private void OnTriggerEnter(Collider other) {
        // Si chocamos con el cubo_verde
        if (other.gameObject.CompareTag("cubo_verde")){
            // Si entra aqui es que hemos chocado
            // Desactivamos el cubo_verde/
            other.gameObject.SetActive(false);
            // Sumamos 1 al marcador
            marcador += 2;
            // Actualizamos el marcador
            ActualizarMarcador();
        }
        if( other.gameObject.CompareTag("cubo_rojo") ) {
            other.gameObject.SetActive(false); 
            marcador += 1;
            ActualizarMarcador();
        }

        if(nivel == 1 && marcador > 14){ 
            // hemos completado el nivel 1
            // abrimos la barrera
            barreraNivel1.SetActive(false);
            nivel = 2;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if( other.gameObject.CompareTag("cubo_trampa") ) {
             Debug.Log("Hemos chocado con el cubo trampa");
        }
    }
private void ActualizarMarcador(){
        marcadorTextoEditor.text = "Marcador: " + marcador.ToString();
    }
}
