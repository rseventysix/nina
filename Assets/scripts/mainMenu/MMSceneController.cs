using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;   

public class MenuController : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private GameObject sceneTransitionObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneTransitionObject.SetActive(true);
        transition.SetTrigger("out");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }

    public void PlayGame()
    {
        StartCoroutine(sceneTransition());
    }

    private IEnumerator sceneTransition()
    {
        transition.SetTrigger("in");
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(1);
    }
}
