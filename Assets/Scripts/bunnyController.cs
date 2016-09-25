using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bunnyController : MonoBehaviour {
    public float bunnyJumpForce = 500f;
    private Rigidbody2D myRigidBdy;
    private Animator myAnim;
    private Collider2D myCollider;
    private float bunnyHurtTime = -1;
    public float playerScore;
    public Text scoreText;
    private int jumpTwice;
    public AudioSource jumpSound, deadSound;
	// Use this for initialization
	void Start () {
        myRigidBdy = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        playerScore = Time.time;
        jumpTwice = 2;
    }
	
	// Update is called once per frame
	void Update () {

        if (bunnyHurtTime == -1)
        {            
            if (Input.GetButtonUp("Jump"))
            {
                if (jumpTwice <= 2 && jumpTwice > 0)
                {
                    myRigidBdy.AddForce(transform.up * bunnyJumpForce);
                    jumpTwice = jumpTwice - 1;
                    jumpSound.Play();
                }
                
            }
            scoreText.text = (Time.time - playerScore).ToString("0.0");
            myAnim.SetFloat("Velocity", Mathf.Abs(myRigidBdy.velocity.y));
        } else
        {
            if(Time.time > bunnyHurtTime+2)
            {
                Application.LoadLevel(Application.loadedLevel);
            }      
        }       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        jumpTwice = 2;
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {

            foreach (CactusSpwan cacSpwan in FindObjectsOfType<CactusSpwan>())
            {
                cacSpwan.enabled = false;
            }
            foreach (runLeft rnLft in FindObjectsOfType<runLeft>())
            {
                rnLft.enabled = false;
            }
            bunnyHurtTime = Time.time;
            myAnim.SetBool("bunnyHurt", true);
            myRigidBdy.velocity = Vector2.zero;
            myRigidBdy.AddForce(transform.up * bunnyJumpForce);
            myCollider.enabled = false;
            deadSound.Play();
        }
    }
}