using System;
using UnityEngine;

public abstract class PoolableObject: MonoBehaviour
{
    public event Action<PoolableObject> Disabled;

    public void Disable()
    {
        gameObject.SetActive(false);
        Disabled?.Invoke(this);
    }
}