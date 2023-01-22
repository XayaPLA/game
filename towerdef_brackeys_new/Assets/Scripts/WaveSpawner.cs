using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 7f;
    public float countdown = 10f;
    private int WaveIndex = 0;
    public Text countDownText;


    void Update()
    {
        if (countdown <= 0) {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        else if (countdown <= 5) {
            countDownText.text = Mathf.Floor(countdown + 1).ToString();
        }
        else
        {
            countDownText.text = "Wave incoming!!";
        }
        countdown -= Time.deltaTime;
        
    }

    IEnumerator SpawnWave()
    {
        WaveIndex++;
        for (int i = 0; i < WaveIndex; i++)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("Wave incoming!!");
    }


}
