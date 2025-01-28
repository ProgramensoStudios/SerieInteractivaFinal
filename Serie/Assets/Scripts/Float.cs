using UnityEngine;

public class Float : MonoBehaviour
{
    public float floatAmplitude = 0.5f;  
    public float floatFrequency = 1f;    
    public bool useGravity;     

    private Vector3 startPos;         
    private Rigidbody rb;

    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No se encontró un Rigidbody en el GameObject.");
        }
    }

    void Update()
    {
        switch (useGravity)
        {
            case true:
                rb.useGravity = true;
                rb.isKinematic = false;
                break;
            case false: Floating();
                break;
        }
    }

    void Floating()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}