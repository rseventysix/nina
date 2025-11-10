using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class demoEndTrigger : MonoBehaviour
{
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
        if (collider.CompareTag("Player"))
        {
            StartCoroutine(DemoEndTransition());
        }
    }

    private IEnumerator DemoEndTransition()
    {
        transition.SetTrigger("in");
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(3);
    }
}
