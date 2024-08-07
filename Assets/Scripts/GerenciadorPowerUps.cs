using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorPowerUps : MonoBehaviour
{
    public List<PowerUpData> powerUpsDisponiveis;
    public GameObject powerUpPrefab;

    public float PosX;
    public float PosY;
    public float minIntervalo;
    public float maxIntervalo;
    public int maxPowerUps = 5;

    private int PowerUpsAtivos = 0;
    void Start()
    {
        StartCoroutine(SpawnarPowerUps());
    }

    IEnumerator SpawnarPowerUps()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minIntervalo, maxIntervalo));
            if (PowerUpsAtivos < maxPowerUps)
            {
                SpawnarPowerUp();
            }            
        }
    }

    void SpawnarPowerUp()
    {
        PowerUpsAtivos++;
        Vector3 posicao = new Vector3(Random.Range(-PosX, PosX), Random.Range(-PosY, PosY), 1);
        PowerUpData powerUpData = powerUpsDisponiveis[Random.Range(0, powerUpsDisponiveis.Count)];
        GameObject powerUp = Instantiate(powerUpPrefab, posicao, Quaternion.identity);
        powerUp.GetComponent<PowerUp>().powerUpData = powerUpData;
    }

    public void PowerUpDestruido()
    {
        PowerUpsAtivos--;
    }
}
