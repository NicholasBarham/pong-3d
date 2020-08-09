using UnityEngine;

namespace Pong
{
    public interface IBallVelocity
    {
        Vector3 LastGivenVelocity { get; }
        void SetVelocity(Vector3 velocity);
    }
}