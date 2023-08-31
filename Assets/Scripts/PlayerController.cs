using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int health = 5;
    private int score = 0;
    public float speed;
    
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
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Trap"))
        {
            health--;
            Debug.Log("Healt: " + health);
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
}
