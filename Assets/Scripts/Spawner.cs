
using UnityEngine;

public class Spawner: MonoBehaviour
{
    public GameObject prefabToSpawnEnemies;
    public GameObject prefabToSpawnCoins;
    [SerializeField] Transform[] spawnEnemiesPoints;
    [SerializeField] Transform[] spawnCoinsPoints;
    

    private void Start()
    {
        SpawnAllEnemies();
        SpawnAllCoins();
    }

    private void SpawnAllEnemies()
    {
        foreach (Transform point in spawnEnemiesPoints)
        {
            if (point != null && prefabToSpawnEnemies != null)
            {
                Instantiate(prefabToSpawnEnemies, point.position, point.rotation);
            }
        }
    }
    private void SpawnAllCoins()
    {
        foreach (Transform point in spawnCoinsPoints)
        {
            if (point != null && prefabToSpawnCoins != null)
            {
                Instantiate(prefabToSpawnCoins, point.position, point.rotation);
            }
        }
    }
}



