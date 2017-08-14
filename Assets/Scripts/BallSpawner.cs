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
        // public float frequency = 5;
        // public float amplitude = 6;

        

        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }

        // Use this for initialization
        void Start()
        {

            InvokeRepeating("SpawnBalls", 2.0f, 1.0f);
            // InvokeRepeating([function], [start seconds float], [repeating seconds float])


        }

        // Update is called once per frame
        void Update()
        {
            
        }



        void SpawnBalls() // for 3D
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

                // Cancel out the Z
                // randomPos.z = 0;
                // randomPos.y = 0;

                // Set spawned object's position
                clone.transform.position = randomPos;                               
            }
        }

        

    }
}