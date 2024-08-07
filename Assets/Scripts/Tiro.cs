using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public TiroData tiroData;

    private float velocidadeAtual;
    private float duracaoAtual;

    void Start()
    {
        if (tiroData == null) return;

        spriteRenderer.sprite = tiroData.sprite;
        velocidadeAtual = tiroData.velocidade;
    }

    void Update()
    {
        duracaoAtual += Time.deltaTime;
        transform.Translate(Vector3.up * velocidadeAtual * Time.deltaTime);
        
        if (duracaoAtual > tiroData.duracao) Destroy(gameObject);
    }
}
