using System;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public event Action OnLevelFinished;

    void OnTriggerEnter(Collider other)
    {
        var state = other.GetComponentInParent<PlayerWealthState>();
        if (state == null)
            return;

        OnLevelFinished?.Invoke();
    }
}
