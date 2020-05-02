using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris.GameModule
{
    public class Spawner : MonoBehaviour
    {
        public GameObject[] Groups;


        public void SpawnNext()
        {
            int i = Random.Range(0, Groups.Length);

            // Spawn Group at current Position
            Instantiate(Groups[i], transform.position, Quaternion.identity);
        }


        void Start()
        {
            SpawnNext();
        }

        
        void Update()
        {

        }
    }
}

