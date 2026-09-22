using UnityEngine;

public class RewardMultiplierGate : GateTrigger
{
    [SerializeField] int multiplier = 2;

    protected override void OnPassed(PlayerWealthState state, RunRewardState reward)
    {
        reward.SetMultiplier(multiplier);
    }
}
