using System;
using UnityEngine;
using ButchersGames;

public class GameFlowController : MonoBehaviour
{
    public event Action OnLevelBegin;
    public event Action OnGameplayStarted;
    public event Action<int> OnLevelWon;
    public event Action OnLevelLost;

    public int CurrentLevelNumber => LevelManager.CurrentLevel;

    [SerializeField] LevelManager levelManager;
    [SerializeField] PlayerLocomotion playerLocomotion;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] PlayerWealthState playerWealthState;
    [SerializeField] RunRewardState runRewardState;
    [SerializeField] FinishTrigger finishTrigger;
    [SerializeField] LoseTrigger loseTrigger;
    [SerializeField] string spawnPointName = "PlayerSpawnPoint";

    void Awake()
    {
        playerLocomotion.enabled = false;
        playerInput.enabled = false;
    }

    void Start()
    {
        levelManager.Init();
        levelManager.OnLevelStarted += HandleLevelStarted;

        playerInput.OnFirstInput += HandleFirstInput;

        if (finishTrigger != null)
            finishTrigger.OnLevelFinished += HandleLevelFinished;

        if (loseTrigger != null)
            loseTrigger.OnPlayerLost += HandleLevelLost;

        BeginLevel();
    }

    void OnDestroy()
    {
        levelManager.OnLevelStarted -= HandleLevelStarted;
        playerInput.OnFirstInput -= HandleFirstInput;

        if (finishTrigger != null)
            finishTrigger.OnLevelFinished -= HandleLevelFinished;

        if (loseTrigger != null)
            loseTrigger.OnPlayerLost -= HandleLevelLost;
    }

    void BeginLevel()
    {
        playerLocomotion.enabled = false;
        playerInput.ResetFirstInput();

        PlacePlayerAtSpawnPoint();

        playerInput.enabled = true;

        OnLevelBegin?.Invoke();
    }

    void HandleFirstInput()
    {
        playerLocomotion.enabled = true;
        levelManager.StartLevel();

        OnGameplayStarted?.Invoke();
    }

    void HandleLevelStarted()
    {
    }

    void HandleLevelFinished()
    {
        playerLocomotion.enabled = false;
        playerInput.enabled = false;
        Debug.Log($"[GameFlowController] level finished, multiplier={runRewardState.Multiplier}");

        OnLevelWon?.Invoke(runRewardState.Multiplier);
    }

    void HandleLevelLost()
    {
        playerLocomotion.enabled = false;
        playerInput.enabled = false;
        Debug.Log("[GameFlowController] level lost");

        OnLevelLost?.Invoke();
    }

    public void OnNextLevelClicked()
    {
        playerWealthState.ResetForNewRun();
        runRewardState.ResetForNewRun();
        levelManager.NextLevel();
        BeginLevel();
    }

    public void OnRetryClicked()
    {
        playerWealthState.ResetForNewRun();
        runRewardState.ResetForNewRun();
        levelManager.RestartLevel();
        BeginLevel();
    }

    void PlacePlayerAtSpawnPoint()
    {
        var spawnPoint = FindSpawnPoint();
        if (spawnPoint == null)
        {
            Debug.LogWarning($"SP \"{spawnPointName}\" not found");
            return;
        }

        playerLocomotion.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
    }

    Transform FindSpawnPoint()
    {
        foreach (Transform child in levelManager.transform)
        {
            var found = FindInChildren(child, spawnPointName);
            if (found != null)
                return found;
        }
        return null;
    }

    Transform FindInChildren(Transform root, string targetName)
    {
        if (root.name == targetName)
            return root;

        foreach (Transform child in root)
        {
            var found = FindInChildren(child, targetName);
            if (found != null)
                return found;
        }
        return null;
    }
}
