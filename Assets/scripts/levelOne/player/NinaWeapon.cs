using UnityEngine;

public class NinaWeapon : MonoBehaviour
{
    [SerializeField] private GameObject courageBubblePrefab;
    [SerializeField] private Transform firePoint;
    private Movement playerMovement;

    private float fireRate = 1f;
    private float nextFireTime = 0f;

    public bool canShoot;

    [SerializeField] Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canShoot = true;
        
        playerMovement = GetComponentInParent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
            {
                animator.SetBool("isShooting", true);
                
                nextFireTime = Time.time + fireRate;
            
                CourageBubbleShoot();
            }

            else {animator.SetBool("isShooting", false);}
        }
    }

    private void CourageBubbleShoot()
    {
        GameObject projectile = 
        Instantiate(courageBubblePrefab, firePoint.position, firePoint.rotation);
        
        Vector2 direction = playerMovement.isFacingRight ? Vector2.right : Vector2.left;

        CourageBubbleProjectile projectileScript = 
        projectile.GetComponent<CourageBubbleProjectile>();

        projectileScript.Launch(direction);
    }
}
