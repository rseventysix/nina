using UnityEngine;

public class NinaWeapon : MonoBehaviour
{
    [SerializeField] private GameObject courageBubblePrefab;
    [SerializeField] private GameObject friendshipBubblePrefab;
    
    [SerializeField] private Transform firePoint;
    private Movement playerMovement;

    private float fireRate = 1f;
    private float nextFireTime = 0f;

    public bool canShoot;

    [SerializeField] Animator animator;

    public bool courageBubble;
    public bool friendshipBubble;

    public bool changeBubble;

    [SerializeField] private GameObject hudBubblesSelect;
    [SerializeField] private Sprite yellowAndRedBubblesSelect;
    [SerializeField] private Sprite redAndYellowBubblesSelect;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canShoot = false;
        
        playerMovement = GetComponentInParent<Movement>();

        courageBubble = false;

        friendshipBubble = false;

        changeBubble = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && changeBubble)
        {
            if (courageBubble)
            {
                friendshipBubble = true;
                courageBubble = false;
            }

            else if (friendshipBubble)
            {
                courageBubble = true;
                friendshipBubble = false;
            }
        }

        if (courageBubble && changeBubble)
        {
            hudBubblesSelect.GetComponent<UnityEngine.UI.Image>().sprite 
            = yellowAndRedBubblesSelect;
        }

        if (friendshipBubble)
        {
            hudBubblesSelect.GetComponent<UnityEngine.UI.Image>().sprite 
            = redAndYellowBubblesSelect;
        }
        
        if (canShoot)
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
            {
                animator.SetBool("isShooting", true);
                
                if (courageBubble)
                {
                    CourageBubbleShoot();

                    nextFireTime = Time.time + fireRate;
                }

                else if (friendshipBubble)
                {
                    FriendshipBubbleShoot();

                    nextFireTime = Time.time + fireRate;
                }
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

    private void FriendshipBubbleShoot()
    {
        GameObject projectile = 
        Instantiate(friendshipBubblePrefab, firePoint.position, firePoint.rotation);
        
        Vector2 direction = playerMovement.isFacingRight ? Vector2.right : Vector2.left;

        FriendshipBubbleProjectile projectileScript = 
        projectile.GetComponent<FriendshipBubbleProjectile>();

        projectileScript.Launch(direction);
    }
}
