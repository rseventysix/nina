using UnityEngine;
using System.Collections;

public class LOSceneController : MonoBehaviour
{
    [SerializeField] private Animator transition;

    [SerializeField] private GameObject sceneTransitionObject;

    [SerializeField] private GameObject arrowKeysAnimationObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneTransitionObject.SetActive(true);
        
        transition.SetTrigger("out");

        StartCoroutine(ArrowsTutorial());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ArrowsTutorial()
    {
        yield return new WaitForSeconds(2);
        arrowKeysAnimationObject.SetActive(true);
    }
}
