using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    private Vector3 direction;

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    
    public void SetDirection(Vector3 direction)
    {
        this.direction = direction.normalized;
    }
}