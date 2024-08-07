using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDePowerUps : MonoBehaviour
{
    public List<PowerUpData> powerUpsDisponiveis;
    public GameObject powerUpPrefab;
    public Transform[] pontosDeSpawn;
    public float intervaloEntreSpawns;

    void Start()
    {
        StartCoroutine(SpawnarPowerUps());
    }

    IEnumerator SpawnarPowerUps()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervaloEntreSpawns);
            SpawnarPowerUp();
        }
    }

    void SpawnarPowerUp()
    {
        Transform pontoDeSpawn = pontosDeSpawn[Random.Range(0, pontosDeSpawn.Length)];
        PowerUpData powerUpData = powerUpsDisponiveis[Random.Range(0, powerUpsDisponiveis.Count)];
        GameObject powerUp = Instantiate(powerUpPrefab, pontoDeSpawn.position, Quaternion.identity);
        powerUp.GetComponent<PowerUp>().powerUpData = powerUpData;
    }
}
