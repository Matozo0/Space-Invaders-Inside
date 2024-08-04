using UnityEngine;

[CreateAssetMenu(fileName = "Inimigo", menuName = "Inimigo/Criar Inimigo")]
public class InimigoData : ScriptableObject
{
    public string nome;
    public int vida;
    public float velocidade;
    public int ataque;
    public Sprite sprite;
}
