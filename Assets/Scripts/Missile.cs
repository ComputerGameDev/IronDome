using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab; // Explosion effect prefab
    [SerializeField]
    private float speed;                // Movement speed
    [SerializeField]
    private float rotationSpeed;        // Rotation speed

    private Vector3 targetPosition;     // Dynamic target position
    private Transform selfTransform;    // Reference to missile's transform

    public void Launch(Vector3 position, Vector3 direction, Vector3 target)
    {
        selfTransform = transform;
        selfTransform.position = position;
        targetPosition = target;
        Debug.Log($"Missile launched from {position} toward {targetPosition}");
    }

    private void FixedUpdate()
    {
        // Move and rotate toward the target position
        if (selfTransform != null)
        {
            Vector3 direction = (targetPosition - selfTransform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            selfTransform.rotation = Quaternion.RotateTowards(selfTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            selfTransform.position += selfTransform.forward * speed * Time.deltaTime;

            // Check if the missile is close to the target
            if (Vector3.Distance(selfTransform.position, targetPosition) < 0.5f)
            {
                Explode();
            }
        }
    }

    private void Explode()
    {
        // Instantiate explosion effect and destroy the missile
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
