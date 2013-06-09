using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
	public List<GameObject> MobList = new List<GameObject>(); //������ ����� � ����
	public int MobCount = 0; //������� ����� � ����

	public List<GameObject> TurretList = new List<GameObject>(); //������ ����� � ����
	public int TurretCount = 0; //������� ����� � ����

	public float PlayerMoney; //������ ������

	public ClickState mau5tate = ClickState.Default; //��������� ��������� �������

	public enum ClickState //������������ ���� ��������� �������
	{
		Default,
		Placing,
		Selling,
		Upgrading
	}

	public void Awake()
	{
		PlayerMoney = PlayerPrefs.GetFloat("Player Money", 200.0f); //��� ������ ����, ���� ���� ���������� ������ ��� ������ ������ - �� ���������� 200$, ����� ����������� �� ������
	}

	public void OnApplicationQuit()
	{
		PlayerPrefs.SetFloat("Player Money", PlayerMoney); //��������� ������ ������ ��� ������
		PlayerPrefs.Save();
	}
}