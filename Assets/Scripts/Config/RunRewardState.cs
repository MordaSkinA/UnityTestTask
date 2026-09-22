using UnityEngine;

public class RunRewardState : MonoBehaviour
{
    public int Multiplier { get; private set; } = 1;

    public void SetMultiplier(int multiplier)
    {
        Multiplier = multiplier;
        Debug.Log($"[RunRewardState] multiplier={Multiplier}");
    }
}
