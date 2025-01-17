using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int Value { get; private set; }

    public void Add(int value)
    {
        if (value <= 0)
            return;

        Value += value;
    }

    public void Reset()
    {
        Value = 0;
    }
}
