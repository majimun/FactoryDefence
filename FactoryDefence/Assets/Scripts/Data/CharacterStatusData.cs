using UnityEngine;
using System.Collections;

public struct CharacterStatusData {

	// ステータスフィールド
	public string Name;
	public string Id;
	public string Attribute;
	public int Level;
	public int Hp;
	public int Hp_max;
	public int Exp;
	public int Exp_max;
	public int Attack;
	public int Speed;
	public int Search_range;
	public int Attack_renge;
	public int Energy_rate;


	public void Edit (object name, object status) {
		// フィールドの全情報を取得する
		var fields = GetType().GetFields();
		foreach(var fieldInfo in fields) {
			if(name.Equals(fieldInfo.Name)) {
				fieldInfo.SetValue(this, System.Convert.ChangeType(status, fieldInfo.FieldType));
			}
		}
	}
}
