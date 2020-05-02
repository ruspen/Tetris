using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris.GameModule
{
    public class Spawner : MonoBehaviour
    {
        public GameObject[] Groups;


        public Transform SpawnNext()
        {
            int i = Random.Range(0, Groups.Length);

            // Spawn Group at current Position
            GameObject gameObject = Instantiate(Groups[i], transform.position, Quaternion.identity);
            return gameObject.transform;
        }

    }
}

