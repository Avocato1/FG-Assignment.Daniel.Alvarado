using UnityEngine;

[CreateAssetMenu]
public class FloatSO : ScriptableObject
{
    [SerializeField]
    private float p1CoinScore, p1LapScore, p2CoinScore, p2LapScore;

    public float CoinScore
    {
        get {return p1CoinScore;}
        set { p1CoinScore = value; }
    }
    public float LapScore
    {
        get {return p1LapScore;}
        set { p1LapScore = value; }
    }
    
    public float P2CoinScore
    {
        get {return p2CoinScore;}
        set { p2CoinScore = value; }
    }
    public float P2LapScore
    { 
        get {return p2LapScore;}
        set { p2LapScore = value; }
    }
}
