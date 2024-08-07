using UnityEngine;

[CreateAssetMenu(fileName = "Inimigo", menuName = "Inimigo/Criar Inimigo")]
public class InimigoData : ScriptableObject
{
    public int vida;
    public float velocidade;
    public Sprite sprite;
    public Color corMorte;
}

[CreateAssetMenu(fileName = "ZigzagInimigo", menuName = "Inimigo/Habilidades/Criar Zigzag")]
public class ZigzagInimigoData : InimigoData
{
    public float zigzagAmplitude;
    public float zigzagFrequencia;
}

[CreateAssetMenu(fileName = "TiroInimigo", menuName = "Inimigo/Habilidades/Criar Tiro")]
public class TiroInimigoData : InimigoData
{
    public GameObject tiroPrefab;
    public float tiroIntervalo;
}

[CreateAssetMenu(fileName = "TankInimigo", menuName = "Inimigo/Habilidades/Criar Tank")]
public class TankInimigoData : InimigoData
{
    public int vidaExtra;
}

[CreateAssetMenu(fileName = "TeleporteInimigo", menuName = "Inimigo/Habilidades/Criar Teleporte")]
public class TeleporteInimigoData : InimigoData
{
    public float teleporteIntervalo;
    public float min_teleportDistancia;
    public float max_teleportDistancia;
    public GameObject efeito;
}