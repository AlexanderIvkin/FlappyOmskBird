using UnityEngine;

public class ScoreZone : MonoBehaviour ,IScoreable
{
    [SerializeField] private int _bonusValue;

    public int GetBonusValue()
    {
        return _bonusValue;
    }
}
