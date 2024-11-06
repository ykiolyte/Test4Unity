using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Чувствительность мыши
    private Transform playerBody; // Ссылка на объект тела игрока

    private float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Скрываем курсор и фиксируем его в центре экрана
        playerBody = transform.parent; // Предполагаем, что камера — дочерний объект игрока
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Регулируем угол поворота камеры по вертикали
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Ограничиваем угол наклона камеры

        // Устанавливаем поворот камеры по оси X (вверх-вниз)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Вращаем игрока по оси Y (влево-вправо)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
