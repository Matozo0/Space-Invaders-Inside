using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

public class PlayerControle : MonoBehaviour
{
    private Rigidbody2D meuRb;
    private float InputX;
    private float InputY;
    public float velocidadeX;
    public float velocidadeY;
    public int vidaAtual = 3;
    private float tempoTiroAnterior;
    public float intervaloTiro = 0.3f; 

    public GameObject Tiro;
    public Animator animator;
    private string estadoAtual;
    
    GerenciadorAudio gerenciadorAudio;

    public Image[] powerUpSlots;
    public TMP_Text[] nomes;
    private PowerUpData[] powerUps = new PowerUpData[2];   

    void Start()
    {
        meuRb = GetComponent<Rigidbody2D>();
        gerenciadorAudio = GameObject.FindGameObjectWithTag("Audio").GetComponent<GerenciadorAudio>();
    }

    void Update()
    {
        Mover();

        if (Input.GetButton("Fire1") && Time.time >= tempoTiroAnterior + intervaloTiro)
        {
            animator.Play("Nave_Ataque");
            Vector3 offsetTiro = new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z);
            Instantiate(Tiro, offsetTiro, Quaternion.identity);
            gerenciadorAudio.TocarEfeito(gerenciadorAudio.tiro);
            tempoTiroAnterior = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            UsarPowerUp(0);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            UsarPowerUp(1);
        }
    }

    void Mover()
    {
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");

        meuRb.AddForce(new Vector2(InputX * velocidadeX, InputY * velocidadeY));
    }

    public void TomarDano(int ataque)
    {
        gerenciadorAudio.TocarEfeito(gerenciadorAudio.dano);
        vidaAtual -= ataque;
        if (vidaAtual <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ColetarPowerUp(PowerUp powerUp)
    {
        for (int i = 0; i < 2; i++)
        {
            if (powerUps[i] == null)
            {
                powerUps[i] = powerUp.powerUpData;
                powerUpSlots[i].sprite = powerUp.powerUpData.sprite;
                nomes[i].text = powerUp.powerUpData.nome;
                Destroy(powerUp.gameObject);
                break;
            }
        }
    }

    void UsarPowerUp(int slot)
    {
        if (powerUps[slot] != null)
        {
            Instantiate(powerUps[slot].efeitoPrefab, transform.position, Quaternion.identity);
            powerUps[slot] = null;
            powerUpSlots[slot].sprite = null;
            nomes[slot].text = "";
        }
    }
}
