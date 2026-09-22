using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDUI : MonoBehaviour
{
    [SerializeField] GameFlowController gameFlow;
    [SerializeField] PlayerWealthState wealthState;
    [SerializeField] WealthTiers tiersConfig;
    [SerializeField] GameObject panelRoot;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI tierLabelText;
    [SerializeField] Image tierProgressFill;

    void OnEnable()
    {
        gameFlow.OnLevelBegin += Hide;
        gameFlow.OnGameplayStarted += HandleGameplayStarted;
        gameFlow.OnLevelWon += HandleLevelWon;
        gameFlow.OnLevelLost += HandleLevelLost;
        wealthState.OnScoreChanged += HandleScoreChanged;
        wealthState.OnTierChanged += HandleTierChanged;
    }

    void OnDisable()
    {
        gameFlow.OnLevelBegin -= Hide;
        gameFlow.OnGameplayStarted -= HandleGameplayStarted;
        gameFlow.OnLevelWon -= HandleLevelWon;
        gameFlow.OnLevelLost -= HandleLevelLost;
        wealthState.OnScoreChanged -= HandleScoreChanged;
        wealthState.OnTierChanged -= HandleTierChanged;
    }

    void HandleGameplayStarted()
    {
        panelRoot.SetActive(true);

        if (levelText != null)
            levelText.text = $"Уровень {gameFlow.CurrentLevelNumber}";

        HandleScoreChanged(0, wealthState.Score);
        HandleTierChanged(wealthState.TierIndex);
    }

    void HandleLevelWon(int multiplier)
    {
        panelRoot.SetActive(false);
    }

    void HandleLevelLost()
    {
        panelRoot.SetActive(false);
    }

    void Hide()
    {
        panelRoot.SetActive(false);
    }

    void HandleScoreChanged(int delta, int newScore)
    {
        scoreText.text = newScore.ToString();
    }

    void HandleTierChanged(int tierIndex)
    {
        if (tiersConfig == null || tierIndex < 0 || tierIndex >= tiersConfig.tiers.Count)
        {
            Debug.LogWarning($"[HUDUI] no tier data for index {tierIndex}");
            return;
        }

        tierLabelText.text = tiersConfig.tiers[tierIndex].statusPopupLabel;

        if (tierProgressFill != null)
        {
            int lastIndex = tiersConfig.tiers.Count - 1;
            tierProgressFill.fillAmount = lastIndex <= 0 ? 1f : (float)tierIndex / lastIndex;
        }
    }
}
