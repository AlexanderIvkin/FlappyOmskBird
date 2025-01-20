using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusZone : IBonusable
{
    [SerializeField] private int _bonusValue;

    public int GetBonusValue()
    {
        return _bonusValue;
    }
}
