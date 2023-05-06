using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    public Rigidbody2D birdRigidbody;
    public float jumpPower;
    public Logic logic;
    public bool birdAlive = true;

    // Audio
    public AudioSource source;
    public AudioClip clip;
    private bool hasPlayedAudio = false;

    // Sprites
    public Sprite sprite1;
    public Sprite sprite2;
    private SpriteRenderer spriteRenderer;
    private bool isSprite1Active = true;

    //Button
    public Button jumpButton;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite1;
        jumpButton.onClick.AddListener(JumpOnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        // Jump with 'Spacebar' with the sprite.
        if(Input.GetKeyDown(KeyCode.Space) == true && birdAlive)
        {
            birdRigidbody.velocity = Vector2.up * jumpPower;

            if (isSprite1Active)
            {
                spriteRenderer.sprite = sprite2;
                isSprite1Active = false;
            }
            else
            {
                spriteRenderer.sprite = sprite1;
                isSprite1Active = true;
            }
        }
    }

    // This is where the bird collides with pipes or top-bottom wall.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasPlayedAudio) // Checking the audio if that played before or not.
        {
            source.PlayOneShot(clip);
            hasPlayedAudio = true; // Setting the flag to true to indicate that the audio has been played.
        }
        logic.gameOver();
        Destroy(jumpButton);
        birdAlive = false;
    }

    // A Method for Jump Button - Similar idea with Spacebar we are checking if bird is alive or not with the 'if' statment.
    void JumpOnButtonClick()
    {
        // This statement added to make sure sprites are rendering without any problem after we switch to the spacebar press.
        if (Input.GetKeyDown(KeyCode.Space) == false && birdAlive == true)
        {
            birdRigidbody.velocity = Vector2.up * jumpPower;

            if (isSprite1Active)
            {
                spriteRenderer.sprite = sprite2;
                isSprite1Active = false;
            }
            else
            {
                spriteRenderer.sprite = sprite1;
                isSprite1Active = true;
            }
        }
    }
}
