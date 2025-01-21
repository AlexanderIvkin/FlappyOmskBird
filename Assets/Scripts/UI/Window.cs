using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private Canvas _canvasWindow;
    [SerializeField] private Button _actionButton;

    protected Canvas CanvasWindow => _canvasWindow;
    protected Button ActionButton => _actionButton;

    private void OnEnable()
    {
        _actionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Close()
    {
        CanvasWindow.gameObject.SetActive(false);
    }

    public void Open()
    {
        CanvasWindow.gameObject.SetActive(true);
    }
    protected abstract void OnButtonClick();
}
