using UnityEngine;
using System.Collections;

public class catsSceneTrigger : MonoBehaviour
{
    [SerializeField] private GameObject catTwoObject;

    private Movement playerMovement;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerMovement = collider.GetComponent<Movement>();
            playerMovement.canMove = false;
            
            catTwoObject.SetActive(true);

            // falas dos gatos e cutscenes

            StartCoroutine(StartCatsChallenge());
        }
    }

    private IEnumerator StartCatsChallenge()
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        
        yield return new WaitForSeconds(4);
        playerMovement.canMove = true;
    }
}
