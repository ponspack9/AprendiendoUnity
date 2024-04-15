using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorJugador : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0;

    private int score = 0;
    public TextMeshProUGUI scoreTextUI;

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

    private void FixedUpdate() {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement*speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Premio"))
        {
            other.gameObject.SetActive(false);
            score += 100;
            scoreTextUI.text = "SCORE: " + score.ToString();

        }
    }
}
