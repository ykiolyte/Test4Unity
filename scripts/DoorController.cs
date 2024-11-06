using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false; // Статус ворот: открыты или закрыты

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Проверка нажатия клавиши Enter
        {
            ToggleDoor();
        }
    }

    private void ToggleDoor()
    {
        isOpen = !isOpen;
        animator.SetTrigger("ToggleDoor"); // Активируем триггер в аниматоре
    }
}
