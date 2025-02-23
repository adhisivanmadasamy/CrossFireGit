using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    float timer = 0f;
    [SerializeField] float BulletSpeed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(this.gameObject.transform.forward * BulletSpeed);
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 5f)
        {
            Destroy(gameObject);
        }
    }
}
