using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public float m_Speed = 15f;

    private Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        Invoke("DestroySelf", 5.0f);
    }

    private void FixedUpdate()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + 
            transform.up * m_Speed * Time.deltaTime);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
