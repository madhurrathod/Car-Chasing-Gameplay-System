using UnityEngine;

public class CarSound : MonoBehaviour
{
    public AudioSource engineIdleSource;   // AudioSource for engine idle sound
    public AudioSource engineAccelSource;  // AudioSource for engine acceleration sound
    public AudioSource brakeSource;        // AudioSource for braking sound
    public float accelerationThreshold = 0.1f;  // Threshold to switch between idle and acceleration sounds

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Start playing the idle sound loop
        if (engineIdleSource != null)
        {
            engineIdleSource.Play();
        }
    }

    void Update()
    {
        // Check if the car is accelerating
        float currentVelocity = rb.velocity.magnitude;
        if (currentVelocity > accelerationThreshold)
        {
            if (engineAccelSource != null && !engineAccelSource.isPlaying)
            {
                // Stop the idle sound and play the acceleration sound
                if (engineIdleSource != null)
                {
                    engineIdleSource.Stop();
                }
                engineAccelSource.Play();
            }
        }
        else
        {
            if (engineIdleSource != null && !engineIdleSource.isPlaying)
            {
                // Stop the acceleration sound and play the idle sound
                if (engineAccelSource != null)
                {
                    engineAccelSource.Stop();
                }
                engineIdleSource.Play();
            }
        }
    }

    public void PlayBrakeSound()
    {
        if (brakeSource != null)
        {
            brakeSource.Play();
        }
    }
}
