using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControle : MonoBehaviour
{
    private Rigidbody2D meuRb;
    private float InputX;
    private float InputY;
    public float velocidadeX;
    public float velocidadeY;

    void Start()
    {
        meuRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");

        meuRb.AddForce(new Vector2(InputX * velocidadeX, InputY * velocidadeY));
    }
}
