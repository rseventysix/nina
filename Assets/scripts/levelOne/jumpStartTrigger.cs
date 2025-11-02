using UnityEngine;

public class jumpStartTrigger : MonoBehaviour
{
    [SerializeField] private GameObject jumpKeyAnimationObject;
    
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
            jumpKeyAnimationObject.SetActive(true);
        }
    }
}
