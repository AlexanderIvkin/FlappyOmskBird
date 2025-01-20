public class ShotKeyViewer : KeysPressedViewer
{
    private void OnEnable()
    {
        InputReader.ShotKeyPressed += ChangeKeyColor;
    }

    private void OnDisable()
    {
        InputReader.ShotKeyPressed -= ChangeKeyColor;
    }
}
