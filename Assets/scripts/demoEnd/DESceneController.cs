using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DESceneController : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private GameObject sceneTransitionObject;
    [SerializeField] private GameObject creditsObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneTransitionObject.SetActive(true);

        transition.SetTrigger("out");

        StartCoroutine(backToMainMenu());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator backToMainMenu()
    {
        yield return new WaitForSeconds(2);

        creditsObject.SetActive(true);

        yield return new WaitForSeconds(35);

        transition.SetTrigger("in");

        yield return new WaitForSeconds(2);

        SceneManager.LoadSceneAsync(0);
    }
}
