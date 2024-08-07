using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontos : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerControle>().AumentarPontos(1);
            Destroy(gameObject);
        }
    }
}
