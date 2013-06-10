using UnityEngine;
using System.Collections.Generic;

public class MobAI : MonoBehaviour {

   public GameObject Target; //текущая цель

   public float mobPrice = 5.0f; //цена за убийство моба
   public float mobMinSpeed = 0.5f; //минимальная скорость моба
   public float mobMaxSpeed = 2.0f; //максимальная скорость моба
   public float mobRotationSpeed = 2.5f; //скорость поворота моба
   public float attackDistance = 5.0f; //дистанция атаки
   public float damage = 5; //урон, наносимый мобом
   public float attackTimer = 0.0f; //переменная расчета задержки между ударами
   public const float coolDown = 2.0f; //константа, используется для сброса таймера атаки в начальное значение

   private float MobCurrentSpeed; //скорость моба, инициализируем позже
   private Transform mob; //переменная для трансформа моба
   private GlobalVars gv; //поле для объекта глобальных переменных

   private void Awake() {
      gv = GameObject.Find("GlobalVars").GetComponent<GlobalVars>(); //инициализируем поле
      mob = transform; //присваиваем трансформ моба в переменную (повышает производительность)
      MobCurrentSpeed = Random.Range(mobMinSpeed, mobMaxSpeed); //посредством рандома выбираем скорость между минимально и максимально указанной
   }

   private void Update() {
      if (Target != null) {
         mob.rotation = Quaternion.Lerp(mob.rotation, Quaternion.LookRotation(new Vector3(Target.transform.position.x, 0.0f, Target.transform.position.z) - new Vector3(mob.position.x, 0.0f, mob.position.z)), mobRotationSpeed);
         mob.position += mob.forward * MobCurrentSpeed * Time.deltaTime;
         float squaredDistance = (Target.transform.position - mob.position).sqrMagnitude; //меряем дистанцию до цели
         Vector3 structDirection = (Target.transform.position - mob.position).normalized;
         float attackDirection = Vector3.Dot(structDirection, mob.forward);
         if (squaredDistance < attackDistance * attackDistance && attackDirection > 0) {
            if (attackTimer > 0) attackTimer -= Time.deltaTime;
            if (attackTimer <= 0) {
               BaseHP bhp = Target.GetComponent<BaseHP>(); //подключаемся к компоненту HP цели
               if (bhp != null)
					bhp.ChangeHP(-damage); // отнимаем от её HP наш урон
               attackTimer = coolDown;
            }
         }
      }
      else {
         GameObject baseGO = GameObject.FindGameObjectWithTag("Base"); //находим наш объект с базой, он всего один
         if (baseGO != null)
			 Target = baseGO; //если она существует - делаем её целью для моба.
      }
   }

   //Очень примитивный метод сортировки целей, море возможностей для модификации!
   private GameObject SortTargets() {
      float closestTurretDistance = 0; //инициализация переменной для проверки дистанции до пушки
      GameObject nearestTurret = null; //инициализация переменной ближайшей пушки
      List<GameObject> sortingTurrets = gv.TurretList; //создаём массив для сортировки

      foreach (var turret in sortingTurrets) //для каждой пушки в массиве
      {
         //если дистанция до пушки меньше, чем closestTurretDistance или равна нулю
         if ((Vector3.Distance(mob.position, turret.transform.position) < closestTurretDistance) || closestTurretDistance == 0)
         {
            closestTurretDistance = Vector3.Distance(mob.position, turret.transform.position); //Меряем дистанцию от моба до пушки, записываем её в переменную
            nearestTurret = turret;//устанавливаем её как ближайшего
         }
      }
      return nearestTurret; //возвращаем ближайший ствол
   }
}
