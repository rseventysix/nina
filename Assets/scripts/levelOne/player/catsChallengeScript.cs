using UnityEngine;
using System.Collections;

public class catsChallengeScript : MonoBehaviour
{
    private int ninaEndurance = 4;

    [SerializeField] private GameObject ninaLife;
    [SerializeField] private Sprite[] ninaLifeChange;

    private int lifeSpriteIndex = 0;

    [SerializeField] private GameObject catsSceneTriggerObject;

    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject wallTwo;

    [SerializeField] private GameObject catOneObject;
    [SerializeField] private GameObject catTwoObject;

    [SerializeField] private Sprite catOneIdle;
    [SerializeField] private Sprite catTwoIdle;

    [SerializeField] private GameObject hudBubblesSelect;
    [SerializeField] private Sprite yellowBubblesSelect;

    [SerializeField] private Animator transition;

    private bool respawn = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ninaEndurance == 0 && !respawn)
        {
            respawn = true;
            StartCoroutine(RespawnTransition());
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("objects"))
        {
            ninaEndurance -= 1;
            lifeSpriteIndex += 1;
            
            ninaLife.GetComponent<UnityEngine.UI.Image>().sprite 
            = ninaLifeChange[lifeSpriteIndex];

            Destroy(collider.gameObject);
        }
    }

    private void RespawnNina()
    {
        this.transform.position = new Vector2(274.2f, 2.2f);
            
        ninaLife.GetComponent<UnityEngine.UI.Image>().sprite 
        = ninaLifeChange[0];
        lifeSpriteIndex = 0;

        catsSceneTriggerObject.GetComponent<catsSceneTrigger>().challengeStart = false;
            
        catTwoObject.GetComponent<CatsController>().canThrow = false;
        catTwoObject.GetComponent<CatsController>().catEndurance = 3;
        catTwoObject.GetComponent<SpriteRenderer>().sprite = catTwoIdle;
        catTwoObject.SetActive(false);
            
        wall.SetActive(false);
        wallTwo.SetActive(false);

        catsSceneTriggerObject.GetComponent<BoxCollider2D>().enabled = true;

        catOneObject.GetComponent<CatsController>().canThrow = false;
        catOneObject.GetComponent<CatsController>().catEndurance = 3;
        catOneObject.SetActive(false);
        catOneObject.SetActive(true);

        this.GetComponent<NinaWeapon>().changeBubble = false;
        this.GetComponent<NinaWeapon>().courageBubble = true;
        this.GetComponent<NinaWeapon>().friendshipBubble = false;
        hudBubblesSelect.GetComponent<UnityEngine.UI.Image>().sprite = yellowBubblesSelect;
    }

    private IEnumerator RespawnTransition()
    {
        this.GetComponent<Movement>().canMove = false;
        this.GetComponent<NinaWeapon>().canShoot = false;
        
        transition.SetTrigger("in");
        yield return new WaitForSeconds(2);

        RespawnNina();
        ninaEndurance = 4;

        transition.SetTrigger("out");
        yield return new WaitForSeconds(2);

        this.GetComponent<Movement>().canMove = true;
        this.GetComponent<NinaWeapon>().canShoot = true;

        respawn = false;
    }
}
