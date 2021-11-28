using UnityEngine;

public class Target : MonoBehaviour
{
    Rigidbody rb;

    static GameManager gm;

    public int pointvalue;

    public ParticleSystem explosionpar;

    void Start()
    {
        if (!gm)
            gm = GameObject.Find("Game Manager").GetComponent<GameManager>();

        rb = GetComponent<Rigidbody>();

        rb.AddForce(rand_Vect(), ForceMode.Impulse);

        rb.AddTorque(rand_tor(),rand_tor(),rand_tor(),ForceMode.Impulse);

        transform.position = new Vector3(Random.Range(-4, 4), -2);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!gameObject.CompareTag("Bad"))
        {
            gm.gameOver();  
        }
            Destroy(gameObject);
    }

    float rand_tor()
    {
        return Random.Range(-10, 10);
    }

    Vector3 rand_Vect()
    {
        return Vector3.up * Random.Range(12, 16);
    }

}
