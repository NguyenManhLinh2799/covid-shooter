using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 targetPos; // Vi tri di chuyen toi
    public float delta;

    public float speed; // Toc do dao dong
    public float rangeX; // Gioi han x
    public float rangeY; // Gioi han y

    public GameObject bullet;
    public GameObject effect;

    public int HP;
    public int score;
    public Text HPDisplay;
    public Text scoreDisplay;
    public GameObject gameOver;
    public GameObject gameStart;
    public GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Tat huong dan
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameStart.SetActive(false);
            spawner.SetActive(true);
        }

        // Hien mau va diem so
        scoreDisplay.text = "Score: " + score.ToString();
        HPDisplay.text = "HP: " + HP.ToString();

        // Het mau
        if (HP <= 0)
        {
            Destroy(gameObject);
            gameOver.SetActive(true);
        }
        
        // Ban
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }

        // Di chuyen den vi tri dieu khien
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        float x = transform.position.x;
        float y = transform.position.y;
        if (Input.GetKey(KeyCode.W) && (transform.position.y + delta) <= rangeY) // Bam phim W
        {
            y += delta;
        }
        if (Input.GetKey(KeyCode.S) && (transform.position.y - delta) >= -1 * rangeY) // Bam phim S
        {
            y -= delta;
        }
        if (Input.GetKey(KeyCode.A) && (transform.position.x - delta) >= -1 * rangeX) // Bam phim A
        {
            x -= delta;
        }
        if (Input.GetKey(KeyCode.D) && (transform.position.x + delta) <= rangeX) // Bam phim D
        {
            x += delta;
        }
        targetPos = new Vector2(x, y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            HP--;
            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }
}
