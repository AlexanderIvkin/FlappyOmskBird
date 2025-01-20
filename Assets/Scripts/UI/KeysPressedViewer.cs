using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class KeysPressedViewer : MonoBehaviour
{
    [SerializeField] protected InputReader InputReader;
    [SerializeField] protected Image KeyImage;
    [SerializeField] protected Color PressedColor;

    private Color _baseColor;
    private float _delay = 0.5f;
    private Coroutine _baseColorReturnCoroutine;

    private void Awake()
    {
        _baseColor = KeyImage.color;
    }

    protected void ChangeKeyColor()
    {
        KeyImage.color = PressedColor;

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
            KeyImage.color = Color.Lerp( _baseColor,PressedColor, currentTime / _delay);

            yield return null;
        }

        _baseColorReturnCoroutine = null;
    }
}
