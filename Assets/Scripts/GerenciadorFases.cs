using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreeEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorFases : MonoBehaviour
{
    public float PosX;
    public float PosY;
    public List<InimigoData> inimigos;
    public GameObject inimigoPrefab;
    public float intervaloEntreOndas = 30f;
    public int quantidadeInicialDeInimigos = 2;
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
            SpawnarOndaDeInimigos();
            yield return new WaitForSeconds(intervaloEntreOndas);
        }
    }

    void SpawnarOndaDeInimigos()
    {
        numeroDaOnda++;
        texto_nOndas.text = "Onda: " + numeroDaOnda.ToString();
        int quantidadeDeInimigos = quantidadeInicialDeInimigos + (numeroDaOnda * incrementoDeInimigosPorOnda);

        for (int i = 0; i < quantidadeDeInimigos; i++)
        {
            Vector3 posicao = new Vector3(Random.Range(transform.position.x-PosX, transform.position.x+PosX), Random.Range(transform.position.y-PosY, transform.position.y+PosY), 1);
            InimigoData inimigoData = inimigos[Random.Range(0, inimigos.Count)];
            GameObject inimigo = Instantiate(inimigoPrefab, posicao, Quaternion.identity);
            inimigo.GetComponent<Inimigo>().inimigoData = inimigoData;
        }
    }
}
