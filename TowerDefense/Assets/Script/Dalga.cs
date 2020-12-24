using System.Collections;
using UnityEngine;

public class Dalga : MonoBehaviour
{

    public static int EnemiesAlive = 0;
    public WaveS[] dalgalar;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countDown = 2f;

    public GameManager gameManager;
    
    private int waveIndex = 0;

    void Start()
    {
        EnemiesAlive = 0;
    }

    void Update()
    {
        if(EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == dalgalar.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (GameManager.gameEnded)
        {
            this.enabled = false;
            return;
        }

        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
            return;
        }

        countDown -= Time.deltaTime; 
    }

    IEnumerator SpawnWave()
    {
        WaveS wave = dalgalar[waveIndex];
        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(1f/wave.rate);
        }
        waveIndex++;
    }



    void SpawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }


}
