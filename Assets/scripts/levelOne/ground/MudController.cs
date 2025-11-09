using UnityEngine;

public class MudController : MonoBehaviour
{   
    private Movement playerMovement;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement = collision.gameObject.GetComponent<Movement>();

            playerMovement.speed = 2f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement.speed = 6f;
        }
    }
}
