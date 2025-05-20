using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform cameraTransform;
    public float smoothSpeed = 5f;

    private CharacterController controller;
    private Vector3 velocity;
    private Vector3 smoothMoveVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(moveX, 0f, moveZ).normalized;

        if (inputDirection.magnitude >= 0.1f)
        {
            // Mover en la dirección de la cámara
            Vector3 moveDir = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0) * inputDirection;
            Vector3 targetVelocity = moveDir * moveSpeed;

            velocity = Vector3.SmoothDamp(velocity, targetVelocity, ref smoothMoveVelocity, 0.1f);
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
