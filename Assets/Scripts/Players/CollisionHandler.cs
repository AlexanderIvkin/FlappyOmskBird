using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action<int> BonusableTouched;
    public event Action DangerableTouched;

    public void ProcessCollision(IInteractable interactable)
    {
        if (interactable is IDangerable)
        {
            DangerableTouched?.Invoke();
        }

        if (interactable is IBonusable)
        {
            IBonusable usefull = interactable as IBonusable;

            BonusableTouched?.Invoke(usefull.GetBonusValue());
        }
    }
}
