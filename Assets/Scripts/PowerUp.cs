using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpData powerUpData;
    public SpriteRenderer spriteRenderer;
    public GerenciadorPowerUps gerenciadorPowerUps;

    void Start()
    {
        spriteRenderer.sprite = powerUpData.sprite_coletavel;
        spriteRenderer.color = powerUpData.cor;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerControle>().ColetarPowerUp(this);
        }
    }

    private void OnDestroy()
    {
        gerenciadorPowerUps.PowerUpDestruido();
    }
}
