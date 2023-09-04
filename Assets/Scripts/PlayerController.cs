using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int health = 5;
    private int score = 0;
    public float speed;
    public Text scoreText;
    public Text healthText;
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
                RestartScene();
                Debug.Log("Game Over!");
            }
        }

        if (other.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }
    }
    void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
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
