using UnityEngine;

public class PlayerAppearance : MonoBehaviour
{
    [SerializeField] PlayerWealthState wealthState;
    [SerializeField] WealthTiers tiersConfig;
    [SerializeField] Transform modelRoot;

    GameObject currentModelInstance;

    void Awake()
    {
        if (wealthState == null)
            wealthState = GetComponent<PlayerWealthState>();

        if (modelRoot == null || !modelRoot.gameObject.scene.IsValid())
            modelRoot = transform;

        Debug.Log($"[PlayerAppearance] modelRoot = {modelRoot?.name}, scene valid = {modelRoot?.gameObject.scene.IsValid()}");
    }

    void OnEnable()
    {
        wealthState.OnTierChanged += HandleTierChanged;
    }

    void OnDisable()
    {
        wealthState.OnTierChanged -= HandleTierChanged;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ApplyTier(wealthState.TierIndex);
    }

    void HandleTierChanged(int tierIndex)
    {
        ApplyTier(tierIndex);
    }

    void ApplyTier(int tierIndex)
    {
        if (tiersConfig == null || tierIndex < 0 || tierIndex >= tiersConfig.tiers.Count)
        {
            Debug.LogWarning($"[PlayerAppearance] no tier data for index {tierIndex}");
            
            
            return;
        }

        var tier = tiersConfig.tiers[tierIndex];
        if (tier.characterModelPrefab == null)
            return;

        if (currentModelInstance != null)
            Destroy(currentModelInstance);

        currentModelInstance = Instantiate(tier.characterModelPrefab, modelRoot);
        currentModelInstance.transform.localPosition = Vector3.zero;
        currentModelInstance.transform.localRotation = Quaternion.identity;
        Debug.Log($"[PlayerAppearance] ApplyTier({tierIndex}) called, frame={Time.frameCount}\n{System.Environment.StackTrace}");
    }
}