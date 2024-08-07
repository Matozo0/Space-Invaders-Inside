using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorFases : MonoBehaviour
{
    public float PosX;
    public float PosY;
    public List<InimigoData> inimigos;
    public GameObject inimigoPrefab;
    public float intervaloEntreOndas = 10f;
    public int quantidadeInicialDeInimigos = 5;
    public int incrementoDeInimigosPorOnda = 2;

    public TMP_Text texto_nOndas;
    private int numeroDaOnda = 0;
    private bool jogoAtivo = true;

    public void IniciarFases()
    {
        StartCoroutine(GerenciarOndas());
    }

    IEnumerator GerenciarOndas()
    {
        while (jogoAtivo)
        {
            yield return new WaitForSeconds(intervaloEntreOndas);
            SpawnarOndaDeInimigos();
        }
    }

    void SpawnarOndaDeInimigos()
    {
        numeroDaOnda++;
        texto_nOndas.text = numeroDaOnda.ToString();
        int quantidadeDeInimigos = quantidadeInicialDeInimigos + (numeroDaOnda * incrementoDeInimigosPorOnda);

        for (int i = 0; i < quantidadeDeInimigos; i++)
        {
            Vector3 posicao = new Vector3(Random.Range(-PosX, PosX), Random.Range(-PosY, PosY), 1);
            InimigoData inimigoData = inimigos[Random.Range(0, inimigos.Count)];
            GameObject inimigo = Instantiate(inimigoPrefab, posicao, Quaternion.identity);
            inimigo.GetComponent<Inimigo>().inimigoData = inimigoData;
        }
    }
}
