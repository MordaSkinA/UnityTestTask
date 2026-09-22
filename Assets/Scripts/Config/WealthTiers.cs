using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/Wealth Tiers Config", fileName = "WealthTiers")]
public class WealthTiers : ScriptableObject
{
    [Serializable]
    public class Tier
    {
        public string tierName;
        public GameObject characterModelPrefab;
        public string statusPopupLabel;
        public GameObject environmentThemePrefab;
    }

    public List<Tier> tiers = new List<Tier>();
}