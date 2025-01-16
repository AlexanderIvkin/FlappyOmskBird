using System;
using UnityEngine;

public abstract class PoolableObject: MonoBehaviour
{
    public event Action Disabled;

    protected void Disable()
    {
        Disabled?.Invoke();
    }
}