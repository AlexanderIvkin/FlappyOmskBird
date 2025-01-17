using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeysPressedViewer : MonoBehaviour
{
    [SerializeField] private Image _keyImage;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Color _pressedColor;

    private Color _baseColor;
    private float _delay = 0.5f;
    private Coroutine _baseColorReturnCoroutine;

    private void Awake()
    {
        _baseColor = _keyImage.color;
    }

    private void OnEnable()
    {
        _inputReader.FlyKeyPressed += ChangeKeyColor;
    }

    private void OnDisable()
    {
        _inputReader.FlyKeyPressed -= ChangeKeyColor;
        
    }

    private void ChangeKeyColor()
    {
        _keyImage.color = _pressedColor;

        if(_baseColorReturnCoroutine != null)
        {
            StopCoroutine(_baseColorReturnCoroutine);
        }

        _baseColorReturnCoroutine = StartCoroutine(DelayBaseColorReturn());
    }

    private IEnumerator DelayBaseColorReturn()
    {
        float currentTime = _delay;

        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            _keyImage.color = Color.Lerp( _baseColor,_pressedColor, currentTime / _delay);

            yield return null;
        }

        _baseColorReturnCoroutine = null;
    }
}
