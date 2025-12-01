using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] Transform player;   // The ball

    [Header("Rotation")]
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float minPitch = 10f;
    [SerializeField] float maxPitch = 45f;

    [Header("Zoom")]
    [SerializeField] float distance = 6f;
    [SerializeField] float zoomSpeed = 2f;
    [SerializeField] float minDistance = 2f;
    [SerializeField] float maxDistance = 10f;

    private float currentYaw = 0f;
    private float currentPitch = 20f;

    void LateUpdate()
    {
        // 1. Rotate with right mouse button
        if (Input.GetMouseButton(1))
        {
            currentYaw += Input.GetAxis("Mouse X") * rotationSpeed;
            currentPitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
            currentPitch = Mathf.Clamp(currentPitch, minPitch, maxPitch);
        }

        // 2. Zoom with scroll
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // 3. Calculate position: spherical orbit
        float pitchRad = Mathf.Deg2Rad * currentPitch;
        float yawRad = Mathf.Deg2Rad * currentYaw;

        Vector3 offset = new Vector3(
            distance * Mathf.Cos(pitchRad) * Mathf.Sin(yawRad),
            distance * Mathf.Sin(pitchRad),
            distance * Mathf.Cos(pitchRad) * Mathf.Cos(yawRad)
        );

        transform.position = player.position + offset;

        // 4. Look at the player
        transform.LookAt(player.position + Vector3.up * 0.5f);
    }
}
