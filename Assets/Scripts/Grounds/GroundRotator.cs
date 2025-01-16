using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRotator : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Rotate()
    {
        transform.Rotate(Vector3.forward, _speed * Time.deltaTime);
    }
}
