using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [Header("Missile Launch Settings")]
    [SerializeField]
    private GameObject missilePrefab; // The missile prefab
    [SerializeField]
    private Transform launchPoint;    // The point where missiles are launched
    [SerializeField]
    private float missileSpeed = 20f; // Speed of the fired missile

    [Header("Launcher Defense Settings")]
    [SerializeField]
    private GameObject explosionPrefab; // Explosion effect when hit by an enemy missile

    void Update()
    {
        // Check for mouse click to fire missiles
        if (Input.GetMouseButtonDown(0))
        {
            FireMissileToMousePosition();
        }
    }

    private void FireMissileToMousePosition()
    {
        // Raycast to find where the mouse is pointing
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 targetPosition = hit.point;

            // Instantiate the missile at the launch point
            GameObject missile = Instantiate(missilePrefab, launchPoint.position, Quaternion.identity);

            // Calculate the direction to the target and set missile velocity
            Vector3 direction = (targetPosition - launchPoint.position).normalized;
            Rigidbody missileRb = missile.GetComponent<Rigidbody>();

            if (missileRb != null)
            {
                missileRb.linearVelocity = direction * missileSpeed;
                Debug.Log("Missile fired toward: " + targetPosition);
            }
            else
            {
                Debug.LogError("Missile prefab is missing a Rigidbody component.");
            }
        }
        else
        {
            Debug.LogWarning("Mouse click did not hit any collider.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detect collisions with enemy missiles
        if (other.CompareTag("EnemyMissile"))
        {
            Debug.Log("MissileLauncher hit by an enemy missile!");

            // Optional: Create explosion effect
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            Destroy(other.gameObject); // Destroy the enemy missile

            // Optional: Handle destruction or health reduction of the launcher
            // Uncomment this line if the launcher should be destroyed on impact:
            // Destroy(gameObject);
        }
    }
}
