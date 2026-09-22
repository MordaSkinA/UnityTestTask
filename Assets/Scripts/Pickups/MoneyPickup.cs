using UnityEngine;

public class MoneyPickup : PickupBase
{
    [SerializeField] int value = 5;

    protected override void OnCollected(PlayerWealthState state)
    {
        state.AddScore(value);
    }
}