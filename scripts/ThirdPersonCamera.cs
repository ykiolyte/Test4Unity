using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // Целевой объект, за которым следует камера
    public float distance = 5.0f; // Расстояние от камеры до объекта
    public float height = 2.0f; // Базовая высота камеры относительно объекта
    public float rotationSpeed = 5.0f; // Скорость вращения камеры
    public float smoothSpeed = 0.125f; // Скорость плавного следования камеры
    public float minVerticalAngle = -30f; // Минимальный угол по вертикали
    public float maxVerticalAngle = 60f; // Максимальный угол по вертикали

    private float currentRotationY;
    private float currentRotationX;

    void Start()
    {
        // Инициализация вращения
        currentRotationY = transform.eulerAngles.y;
        currentRotationX = transform.eulerAngles.x;
        Cursor.lockState = CursorLockMode.Locked; // Скрываем курсор и фиксируем его в центре экрана
    }

    void LateUpdate()
    {
        // Получение ввода мыши для вращения камеры
        float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed;
        float verticalInput = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Обновление углов вращения
        currentRotationY += horizontalInput;
        currentRotationX -= verticalInput; // Отрицательное значение, чтобы камера двигалась в нужном направлении
        currentRotationX = Mathf.Clamp(currentRotationX, minVerticalAngle, maxVerticalAngle); // Ограничение угла по вертикали

        // Применяем поворот камеры вокруг объекта с учетом ограничений
        Quaternion rotation = Quaternion.Euler(currentRotationX, currentRotationY, 0);
        Vector3 offset = rotation * new Vector3(0, height, -distance);

        // Целевая позиция камеры
        Vector3 desiredPosition = target.position + offset;

        // Плавное движение камеры к целевой позиции
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Поворот камеры, чтобы смотреть на объект
        transform.LookAt(target.position + Vector3.up * height);

        // Вращение объекта (игрока) в направлении камеры по оси Y
        Vector3 targetRotation = new Vector3(0, currentRotationY, 0);
        target.rotation = Quaternion.Lerp(target.rotation, Quaternion.Euler(targetRotation), smoothSpeed);
    }
}
