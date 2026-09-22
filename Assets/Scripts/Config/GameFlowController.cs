using UnityEngine;
using ButchersGames;

public class GameFlowController : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    [SerializeField] PlayerLocomotion playerLocomotion;
    [SerializeField] PlayerInput playerInput;
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

        PlacePlayerAtSpawnPoint();

        playerInput.OnFirstInput += HandleFirstInput;
        playerInput.enabled = true;
    }

    void OnDestroy()
    {
        levelManager.OnLevelStarted -= HandleLevelStarted;
        playerInput.OnFirstInput -= HandleFirstInput;
    }

    void HandleFirstInput()
    {
        playerLocomotion.enabled = true;
        levelManager.StartLevel();
    }

    void HandleLevelStarted()
    {
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