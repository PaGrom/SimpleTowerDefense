using UnityEngine;
 
public class BaseHP : MonoBehaviour {
   public float maxHP = 1000;
   public float curHP = 1000;
   public float regenerationDelayConstant = 2.5f; //константа задержки между регенерацией хп базы
   public float regenarationDelayVariable = 2.5f; //переменная той же задержки
   public float regenerationAmount = 10.0f; //количество восстанавливаемого хп при регенерации за раз
 
   private void Awake() {
      if (maxHP < 1)
		 maxHP = 1;
   }
 
   public void ChangeHP(float adjust) {
      if ((curHP + adjust) > maxHP)
		 curHP = maxHP;
      else
		 curHP += adjust;
      if (curHP > maxHP)
		 curHP = maxHP; //just in case
   }
 
   private void Update() {
      if (curHP <= 0) {
         Destroy(gameObject);
      }
      else {
         if (regenarationDelayVariable > 0)
			 regenarationDelayVariable -= Time.deltaTime; //если переменная задержки более нуля - отнимаем от неё единицу в секунду
         if (regenarationDelayVariable <= 0) { //если она стала меньше или равна нулю
            ChangeHP(regenerationAmount); //восстанавливаем ранее указанное количество ХП
            regenarationDelayVariable = regenerationDelayConstant; //и возвращаем нашу переменную в её первоначальное значение
         }
      }
   }
	
	private void OnGUI() {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position); //Находим позицию объекта на экране относительно мира
        Vector3 cameraRelative = Camera.main.transform.InverseTransformPoint(transform.position); //Получаем дальность объекта от камеры
        if (cameraRelative.z > 0) { //если объект находится впереди камеры
            string HPString = curHP + "/" + maxHP;
            GUI.Label(new Rect(screenPosition.x, Screen.height - screenPosition.y, 250f, 20f), HPString);
        }
    }
}
