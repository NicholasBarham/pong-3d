using UnityEngine;

namespace Util.GameEvents
{
    [CreateAssetMenu(fileName = "VoidGameEvent", menuName = "Game Events/Void")]
    public class VoidEvent : BaseGameEvent<Void>
    {
        public void Raise() => Raise(new Void());
    }
}