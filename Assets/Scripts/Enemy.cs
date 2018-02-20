using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public int m_Health = 3;
    public float m_Speed = 7f;
    public GameObject ui_manager;
    public int count = 0;

    private GameObject m_player;
    private Rigidbody m_rigidbody;

    private void Awake()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Destroy(other.gameObject);
            if (--m_Health <= 0)
            {
                count += 1;
                Destroy(this.gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 delta = m_player.transform.position - transform.position;
        Vector3 movement = -transform.up * m_Speed * Time.deltaTime;
        m_rigidbody.MovePosition(m_rigidbody.position + movement);
    }
}
