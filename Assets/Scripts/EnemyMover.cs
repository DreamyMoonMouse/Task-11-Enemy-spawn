using UnityEngine;
using UnityEngine.Serialization;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    
    private Vector3 direction;

    private void Update()
    {
        transform.position += direction * _speed * Time.deltaTime;
    }
    
    public void SetDirection(Vector3 direction)
    {
        this.direction = direction.normalized;
    }
}