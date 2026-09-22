using UnityEngine;

public class StartScreenUI : MonoBehaviour
{
    [SerializeField] GameFlowController gameFlow;
    [SerializeField] GameObject panelRoot;

    void OnEnable()
    {
        gameFlow.OnLevelBegin += Show;
        gameFlow.OnGameplayStarted += Hide;
    }

    void OnDisable()
    {
        gameFlow.OnLevelBegin -= Show;
        gameFlow.OnGameplayStarted -= Hide;
    }

    void Show()
    {
        panelRoot.SetActive(true);
    }

    void Hide()
    {
        panelRoot.SetActive(false);
    }
}
