using UnityEngine;
using System.Collections;

public class catsSceneTrigger : MonoBehaviour
{
    [SerializeField] private GameObject catOneObject;
    [SerializeField] private GameObject catTwoObject;

    private Movement playerMovement;

    [SerializeField] private GameObject changeBubbleKeyAnimationObject;

    private NinaWeapon playerWeapon;

    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject wallTwo;

    public bool challengeStart;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        challengeStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (changeBubbleKeyAnimationObject.activeSelf)
        {
            if (Input.GetButtonDown("Fire2"))
            {   
                changeBubbleKeyAnimationObject.
                GetComponent<Animator>().SetTrigger("changeBubbleTutorialEnd");

                StartCoroutine(StartCatsChallenge());
            }
        }

        if (challengeStart)
        {
            if (!catOneObject.GetComponent<CatsController>().canThrow &&
            !catTwoObject.GetComponent<CatsController>().canThrow)
            {
                wall.SetActive(false);
                wallTwo.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerMovement = collider.GetComponent<Movement>();
            playerWeapon = collider.GetComponent<NinaWeapon>();
            
            playerMovement.canMove = false;
            playerWeapon.canShoot = false;

            wall.SetActive(true);
            wallTwo.SetActive(true);
            
            catTwoObject.SetActive(true);

            StartCoroutine(StartChangeBubbletutorial());
        }
    }

    private IEnumerator StartChangeBubbletutorial()
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        
        yield return new WaitForSeconds(2.5f);

        catTwoObject.GetComponent<Animator>().SetTrigger("idle");

        playerWeapon.changeBubble = true;
        
        changeBubbleKeyAnimationObject.SetActive(true);
        yield return new WaitForSeconds(1);
        
        playerMovement.canMove = true;
        playerWeapon.canShoot = true;
    }

    private IEnumerator StartCatsChallenge()
    {
        yield return new WaitForSeconds(1);

        changeBubbleKeyAnimationObject.SetActive(false);

        catOneObject.GetComponent<CatsController>().canThrow = true;
        catTwoObject.GetComponent<CatsController>().canThrow = true;

        challengeStart = true;
    }
}
