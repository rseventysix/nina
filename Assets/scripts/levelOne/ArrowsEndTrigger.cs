using UnityEngine;
using System.Collections;

public class ArrowsEndTrigger : MonoBehaviour
{
    [SerializeField] private GameObject arrowKeysAnimationObject;
    
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
            arrowKeysAnimationObject.GetComponent<Animator>().SetTrigger("arrowsTutorialEnd");

            StartCoroutine(arrowKeysAnimationDisable());
        }
    }

    private IEnumerator arrowKeysAnimationDisable()
    {
        yield return new WaitForSeconds(1);
        arrowKeysAnimationObject.SetActive(false);
    }
}
