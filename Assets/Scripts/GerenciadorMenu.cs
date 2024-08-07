using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorMenu : MonoBehaviour
{
    public GameObject MenuInicial;
    public GameObject MenuPausa;
    public GameObject BotaoPausa;
    public GameObject Pontuacao;
    public GerenciadorFases gerenciadorFases;

    void Start()
    {
        Time.timeScale = 1.0f;
        MenuInicial.SetActive(true);
        BotaoPausa.SetActive(false);
        Pontuacao.SetActive(false);
    }

    public void Comecar()
    {
        MenuInicial.SetActive(false);
        BotaoPausa.SetActive(true);
        Pontuacao.SetActive(true);
        gerenciadorFases.IniciarFases();
    }

    public void Pausar()
    {
        MenuPausa.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Despausar()
    {
        MenuPausa.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void VoltarAoInicio()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1.0f;
    }

    public void Sair()
    {
        Application.Quit();
    }
}
