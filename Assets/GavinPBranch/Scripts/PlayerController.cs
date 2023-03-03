using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    // components
    Rigidbody2D rb;
    Animator playerAnim;

    //Player
    float walkSpeed = 4f;
    float speedLimiter = 0.7f;
    float inputVertical;
    float inputHorizontal;

    //gun
    public GameObject shootFrom;
    public GameObject bullet;

    //points
    public TextMeshProUGUI pointText;
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        faceMouse();
        if(Input.GetKeyDown(KeyCode.Mouse0))
            {
            Instantiate(bullet, shootFrom.transform.position, shootFrom.transform.rotation);
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
    }
}
