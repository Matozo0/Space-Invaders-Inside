using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public string nome;
    public int vida;
    public float velocidade;
    public int ataque;
    public Sprite sprite;
    public InimigoData inimigoData;

    void OnValidate()
    {
        nome = inimigoData.nome;
        vida = inimigoData.vida;
        velocidade = inimigoData.velocidade;
        ataque = inimigoData.ataque;
        sprite = inimigoData.sprite;
    }
    void Start()
    {
        nome = inimigoData.nome;
        vida = inimigoData.vida;
        velocidade = inimigoData.velocidade;
        ataque = inimigoData.ataque;
        sprite = inimigoData.sprite;
    }
}
