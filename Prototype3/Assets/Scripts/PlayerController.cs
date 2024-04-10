
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //The player's Rigidbody
    private Rigidbody playerRb;
    //Jump force
    private float jumpForce = 15.0f;
    //Gravity Modifier
    [SerializedField] private float gravityModifier;
    //Are we on the ground?
    private bool isOnGround = true;
    //Is the Game Over
    [SerializedField] private bool gameOver {get; private set;};

    //Player Animator
    private Animator playerAnim;

    //ParticleSystem explosion
    [SerializedField] private ParticleSystem explositionParticle;
    //ParticleSystem dirt
    [SerializedField] private ParticleSystem dirtParticle;

    //Jump sound
    [SerializedField] private AudioClip jumpSound;
    //Crash sound
    [SerializedField] private AudioClip crashSound;
    //Player Audio
    [SerializedField] private AudioSource playerAudio;
private const string gameOver = "Gameover"
    // Start is called before the first frame update
    void Start()
    {
        //Get the rigidbody
        playerRb = GetComponent<Rigidbody>();
        //Connect the Animator
        playerAnim = GetComponent<Animator>();
        //Player Audio
        //playerAudio.GetComponent<AudioSource>();
        //update the gravity
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //If we press space, jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //trigger the jump animation
            playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            dirtParticle.Stop();

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        private const string GROUND_TAG = "Ground"
        if (collision.gameObject.CompareTag(GROUND_TAG"));
        {
            dirtParticle.Play();
            isOnGround = true;
        }
        private const string OBSTACLE_TAG = " Obstacle"
        else if (collision.gameObject.CompareTag(OBSTACLE));
        {
            explositionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);

            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}
