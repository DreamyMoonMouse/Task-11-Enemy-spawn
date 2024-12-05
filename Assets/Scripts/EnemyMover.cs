using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    
    private Vector3 _direction;

    private void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }
    
    public void SetDirection(Vector3 direction)
    {
        _direction = direction.normalized;
    }
}