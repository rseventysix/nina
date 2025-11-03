using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class birdSceneTrigger : MonoBehaviour
{
    [SerializeField] private GameObject birdObject;
    [SerializeField] private GameObject birdObjectTwo;
    [SerializeField] private Sprite sadBird;

    [SerializeField] private Animator transition;
    [SerializeField] private GameObject sceneTransitionObject;

    [SerializeField] private GameObject birdSceneAnimation;
    [SerializeField] private GameObject hud;

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
            
            birdObject.SetActive(true);

            StartCoroutine(StartBirdScene());
        }
    }

    private IEnumerator StartBirdScene()
    {
        yield return new WaitForSeconds(1.1f);
        birdObject.GetComponent<SpriteRenderer>().sprite = sadBird;
        
        yield return new WaitForSeconds(0.5f);
        transition.SetTrigger("in");

        yield return new WaitForSeconds(2);
        hud.SetActive(false);

        yield return new WaitForSeconds(2);
        birdSceneAnimation.SetActive(true);
        transition.SetTrigger("out");

        yield return new WaitForSeconds(15);
        transition.SetTrigger("in");

        yield return new WaitForSeconds(2);
        birdSceneAnimation.SetActive(false);
        hud.SetActive(true);
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        birdObject.SetActive(false);
        birdObjectTwo.SetActive(true);

        yield return new WaitForSeconds(2);
        transition.SetTrigger("out");
        yield return new WaitForSeconds(2);

        playerMovement.canMove = true;

        yield return new WaitForSeconds(5);
        transition.SetTrigger("in");
        yield return new WaitForSeconds(4);
        SceneManager.LoadSceneAsync(3);
    }
}
