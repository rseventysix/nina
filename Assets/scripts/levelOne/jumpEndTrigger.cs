using UnityEngine;
using System.Collections;

public class JumpEndTrigger : MonoBehaviour
{
    [SerializeField] private GameObject jumpKeyAnimationObject;
    [SerializeField] private GameObject jumpStartTriggerObject;

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
            jumpKeyAnimationObject.GetComponent<Animator>().SetTrigger("jumpTutorialEnd");

            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;

            StartCoroutine(jumpKeyAnimationDisable());

            jumpStartTriggerObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private IEnumerator jumpKeyAnimationDisable()
    {
        yield return new WaitForSeconds(1);
        jumpKeyAnimationObject.SetActive(false);
    }
}
