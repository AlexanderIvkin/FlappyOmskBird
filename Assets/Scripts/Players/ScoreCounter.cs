using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public event Action<int> CountChanged;

    public int Value { get; private set; } = 0;

    public void Add(int value)
    {
        if (value <= 0)
            return;

        Value += value;
        CountChanged?.Invoke(Value);
    }
}
