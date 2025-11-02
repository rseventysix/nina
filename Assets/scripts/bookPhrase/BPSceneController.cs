using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BPSceneController : MonoBehaviour
{
    [SerializeField] private Animator transition;

    [SerializeField] private GameObject sceneTransitionObject;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneTransitionObject.SetActive(true);
        
        StartCoroutine(LoadNextSceneAfterDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LoadNextSceneAfterDelay()
    {
        transition.SetTrigger("out");
        yield return new WaitForSeconds(2);

        yield return new WaitForSeconds(5);

        transition.SetTrigger("in");
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(2);
    }
}
