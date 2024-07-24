using UnityEngine;

public class PoliceChase : MonoBehaviour
{
    public Transform player;  // Reference to the player's car
    public float speed = 10f;  // Speed of the police car
    public float stoppingDistance = 5f;  // Distance at which the police car stops chasing
    public Collider chaseRegion;  // Reference to the chase region collider

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Check if the player is within the chase region
        if (chaseRegion.bounds.Contains(player.position))
        {
            // Calculate the distance between the police car and the player's car
            float distance = Vector3.Distance(transform.position, player.position);

            // If the distance is greater than the stopping distance, move the police car towards the player
            if (distance > stoppingDistance)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                Vector3 move = direction * speed * Time.fixedDeltaTime;
                rb.MovePosition(rb.position + move);

                // Rotate police car to face the player
                Quaternion toRotation = Quaternion.LookRotation(direction);
                rb.MoveRotation(Quaternion.Lerp(transform.rotation, toRotation, Time.fixedDeltaTime * speed));
            }
        }
    }
}
