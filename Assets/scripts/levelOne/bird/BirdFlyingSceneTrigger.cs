using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BirdFlyingSceneTrigger : MonoBehaviour
{
    [SerializeField] private GameObject shootKeyAnimationObject;

    [SerializeField] private Sprite birdSurprised;

    [SerializeField] private Animator transition;
    
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
        if (collider.CompareTag("courageBubble"))
        {
            shootKeyAnimationObject.GetComponent<Animator>().SetTrigger("shootTutorialEnd");

            StartCoroutine(shootKeyAnimationDisable());
        }
    }

    private IEnumerator shootKeyAnimationDisable()
    {
        yield return new WaitForSeconds(1);
        shootKeyAnimationObject.SetActive(false);

        GetComponentInParent<SpriteRenderer>().sprite = birdSurprised;

        yield return new WaitForSeconds(1);

        GetComponentInParent<Animator>().enabled = true;

        yield return new WaitForSeconds(10);
        transition.SetTrigger("in");
        yield return new WaitForSeconds(4);
        SceneManager.LoadSceneAsync(3);
    }
}
