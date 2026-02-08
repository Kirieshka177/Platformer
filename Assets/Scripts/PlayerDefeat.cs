
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDefeat : MonoBehaviour
{
    [SerializeField] private GameObject SpawnPoint;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Transform SpawnpointTransform = SpawnPoint.transform;

        float yPos = collision.transform.position.y;
        float playeryPos = transform.position.y;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            string z = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(z);
        }
    }
}
