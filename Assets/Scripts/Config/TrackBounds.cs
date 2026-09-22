using UnityEngine;

[CreateAssetMenu(menuName = "Config/Track Bounds Config", fileName = "TrackBounds")]
public class TrackBounds : ScriptableObject
{
    public float minX = -3f;
    public float maxX = 3f;
}