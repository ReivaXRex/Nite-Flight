using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public const float m_PushForce = 20.0f;

    [SerializeField] ParticleSystem m_SmokeParticles;
    [SerializeField] ParticleSystem m_Explosion;
    [SerializeField] GameObject m_Model;
    [SerializeField] private bool m_isLowEnough;
    [SerializeField] private bool m_isAlive;

    //  private const float m_gravityModifier = 1.2f;
    //  private const float m_gravityModifierD = 0.2f;

    // Transform m_Transform;
    Rigidbody m_Rb;
    Animator m_Anim;
    CapsuleCollider m_CaCollider;
    AudioSource m_AudioSource;


    // Start is called before the first frame update
    void Start()
    {

        m_isAlive = true;
        // Physics.gravity *= m_gravityModifier;
        m_AudioSource = GetComponent<AudioSource>();
        m_CaCollider = GetComponent<CapsuleCollider>();
        m_Rb = GetComponent<Rigidbody>();

        // m_Transform = GetComponent<Transform>();
        m_Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        Movement();
        CheckPosition();
        StopMovementOnDeath();
    }
    private void Movement()
    {

        /*if (Input.GetKey(KeyCode.Space) && CheckPosition() && m_isAlive)
        {
            m_Rb.AddForce(Vector3.up * m_PushForce);
        }*/
        if ((Input.touchCount > 0 || Input.GetKey(KeyCode.Space)) && CheckPosition() && m_isAlive)
        {
            m_Rb.AddForce(Vector3.up * m_PushForce);

        }
    }

    private void StopMovementOnDeath()
    {
        if (transform.position.y <= -6.8f && !m_isAlive)
        {
            m_Rb.velocity = Vector3.zero;
        }
    }

    private bool CheckPosition()
    {
        if (transform.position.y > 2.9)
        {
            m_Rb.velocity = Vector3.zero;
            m_isLowEnough = false;

        }
        else
        {
            m_isLowEnough = true;
        }
        return m_isLowEnough;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            // m_CaCollider.enabled = false;
            m_CaCollider.isTrigger = true;
            // Physics.gravity *= m_gravityModifierD;
            Death();
            // Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground") && m_isAlive)
        {

            m_Rb.AddForce(Vector3.up * 4, ForceMode.Impulse);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground") && !m_isAlive)
        {
            Explode();
        }
    }

    private void Death()
    {
        m_isAlive = false;
        GameManager.Instance.PlayerDied();

        Breakdown();
        BreakdownForce();

        Invoke("GameOver", 3.0f);

    }

    private void Breakdown()
    {
        transform.Rotate(new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z));
        m_Anim.SetTrigger("Spin");
        m_SmokeParticles.Play();

        m_AudioSource.clip = AudioManager.Instance.GetBreakdownSound;
        m_AudioSource.Play();
    }

    private void BreakdownForce()
    {
        m_Rb.velocity = Vector3.zero;

        m_Rb.AddForce(Vector3.down * 2, ForceMode.Impulse);
    }


    private void Explode()
    {
        // m_AudioSource.Stop();
        m_SmokeParticles.Stop();
        m_Explosion.Play();
        m_Model.SetActive(false);
        m_AudioSource.clip = AudioManager.Instance.GetCrashSound;
        m_AudioSource.Play();
        // m_Explosion.Stop();
    }

    private void GameOver()
    {
        GameManager.Instance.GameOver();
        // m_Rb.velocity = Vector3.zero;
        Destroy(this.gameObject, 3f);
    }

}
