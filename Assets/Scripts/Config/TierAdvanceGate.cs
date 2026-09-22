public class TierAdvanceGate : GateTrigger
{
    protected override void OnPassed(PlayerWealthState state, RunRewardState reward)
    {
        state.AdvanceTier();
    }
}
