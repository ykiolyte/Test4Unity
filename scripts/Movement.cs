using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость передвижения

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // Получаем значение по оси X (A и D)
        float moveZ = Input.GetAxis("Vertical");   // Получаем значение по оси Z (W и S)

        Vector3 move = transform.right * moveX + transform.forward * moveZ; // Рассчитываем направление движения
        transform.position += move * moveSpeed * Time.deltaTime; // Перемещаем игрока
    }
}
