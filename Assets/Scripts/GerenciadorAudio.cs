using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorAudio : MonoBehaviour
{
    public AudioSource efeitos_sonoros;
    public AudioClip tiro;
    public AudioClip dano;
    public AudioClip teleporte;
    public AudioClip coleta_ponto;

    public void TocarEfeito(AudioClip efeito)
    {
        efeitos_sonoros.PlayOneShot(efeito);
    }
}
