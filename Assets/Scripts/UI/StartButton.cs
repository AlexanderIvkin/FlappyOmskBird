using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _curtain;
    [SerializeField] private float _delay;
    [SerializeField] private int _firstLevelSceneNumber;

    private void OnEnable()
    {
        _button.onClick.AddListener(LoadGame);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(LoadGame);
    }

    private void LoadGame()
    {
        StartCoroutine(DelayedGameLoad());
    }

    private IEnumerator DelayedGameLoad()
    {
        float currentDelay = 0;

        while (currentDelay < _delay)
        {
            currentDelay += Time.deltaTime;

            _curtain.color = new Color(_curtain.color.r, 
                _curtain.color.g, 
                _curtain.color.b, 
                currentDelay/ _delay);

            yield return null;
        }

        SceneManager.LoadScene(_firstLevelSceneNumber);
    }
}
