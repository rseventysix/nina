using UnityEngine;

public class NinaWeapon : MonoBehaviour
{
    [SerializeField] private GameObject courageBubblePrefab;
    [SerializeField] private Transform firePoint;
    private Movement playerMovement;

    private float fireRate = 1f;
    private float nextFireTime = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = GetComponentInParent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            
            CourageBubbleShoot();
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
