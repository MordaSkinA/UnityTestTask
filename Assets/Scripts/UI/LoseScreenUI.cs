using UnityEngine;

public class LoseScreenUI : MonoBehaviour
{
    [SerializeField] GameFlowController gameFlow;
    [SerializeField] GameObject panelRoot;

    void OnEnable()
    {
        gameFlow.OnLevelBegin += Hide;
        gameFlow.OnLevelLost += Show;
    }

    void OnDisable()
    {
        gameFlow.OnLevelBegin -= Hide;
        gameFlow.OnLevelLost -= Show;
    }

    void Show()
    {
        panelRoot.SetActive(true);
    }

    void Hide()
    {
        panelRoot.SetActive(false);
    }

    public void OnRetryClicked()
    {
        gameFlow.OnRetryClicked();
    }
}
