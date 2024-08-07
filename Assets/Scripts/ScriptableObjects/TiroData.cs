using UnityEngine;

[CreateAssetMenu(fileName = "Tiro", menuName = "Tiros/Criar Tiro")]
public class TiroData : ScriptableObject
{
    public float velocidade;
    public int dano;
    public float duracao;
    public Sprite sprite;
    public Color cor;
}
