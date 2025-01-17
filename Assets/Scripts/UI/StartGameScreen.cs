using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScreen : Window
{
    public event Action PlayButtonClicked;

    protected override void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }
}
