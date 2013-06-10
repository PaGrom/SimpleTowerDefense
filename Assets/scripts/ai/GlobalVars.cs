using System.Collections.Generic;
using UnityEngine;

public static class GlobalVars {
    public static List<GameObject> MobList = new List<GameObject>(); //массив мобов в игре
    public static int MobCount = 0; //счетчик мобов в игре

    public static List<GameObject> TurretList = new List<GameObject>(); //массив пушек в игре
    public static int TurretCount = 0; //счетчик пушек в игре

    public static float PlayerMoney = 200.0f; //при старте игры, если нету сохранённых данных про деньги игрока - их становится 200$, иначе загружается из памяти

    public static ClickState mau5tate = ClickState.Default; //дефолтное состояние курсора

    public enum ClickState { //перечисление всех состояний курсора
        Default, //обычное
        Placing, //устанавливаем пушку
        Selling, //продаём пушку
        Upgrading //улучшаем пушку
    }
}
