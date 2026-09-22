using UnityEngine;
using TMPro;

public class WinScreenUI : MonoBehaviour
{
    [SerializeField] GameFlowController gameFlow;
    [SerializeField] GameObject panelRoot;
    [SerializeField] TextMeshProUGUI multiplierText;

    void OnEnable()
    {
        gameFlow.OnLevelBegin += Hide;
        gameFlow.OnLevelWon += Show;
    }

    void OnDisable()
    {
        gameFlow.OnLevelBegin -= Hide;
        gameFlow.OnLevelWon -= Show;
    }

    void Show(int multiplier)
    {
        if (multiplierText != null)
            multiplierText.text = $"X{multiplier}";

        panelRoot.SetActive(true);
    }

    void Hide()
    {
        panelRoot.SetActive(false);
    }

    public void OnContinueClicked()
    {
        gameFlow.OnNextLevelClicked();
    }
}
