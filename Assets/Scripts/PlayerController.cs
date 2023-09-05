using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private readonly float delay = 3;
    public int health = 5;
    private int score = 0;
    public float speed;
    public Text scoreText;
    public Text healthText;
    public GameObject playerWinLose;
    public Text textWinLoseColor;
    public Text textWinLose;
    public Image backgroundWinLose;
    private Color winTextColor = Color.black;
    private Color backgroundWinColor = Color.green;
    private Color loseTextColor = Color.black;
    private Color backgroundLoseColor = Color.red;
    public Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");
        
        Vector3 moveXYZ = new Vector3 (movX, 0f, movZ);
        rigidbody.AddForce (moveXYZ * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            Destroy(other.gameObject);
            SetScoreText();
        }

        if (other.CompareTag("Trap"))
        {
            health--;
            SetHealthText();

            if (health <= 0)
            {
                playerWinLose.SetActive(true);
                textWinLose.text = "Game Over!";
                textWinLoseColor.color = loseTextColor;
                backgroundWinLose.color = backgroundLoseColor;
                StartCoroutine(Countdown());
            }
        }

        if (other.CompareTag("Goal"))
        {
            Debug.Log(delay.ToString());
            playerWinLose.SetActive(true);
            textWinLose.text = "You Win!";
            textWinLoseColor.color = winTextColor;
            backgroundWinLose.color = backgroundWinColor;
            StartCoroutine(Countdown());
        }
    }

    private void StartCorountine(IEnumerator enumerator)
    {
        throw new NotImplementedException();
    }

    void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(delay);
        RestartScene();
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
}
