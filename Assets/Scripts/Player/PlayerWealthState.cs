using System;
using UnityEngine;

public class PlayerWealthState : MonoBehaviour
{
    public int Score { get; private set; }
    public int TierIndex { get; private set; }

    public event Action<int, int> OnScoreChanged;
    public event Action<int> OnTierChanged;

    public void AddScore(int delta)
    {
        Score += delta;
        Debug.Log($"[PlayerWealthState] delta={delta} score={Score}");
        OnScoreChanged?.Invoke(delta, Score);
    }

    public void AdvanceTier()
    {
        TierIndex++;
        Debug.Log($"[PlayerWealthState] tier={TierIndex}");
        OnTierChanged?.Invoke(TierIndex);
    }

    public void ResetForNewRun()
    {
        Score = 0;
        TierIndex = 0;
        OnScoreChanged?.Invoke(0, Score);
        OnTierChanged?.Invoke(TierIndex);
    }
}
