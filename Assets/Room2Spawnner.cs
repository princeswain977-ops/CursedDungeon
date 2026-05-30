using UnityEngine;

public class Room2Spawner : MonoBehaviour
{
    public GameObject slimePrefab;

    public GameObject flyingEyePrefab;

    public GameObject chest;

    private bool spawned = false;

    private bool chestSpawned = false;

    void Update()
    {
        if (!spawned)
        {
            SpawnEnemies();

            spawned = true;
        }

        GameObject[] enemies =
            GameObject.FindGameObjectsWithTag("Enemy");

        if (spawned
            && enemies.Length == 0
            && !chestSpawned
            && chest != null)
        {
            chest.SetActive(true);

            chestSpawned = true;
        }
    }

    void SpawnEnemies()
    {
        Instantiate(
            slimePrefab,
            new Vector2(28, 2),
            Quaternion.identity
        );

        Instantiate(
            slimePrefab,
            new Vector2(32, -2),
            Quaternion.identity
        );

        Instantiate(
            flyingEyePrefab,
            new Vector2(30, 3),
            Quaternion.identity
        );
    }
}