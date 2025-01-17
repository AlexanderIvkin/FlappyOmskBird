using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode FlyKey = KeyCode.Space;
    private const KeyCode ShotKey = KeyCode.LeftShift;

    public event Action FlyKeyPressed;
    public event Action ShotKeyPressed;

    private void Update()
    {
        if (Input.GetKeyDown(FlyKey))
        {
            FlyKeyPressed?.Invoke();
        }

        if (Input.GetKeyDown(ShotKey))
        {
            ShotKeyPressed?.Invoke();
        }
    }
}
