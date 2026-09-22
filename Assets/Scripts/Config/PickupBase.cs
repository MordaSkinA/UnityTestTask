using UnityEngine;

public abstract class PickupBase : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var state = other.GetComponentInParent<PlayerWealthState>();
        if (state == null)
            return;

        OnCollected(state);
        Destroy(gameObject);
    }

    protected abstract void OnCollected(PlayerWealthState state);
}