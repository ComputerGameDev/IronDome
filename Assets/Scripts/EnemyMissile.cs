using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    [SerializeField] private float speed = 10f; // Speed of the enemy missile
    [SerializeField] private GameObject explosionPrefab; // Explosion effect prefab (optional)
    private Transform target; // Target to move toward

    public void SetTarget(Transform targetTransform)
    {
        target = targetTransform;
    }

    void Update()
    {
        if (target != null)
        {
            // Move toward the target
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            // Check if the missile is close to the target
            if (Vector3.Distance(transform.position, target.position) < 0.5f)
            {
                HitTarget();
            }
        }
    }

    private void HitTarget()
    {
        Debug.Log("Enemy missile hit the launcher!");
        Destroy(gameObject); // Destroy this missile
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ensure collision is specifically with an object tagged as "PlayerMissile"
        if (other.CompareTag("PlayerMissile"))
        {
            Debug.Log("Enemy missile hit by player missile!");

            // Optional: Create explosion effect
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            // Destroy both missiles
            Destroy(gameObject); // Destroy this missile
            Destroy(other.gameObject); // Destroy the player missile
        }
    }
}
