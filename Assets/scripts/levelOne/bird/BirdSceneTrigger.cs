using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BirdSceneTrigger : MonoBehaviour
{
    [SerializeField] private GameObject birdObject;
    [SerializeField] private GameObject birdObjectTwo;
    [SerializeField] private Sprite fallenBird;
    [SerializeField] private Sprite sadBird;

    [SerializeField] private GameObject comicTransitionObject;

    [SerializeField] private GameObject birdSceneAnimation;

    [SerializeField] private GameObject shootKeyAnimationObject;

    private Movement playerMovement;

    private NinaWeapon ninaWeapon;

    [SerializeField] private GameObject hudBubblesSelect;
    [SerializeField] private Sprite yellowBubblesSelect;
    
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

            ninaWeapon = collider.GetComponent<NinaWeapon>();

            playerMovement.canMove = false;
            
            birdObject.SetActive(true);

            StartCoroutine(StartBirdScene());
        }
    }

    private IEnumerator StartBirdScene()
    {
        yield return new WaitForSeconds(1.1f);
        birdObject.GetComponent<SpriteRenderer>().sprite = fallenBird;

        yield return new WaitForSeconds(1.1f);
        birdObject.GetComponent<SpriteRenderer>().sprite = sadBird;
        
        yield return new WaitForSeconds(0.5f);
        comicTransitionObject.SetActive(true);

        yield return new WaitForSeconds(4);
        birdSceneAnimation.SetActive(true);

        yield return new WaitForSeconds(20.5f);

        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        birdSceneAnimation.SetActive(false);
        hudBubblesSelect.GetComponent<UnityEngine.UI.Image>().sprite = yellowBubblesSelect;
        birdObject.SetActive(false);
        birdObjectTwo.SetActive(true);

        yield return new WaitForSeconds(2);

        comicTransitionObject.GetComponent<Animator>().SetTrigger("out");
        yield return new WaitForSeconds(2);

        comicTransitionObject.SetActive(false);

        playerMovement.canMove = true;

        shootKeyAnimationObject.SetActive(true);
        ninaWeapon.canShoot = true;
        ninaWeapon.courageBubble = true;
    }
}
