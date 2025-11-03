using UnityEngine;

public class DESceneController : MonoBehaviour
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
        
    }
}
