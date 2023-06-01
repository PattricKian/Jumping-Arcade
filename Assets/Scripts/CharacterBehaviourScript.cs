using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class CharacterBehaviourScript : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 700;
    private float Move;
    private Vector2 startPosition;

    public Rigidbody2D rb;

    public bool isGrounded = false;
    private Animator anim;
    public UnityEvent coinCollect;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource collectSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;
    public GameObject winScreenText;
    [SerializeField] private AudioSource winSoundEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        winScreenText.SetActive(false);
        startPosition = transform.position;
    }

    void Update()
    {
        // Check if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            Move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(speed * Move, rb.velocity.y);

            // Check if the player is moving horizontally and grounded to set the animation
            if (!anim.GetBool("isRunning") && isGrounded)
            {
                anim.SetBool("isRunning", true);
            }
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    void Jump()
    {
        // Check if the player is grounded before jumping
        if (isGrounded)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            isGrounded = false; // Set isGrounded to false to prevent multiple jumps
            jumpSoundEffect.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Reset")
        {
            deathSoundEffect.Play();
            rb.velocity = Vector2.zero;
            transform.position = startPosition;
        }
        else if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "Point")
        {
            collectSoundEffect.Play();
            coinCollect.Invoke();
            ScoreManager.instance.AddPoint();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Win")
        {
            winSoundEffect.Play();
            StartCoroutine(ShowWinScreen());
        }
    }

    private IEnumerator ShowWinScreen()
    {
        // Zobraziù "You win" na obrazovke GUI (prÌkladom mÙûe byù aktÌvny textov˝ objekt)
        winScreenText.SetActive(true);

        yield return new WaitForSeconds(10f);

        // Prepn˙ù scÈnu na MainMenu
        SceneManager.LoadScene("MainMenu");
    }









}
