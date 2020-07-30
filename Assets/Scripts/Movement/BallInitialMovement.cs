using UnityEngine;

public class BallInitialMovement : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward * -5f;
    }
}
