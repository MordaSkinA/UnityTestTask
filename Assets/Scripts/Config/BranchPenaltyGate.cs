using UnityEngine;

public class BranchPenaltyGate : GateTrigger
{
    // NEEDS VALIDATION: эффект красной ветки "ВЕЧЕРИНКА" не подтверждён референсом (REFERENCE_SPEC §5/§11). Дефолт 0 — заглушка.
    [SerializeField] int scorePenalty = 0;

    protected override void OnPassed(PlayerWealthState state, RunRewardState reward)
    {
        if (scorePenalty != 0)
        {
            state.AddScore(-scorePenalty);
        }
    }
}
