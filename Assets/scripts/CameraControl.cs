using UnityEngine;
 
public class CameraControl : MonoBehaviour {
   public float CameraSpeed = 100.0f; //Скорость движения камеры
   public float CameraSpeedBoostMultiplier = 2.0f; //Множитель ускорения движения камеры при зажатом Shift
 
   //Задаём позицию по умолчанию для камеры, здесь выставлена моя - меняйте под себя
   public float DefaultCameraPosX = 256.0f;
   public float DefaultCameraPosY = 138.0f;
   public float DefaultCameraPosZ = 122.0f;
 
   private void Awake() {
      //Задаём позицию по умолчанию для камеры, используя ранее указанные координаты
      transform.position = new Vector3(DefaultCameraPosX, DefaultCameraPosY, DefaultCameraPosZ);
   }
 
   private void Update() {
      float smoothCamSpeed = CameraSpeed * Time.smoothDeltaTime; //множим скорость перемещения камеры на сглаженную версию Time.deltaTime
 
      //При нажатии какой-либо из кнопки из WASD происходит перемещение в соответствующую сторону, нажания сразу двух кнопок также обрабатываются (WA будет двигать камеру вверх и влево), зажатие Shift при этом ускоряет передвижение.
      if (Input.GetKey(KeyCode.W)) transform.position += Input.GetKey(KeyCode.LeftShift) ? new Vector3(0.0f, 0.0f, smoothCamSpeed * CameraSpeedBoostMultiplier) : new Vector3(0.0f, 0.0f, smoothCamSpeed); //вверх
      if (Input.GetKey(KeyCode.A)) transform.position += Input.GetKey(KeyCode.LeftShift) ? new Vector3(-smoothCamSpeed * CameraSpeedBoostMultiplier, 0.0f, 0.0f) : new Vector3(-smoothCamSpeed, 0.0f, 0.0f); //налево
      if (Input.GetKey(KeyCode.S)) transform.position += Input.GetKey(KeyCode.LeftShift) ? new Vector3(0.0f, 0.0f, -smoothCamSpeed * CameraSpeedBoostMultiplier) : new Vector3(0.0f, 0.0f, -smoothCamSpeed); //вниз
      if (Input.GetKey(KeyCode.D)) transform.position += Input.GetKey(KeyCode.LeftShift) ? new Vector3(smoothCamSpeed * CameraSpeedBoostMultiplier, 0.0f, 0.0f) : new Vector3(smoothCamSpeed, 0.0f, 0.0f); //направо
   }
}
