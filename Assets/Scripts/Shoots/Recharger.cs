using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recharger : MonoBehaviour
{
    [SerializeField] private float _cooldown;

    private Coroutine StartRechargingCoroutine;

    public float Cooldown => _cooldown;
    public bool IsRecharge { get; private set; } = true;

    public void Recharge()
    {
        if (StartRechargingCoroutine != null)
            return;

        StartRechargingCoroutine = StartCoroutine(StartRecharging());
    }

    private IEnumerator StartRecharging()
    {
        var wait = new WaitForSeconds(_cooldown);

        IsRecharge = false;

        yield return wait;

        IsRecharge = true;
        StartRechargingCoroutine = null;
    }
}
