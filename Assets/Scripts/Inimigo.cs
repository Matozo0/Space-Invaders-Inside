using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using static TankInimigoData;

public class Inimigo : MonoBehaviour
{
    private int vidaAtual;
    private float velocidadeAtual;
    public SpriteRenderer spriteRenderer;
    public GameObject efeitoMorte;
    public InimigoData inimigoData;

    private ParticleSystem.MainModule main;
    private float proximoTiro;
    private float proximoTeleporte;

    public GameObject ponto;

    GerenciadorAudio gerenciadorAudio;

    void OnValidate()
    {
        if (inimigoData == null) return;

        vidaAtual = inimigoData.vida;
        velocidadeAtual = inimigoData.velocidade;

        spriteRenderer.sprite = inimigoData.sprite;
    }

    void Start()
    {
        gerenciadorAudio = GameObject.FindGameObjectWithTag("Audio").GetComponent<GerenciadorAudio>();
        if (inimigoData == null) return;

        vidaAtual = inimigoData.vida;
        velocidadeAtual = inimigoData.velocidade;
        spriteRenderer.sprite = inimigoData.sprite;

        if (inimigoData is TankInimigoData tankData)
        {
            vidaAtual += tankData.vidaExtra;
        }
    }

    void Update()
    {
        Mover();

        if (inimigoData is TiroInimigoData tiroData && Time.time >= proximoTiro)
        {
            Atirar(tiroData);
            proximoTiro = Time.time + tiroData.tiroIntervalo;
        }
        if (inimigoData is TeleporteInimigoData teleporteData && Time.time >= proximoTeleporte)
        {
            Teleportar(teleporteData);
            proximoTeleporte = Time.time + teleporteData.teleporteIntervalo;
        }
    }

    private void Mover()
    {
        if (inimigoData is ZigzagInimigoData zigzagData)
        {
            float zigzag = Mathf.Sin(Time.time * zigzagData.zigzagFrequencia) * zigzagData.zigzagAmplitude;
            transform.Translate(new Vector3(zigzag, -velocidadeAtual * Time.deltaTime, 0));
        }
        else
        {
            transform.Translate(Vector3.down * velocidadeAtual * Time.deltaTime);
        }
    }

    private void Atirar(TiroInimigoData tiroData)
    {
        // Atira
    }

    private void Teleportar(TeleporteInimigoData teleporteData)
    {
        Instantiate(teleporteData.efeito, transform.position, Quaternion.identity);
        gerenciadorAudio.TocarEfeito(gerenciadorAudio.teleporte);
        Vector3 novaPosicao = new Vector3(
            Random.Range(teleporteData.min_teleportDistancia, teleporteData.max_teleportDistancia),
            transform.position.y, 1);
        transform.position = novaPosicao;
        Instantiate(teleporteData.efeito, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerControle>().TomarDano(1);
        } 
        if (collision.CompareTag("Projetil"))
        {
            TomarDano(collision.GetComponent<Tiro>().tiroData.dano);
            Destroy(collision.gameObject);
        }
    }

    public void TomarDano(int ataque)
    {
        vidaAtual -= ataque;
        if (vidaAtual <= 0)
        {
            Destroy(gameObject);
            main = efeitoMorte.GetComponent<ParticleSystem>().main;
            main.startColor = inimigoData.corMorte;
            Instantiate(efeitoMorte, transform.position, Quaternion.identity);
            if (Random.Range(0.0f,1.0f) >= 0.1f)
            {
                Instantiate(ponto, transform.position, Quaternion.identity);
            }
        }
    }
}
