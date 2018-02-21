using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffscreenSpawner : MonoBehaviour
{
    public GameObject m_Prefab;

    public float m_SpawnDelay = 2.5f;

    private float m_spawnTimer;

    private void Awake()
    {
        m_spawnTimer = m_SpawnDelay;
    }

    private void Update()
    {
        m_spawnTimer -= Time.deltaTime;
        if(m_spawnTimer <= 0)
        {
            
            // Spawn our new clone!
            Instantiate(m_Prefab, transform.position, Quaternion.identity);

            m_spawnTimer = m_SpawnDelay;
        }
    }
}
