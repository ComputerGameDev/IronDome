using UnityEngine;

public class EnemyMissileSpawner : MonoBehaviour
{
    [Header("Enemy Missile Settings")]
    [SerializeField]
    private GameObject enemyMissilePrefab; // The enemy missile prefab
    [SerializeField]
    private Transform launcherTarget;      // The target (MissileLauncher object)

    [Header("Spawner Settings")]
    [SerializeField]
    private float spawnInterval = 3f;     // Time between spawns
    [SerializeField]
    private Transform[] spawnPoints;     // Array of spawn points for enemy missiles

    private void Start()
    {
        // Start spawning enemy missiles at regular intervals
        InvokeRepeating(nameof(SpawnEnemyMissile), 1f, spawnInterval);
    }

    private void SpawnEnemyMissile()
    {
        if (enemyMissilePrefab == null || launcherTarget == null || spawnPoints.Length == 0)
        {
            Debug.LogWarning("Spawner not properly configured.");
            return;
        }

        // Pick a random spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Spawn the enemy missile
        GameObject enemyMissile = Instantiate(enemyMissilePrefab, spawnPoint.position, Quaternion.identity);

        // Direct the missile toward the launcher target
        EnemyMissile missileScript = enemyMissile.GetComponent<EnemyMissile>();
        if (missileScript != null)
        {
            missileScript.SetTarget(launcherTarget);
        }
        else
        {
            Debug.LogError("Enemy missile prefab is missing the EnemyMissile script!");
        }
    }
}
