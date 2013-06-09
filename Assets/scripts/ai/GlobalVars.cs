using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
	public List<GameObject> MobList = new List<GameObject>(); //массив мобов в игре
	public int MobCount = 0; //счетчик мобов в игре

	public List<GameObject> TurretList = new List<GameObject>(); //массив пушек в игре
	public int TurretCount = 0; //счетчик пушек в игре

	public float PlayerMoney; //деньги игрока

	public ClickState mau5tate = ClickState.Default; //дефолтное состояние курсора

	public enum ClickState //перечисление всех состояний курсора
	{
		Default,
		Placing,
		Selling,
		Upgrading
	}

	public void Awake()
	{
		PlayerMoney = PlayerPrefs.GetFloat("Player Money", 200.0f); //при старте игры, если нету сохранённых данных про деньги игрока - их становится 200$, иначе загружается из памяти
	}

	public void OnApplicationQuit()
	{
		PlayerPrefs.SetFloat("Player Money", PlayerMoney); //сохраняет деньги игрока при выходе
		PlayerPrefs.Save();
	}
}