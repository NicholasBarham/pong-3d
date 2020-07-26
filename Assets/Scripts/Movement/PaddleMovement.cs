using UnityEngine;

namespace Pong
{
    public class PaddleMovement : MonoBehaviour, IMove
    {
        [SerializeField]
        private Transform leftLimit = null;

        [SerializeField]
        private Transform rightLimit = null;

        public void Move(float input)
        {
            Vector3 currentPos = transform.position;
            currentPos.x = Mathf.Clamp(currentPos.x + input * Time.deltaTime, leftLimit.position.x, rightLimit.position.x);
            transform.position = currentPos;
        }
    }
}