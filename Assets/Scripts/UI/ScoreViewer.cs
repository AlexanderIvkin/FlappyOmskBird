using TMPro;
using UnityEngine;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TextMeshProUGUI _countText;

    private void OnEnable()
    {
        _scoreCounter.CountChanged += ShowCount;
    }

    private void OnDisable()
    {
        _scoreCounter.CountChanged -= ShowCount;
    }

    private void Start()
    {
        _countText.text = _scoreCounter.Value.ToString();
    }

    private void ShowCount(int value)
    {
        _countText.text = value.ToString();
    }
}
