using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public float pickupRange = 2f;       // Дистанция для взаимодействия
    private GameObject heldObject;       // Текущий удерживаемый объект
    public Transform holdPosition;       // Позиция для удержания предмета перед игроком
    public AudioSource pickupSound;      // Звук для подбора предмета
    public AudioSource dropSound;        // Звук для выброса предмета

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                TryPickUpObject();       // Попытка поднять предмет
            }
            else
            {
                DropObject();            // Сброс предмета
            }
        }
    }

    private void TryPickUpObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, pickupRange))
        {
            if (hit.collider.CompareTag("Pickupable")) // Проверяем, имеет ли объект тег "Pickupable"
            {
                heldObject = hit.collider.gameObject;  // Запоминаем объект
                var rb = heldObject.GetComponent<Rigidbody>();
                
                if (rb != null)
                {
                    rb.isKinematic = true;            // Отключаем физику для удерживаемого объекта
                }

                // Перемещаем объект в позицию удержания
                heldObject.transform.position = holdPosition.position;
                heldObject.transform.parent = holdPosition; // Привязываем объект к позиции удержания

                // Воспроизводим звук подбора
                if (pickupSound != null)
                {
                    pickupSound.Play();
                }
            }
        }
    }

    private void DropObject()
    {
        if (heldObject != null)
        {
            var rb = heldObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;               // Включаем физику обратно
            }

            heldObject.transform.parent = null;       // Убираем привязку к позиции удержания
            heldObject = null;                        // Освобождаем объект

            // Воспроизводим звук выброса
            if (dropSound != null)
            {
                dropSound.Play();
            }
        }
    }
}
