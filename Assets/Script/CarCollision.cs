using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CarCollision : MonoBehaviour
{
    public GameObject explosionPrefab;  // Reference to the explosion prefab
    public float explosionDuration = 3f;  // Duration to wait before reloading the scene

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the police car
        if (collision.gameObject.CompareTag("Police"))
        {
            // Instantiate the explosion at the car's position and rotation
            Instantiate(explosionPrefab, transform.position, transform.rotation);

            // Start the coroutine to handle the delay before reloading the scene
            StartCoroutine(HandleExplosion());
        }
    }

    private IEnumerator HandleExplosion()
    {
        // Disable the player's car to stop any further interactions
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        // Wait for the explosion duration
        yield return new WaitForSeconds(explosionDuration);

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
