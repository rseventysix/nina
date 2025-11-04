using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DESceneController : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private GameObject sceneTransitionObject;

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
        yield return new WaitForSeconds(17);

        transition.SetTrigger("in");
        yield return new WaitForSeconds(4);

        SceneManager.LoadSceneAsync(0);
    }
}
