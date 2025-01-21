using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action<int> ScoreableTouched;
    public event Action DangerableTouched;

    public void ProcessCollision(IInteractable interactable)
    {
        if (interactable is IDangerable)
        {
            DangerableTouched?.Invoke();
        }

        if (interactable is IScoreable)
        {
            IScoreable usefull = interactable as IScoreable;

            ScoreableTouched?.Invoke(usefull.GetBonusValue());
        }
    }
}
