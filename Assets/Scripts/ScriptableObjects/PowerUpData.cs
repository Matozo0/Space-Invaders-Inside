using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp/Criar PowerUp")]
public class PowerUpData : ScriptableObject
{
    public string nome;
    public float duracao;
    public Sprite sprite;
}
