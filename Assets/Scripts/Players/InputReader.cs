using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode MoveKey = KeyCode.Space;

    public event Action MoveKeyPressed;

    private void Update()
    {
        if (Input.GetKeyDown(MoveKey))
        {
            MoveKeyPressed?.Invoke();
        }
    }
}
