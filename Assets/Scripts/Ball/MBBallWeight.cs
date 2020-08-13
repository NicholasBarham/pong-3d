using Pong;
using UnityEngine;
using Util.Variables;

public class MBBallWeight : MonoBehaviour, IBallWeight
{
    [Range(0f, 1f)]
    [SerializeField]
    private float ballWeight = 0.5f;

    public float GetWeight() => ballWeight;
}
