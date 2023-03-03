using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    // components
    Rigidbody2D rb;
    Animator playerAnim;
    SpriteRenderer Sr;

    //Player
    float walkSpeed = 4f;
    float speedLimiter = 0.7f;
    float inputVertical;
    float inputHorizontal;
    private int maxHealth = 3;

    //gun
    public GameObject shootFrom;
    public GameObject bullet;

    //Ui
    public TextMeshProUGUI pointText;
    public int points;
    public GameObject gameOverScreen;

    //weapon switch
    public bool canShoot = true;
    public int currentWeapon = 0;
    public GameObject[] weapons;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerAnim = gameObject.GetComponent<Animator>();
        Sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        faceMouse();
        if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                if(canShoot)
                    {
                    Instantiate(bullet, shootFrom.transform.position, shootFrom.transform.rotation);
                    }
            }

        //switch weapons
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            SwithWeapons();
        }

    }
    private void FixedUpdate()
    {
        if(inputHorizontal != 0 || inputVertical != 0)
        {
            if(inputHorizontal != 0 && inputVertical != 0)
            {
                inputHorizontal *= speedLimiter;
                inputVertical *= speedLimiter;
            }
            rb.velocity = new Vector2(inputHorizontal * walkSpeed, inputVertical * walkSpeed);
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }
    }

    public void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = -direction;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            points++;
            Destroy(collision.gameObject);
            pointText.text = "Points: " + points;
        }
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Slime"))
        {
            maxHealth--;
            if(maxHealth <= 0)
            {
                //gameOver
                gameOverScreen.SetActive(true);
            }
        }
    }

    public void SwithWeapons()
    {
        currentWeapon++;
        if(currentWeapon >= weapons.Length)
        {
            currentWeapon = 0;
        }

        //gun
        if(currentWeapon == 0)
        {
            weapons[1].SetActive(false);

            weapons[0].SetActive(true);
            canShoot = true;
        }
        //sword
        if(currentWeapon == 1)
        {
            weapons[0].SetActive(false);

            weapons[1].SetActive(true);
            canShoot = false;
        }

    }
}
