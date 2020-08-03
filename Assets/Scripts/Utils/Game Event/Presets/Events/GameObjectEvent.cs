using UnityEngine;

namespace Util.GameEvents
{
    [CreateAssetMenu(fileName = "GameObjectGameEvent", menuName = "Game Events/GameObject")]
    public class GameObjectEvent : BaseGameEvent<GameObject> { }
}