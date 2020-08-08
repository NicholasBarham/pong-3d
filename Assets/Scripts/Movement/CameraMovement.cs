using UnityEngine;

namespace Pong
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        private Transform mainPlayerPaddle = null;

        [SerializeField]
        private Transform mainPlayerCentre = null;

        [SerializeField]
        [Range(0f, 1f)]
        private float cameraSlowMultiplier = 0.1f;

        void LateUpdate()
        {
            float paddleXCentre = mainPlayerCentre.position.x;
            float paddleXPos = mainPlayerPaddle.position.x;
            float diff = paddleXPos - paddleXCentre;
            Vector3 cameraPos = transform.position;
            cameraPos.x = paddleXCentre + diff * cameraSlowMultiplier;
            transform.position = cameraPos;
        }
    }
}