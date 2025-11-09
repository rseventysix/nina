using UnityEngine;

public class CatsController : MonoBehaviour
{   
    [SerializeField] private GameObject[] objectsToThrow;
    [SerializeField] private Transform firePoint;

    private float throwRate = 3f;
    private float nextThrowTime = 0f;

    private Vector2 direction;

    [SerializeField] private Animator animator;

    public bool canThrow;

    public int catEndurance = 3;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = firePoint.right;
        canThrow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextThrowTime && canThrow)
        {
            ThrowRandomObject();
            nextThrowTime = Time.time + throwRate;
        }

        if (catEndurance == 0)
        {
            canThrow = false;
            animator.SetTrigger("calm");
        }
    }

    private void ThrowRandomObject()
    {
        int randomIndex = Random.Range(0, objectsToThrow.Length);

        GameObject selectedObjectPrefab = objectsToThrow[randomIndex];

        animator.SetTrigger("angry");
        
        GameObject thrownObject = 
        Instantiate(selectedObjectPrefab, firePoint.position, firePoint.rotation);

        ObjectsProjectile thrownObjectScript =
        thrownObject.GetComponent<ObjectsProjectile>();

        thrownObjectScript.Launch(direction);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("friendshipBubble"))
        {
            catEndurance -= 1;
        }
    }
}
