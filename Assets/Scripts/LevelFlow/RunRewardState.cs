using System;
using UnityEngine;

public class RunRewardState : MonoBehaviour
{
    public int Multiplier { get; private set; } = 1;

    public event Action<int> OnMultiplierChanged;

    public void SetMultiplier(int multiplier)
    {
        Multiplier = multiplier;
        Debug.Log($"[RunRewardState] multiplier={Multiplier}");
        OnMultiplierChanged?.Invoke(Multiplier);
    }

    public void ResetForNewRun()
    {
        Multiplier = 1;
        OnMultiplierChanged?.Invoke(Multiplier);
    }
}
