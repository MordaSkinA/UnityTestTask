using UnityEngine;

public abstract class GateTrigger : MonoBehaviour
{
    bool hasTriggered;

    void OnTriggerEnter(Collider other)
    {
        if (hasTriggered)
            return;

        var state = other.GetComponentInParent<PlayerWealthState>();
        if (state == null)
            return;

        var reward = other.GetComponentInParent<RunRewardState>();
        if (reward == null)
            return;

        hasTriggered = true;
        OnPassed(state, reward);
    }

    protected abstract void OnPassed(PlayerWealthState state, RunRewardState reward);
}
