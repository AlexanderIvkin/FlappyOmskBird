public class FlyKeyViewer : KeysPressedViewer
{
    private void OnEnable()
    {
        InputReader.FlyKeyPressed += ChangeKeyColor;
    }

    private void OnDisable()
    {
        InputReader.FlyKeyPressed -= ChangeKeyColor;
    }
}
