using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Collider spawnArea;
    [SerializeField] private GameObject[] FruitsPrefabs;

    public GameObject bombPrefab;
    [SerializeField] GameObject Timeprefab;
    [SerializeField] GameObject SpeedPrefab;

    [Range(0f, 1f)]
    public float bombChance = 0.04f;
    public float TimerChance = 0.06f;
    public float SpeedChance = 0.04f;

    public AudioSource BombAudio;


    [SerializeField] private float minSpawnDelay = 0.25f;
    [SerializeField] private float maxSpawnDelay = 0.75f;

    [SerializeField] private float minAngle = -15f;
    [SerializeField] private float maxAngle = 15f;


    [SerializeField] private float minForce = 18f;
    [SerializeField] private float maxForce = 22f;


    [SerializeField] private float maxlifetime = 5f;

    private void Awake()
    {
        spawnArea = GetComponent<Collider>();
        BombAudio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);

        while (enabled)
        {
           
            //if (speedprefab.GetComponent<SpeedBoost>().is_speed)
            //{
            //    maxSpawnDelay = 0.5f;
            //}
            //else
            //{
            //    maxSpawnDelay = 1f;
            //}
            if(FindObjectOfType<GameManager>().timeRemaining < 10)
            {
                TimerChance = 0.1f;
                SpeedChance = 0.07f;
            }
            GameObject prefab = FruitsPrefabs[UnityEngine.Random.Range(0,FruitsPrefabs.Length)];
            GameObject timerprefab = FruitsPrefabs[UnityEngine.Random.Range(0, FruitsPrefabs.Length)];
            GameObject speedprefab = FruitsPrefabs[UnityEngine.Random.Range(0, FruitsPrefabs.Length)];

            float randomvalue = UnityEngine.Random.value;
            float randomtimervalue = UnityEngine.Random.value;
            float randomspeedvalue = UnityEngine.Random.value;

            if (randomvalue < bombChance && Time.timeScale == 1  )
            {
                prefab = bombPrefab;
                BombAudio.Play();
            }

            if (randomtimervalue < TimerChance && Time.timeScale == 1)
            {
                timerprefab = Timeprefab;
                Vector3 timerposition = new Vector3();
                timerposition.x = UnityEngine.Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
                timerposition.y = UnityEngine.Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
                timerposition.z = UnityEngine.Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);
                Quaternion timerrotation = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(minAngle, maxAngle));
                GameObject timer = Instantiate(timerprefab, timerposition, timerrotation);
                Destroy(timer, maxlifetime);

                float forcee = UnityEngine.Random.Range(minForce, maxForce);

                timer.GetComponent<Rigidbody>().AddForce(timer.transform.up * forcee, ForceMode.Impulse);

                //BombAudio.Play();
            }
            if (randomspeedvalue < SpeedChance && Time.timeScale ==1)
            {
                speedprefab = SpeedPrefab;
                Vector3 timerposition = new Vector3();
                timerposition.x = UnityEngine.Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
                timerposition.y = UnityEngine.Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
                timerposition.z = UnityEngine.Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);
                Quaternion timerrotation = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(minAngle, maxAngle));
                GameObject timer = Instantiate(speedprefab, timerposition, timerrotation);
                Destroy(timer, maxlifetime);

                float forcee = UnityEngine.Random.Range(minForce, maxForce);

                timer.GetComponent<Rigidbody>().AddForce(timer.transform.up * forcee, ForceMode.Impulse);

                //BombAudio.Play();
            }


            Vector3 position = new Vector3();
            position.x = UnityEngine.Random.Range(spawnArea.bounds.min.x,spawnArea.bounds.max.x);
            position.y = UnityEngine.Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            position.z = UnityEngine.Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);


         

            Quaternion rotation = Quaternion.Euler(0f,0f, UnityEngine.Random.Range(minAngle,maxAngle));

            GameObject fruit = Instantiate(prefab, position, rotation);
            Destroy(fruit,maxlifetime);

      

            float force = UnityEngine.Random.Range(minForce,maxForce);
            fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);


            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }
}
