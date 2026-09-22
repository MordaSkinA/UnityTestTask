using UnityEngine;

public class AlcoholPickup : PickupBase
{
    [SerializeField] int penalty = 20;

    protected override void OnCollected(PlayerWealthState state)
    {
        state.AddScore(-penalty);
    }
}