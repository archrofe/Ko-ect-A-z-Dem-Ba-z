using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoopsArrays
{
    public class BallSpawner : MonoBehaviour
    {

        public GameObject[] spawnPrefabs;
        public float spawnRadius = 1f;
        public int spawnAmount = 5;
                

        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }

        // Use this for initialization
        void Start()
        {

            InvokeRepeating("SpawnBalls", 2.0f, 1.0f);
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }



        void SpawnBalls()
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                // Spawned new GameObject
                int randomIndex = Random.Range(0, spawnPrefabs.Length);

                // Store randomly selected prefab
                GameObject randomPrefab = spawnPrefabs[randomIndex];

                // Instantiate randomly selected prefab
                GameObject clone = Instantiate(randomPrefab);

                // Calculate random position within sphere
                float x = 0; // 
                float y = 0;
                float z = 0; // 
                Vector3 randomPos = transform.position + new Vector3(x, y, z); // calculate random position

                // Set spawned object's position
                clone.transform.position = randomPos;                               
            }
        }

        

    }
}