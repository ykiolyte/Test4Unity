using UnityEngine;

public class DoorAutoOpen : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("DoorOpen"); // Запускаем анимацию открытия при старте сцены
    }
}
