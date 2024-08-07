using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp/Criar PowerUp")]
public class PowerUpData : ScriptableObject
{
    public string nome;
    public Sprite sprite_coletavel;
    public Sprite sprite;
    public GameObject efeitoPrefab;
    public Color cor;
}
