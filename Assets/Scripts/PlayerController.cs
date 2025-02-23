using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Singleton
    public static PlayerController instance { get; set; }

    //Input Actions
    public PlayerIA playerIA;
    private InputAction Aim;
    private InputAction Fire;

    //Input Value Public
    public float aimVal;


    //Shoot
    [SerializeField] Transform BulletSpawn;
    [SerializeField] GameObject BulletPrefab;
    float shotTimer = 0f;
    bool shotReady = true;

    //Ragdoll
    Animator playerAnimator;

    private void Awake()
    {
        if(instance != null && instance!=this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        playerIA = new PlayerIA();
    }
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        aimVal = Aim.ReadValue<float>();  
        
        if(!shotReady)
        {
            shotTimer += Time.deltaTime;
            if(shotTimer > 5f)
            {
                shotReady = true;
                shotTimer = 0f;
            }
        }

    }

    private void OnEnable()
    {
        
        Aim = playerIA.Player.Aim;
        Aim.Enable();

        Fire = playerIA.Player.Fire;
        Fire.Enable();
        Fire.performed += FireFunc;
    }
    private void OnDisable()
    {
        
        Aim.Disable();
        Fire.Disable();
    }

    private void FireFunc(InputAction.CallbackContext context)
    {
        if(shotReady)
        {
            Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.rotation);
            shotReady = false;
        }
            
    }

    void RagAnimSwitch(bool ragNow)
    {
        if(ragNow)
        {
            playerAnimator.enabled = true;
        }
        else
        {
            playerAnimator.enabled = false;
        }
    }
}
