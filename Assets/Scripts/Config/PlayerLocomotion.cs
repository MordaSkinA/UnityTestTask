using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    [SerializeField] float forwardSpeed = 5f;
    [SerializeField] float horizontalSensetivity = 5f;
    [SerializeField] TrackBounds bounds;

    public float HorizontalInput { get; set; }

    void Update()
    {
        float dt =  Time.deltaTime;
        transform.position += transform.forward * forwardSpeed * dt;
        
        float x = transform.position.x + HorizontalInput * dt * horizontalSensetivity;
        if (bounds != null)
        {
            x = Mathf.Clamp(x, bounds.minX, bounds.maxX);
        }
        
        var pos = transform.position;
        pos.x = x;
        transform.position = pos;
    }
}