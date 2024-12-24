using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Prefab de la moneda
    public float spawnInterval = 2f; // Intervalo entre spawns
    public Vector2 spawnAreaMin; // Coordenadas mínimas del área de spawn
    public Vector2 spawnAreaMax; // Coordenadas máximas del área de spawn

    void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            SpawnCoin();
            yield return new WaitForSeconds(spawnInterval); // Espera antes de spawnear otra moneda
        }
    }

    private void SpawnCoin()
    {
        // Genera una posición aleatoria dentro del área
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector2 spawnPosition = new Vector2(x, y);

        // Instancia la moneda
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}
