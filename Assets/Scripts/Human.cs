using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Human : MonoBehaviour
{
    public float m_Speed = 1.0f;
    public GameObject m_BulletPrefab;
    public GameObject ui_manager;

    public Text projText;
    public int projCount;
    public Text gullText;
    public int gullCount;

    private Rigidbody m_rigidbody;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        projCount = 0;
        gullCount = 0;
        projText.text = "";
        gullText.text = "";
        SetProjCountText();
        SetGullCountText();
    }

    private void Update()
    {
        Shoot();
        SetProjCountText();
        SetGullCountText();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(m_BulletPrefab, transform.position, transform.rotation);
            projCount += 1;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            ui_manager.GetComponent<UIManager>().showFinished();
        }
    }

    private void Move()
    {
        // TODO: Replace GetKey() with GetAxis()
        Vector3 input = Vector3.zero;
        if (Input.GetKey(KeyCode.D))
            input += Vector3.right;
        if (Input.GetKey(KeyCode.A))
            input += Vector3.left;

        input.Normalize();

        Vector3 movement = input * m_Speed * Time.deltaTime;
        m_rigidbody.MovePosition(m_rigidbody.position + movement);
    }

    void SetProjCountText()
    {
        projText.text = projCount.ToString();
    }

    public void SetGullCountText()
    {
        gullText.text = gullCount.ToString();
    }

}
