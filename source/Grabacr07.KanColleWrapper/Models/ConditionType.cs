using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grabacr07.KanColleWrapper.Models
{
	/// <summary>
	/// コンディションの種別を示す識別子を定義します。
	/// </summary>
	public enum ConditionType
	{
        Max = 100,
		/// <summary>
		/// キラキラ状態 (コンディション値 50 ～ 100)。
		/// </summary>
		Brilliant = 50,
		// 神宝「ブリリアントドラゴンバレッタ」 

		/// <summary>
		/// 通常状態 (コンディション値 40 ～ 49)。
		/// </summary>
		Normal = 40,

		/// <summary>
		/// 疲労状態 (間宮点灯, コンディション値 30 ～ 39)。
		/// </summary>
		Tired = 30,

		/// <summary>
		/// 疲労状態 (橙アイコン, コンディション値 20 ～ 29)。
		/// </summary>
		OrangeTired = 20,

		/// <summary>
		/// 疲労状態 (赤アイコン, コンディション値 0 ～ 20)。
		/// </summary>
		RedTired = 0,
        Min = 0,
	}

	public static class ConditionTypeHelper
	{
		/// <summary>
		/// コンディション値を示す整数値から、<see cref="ConditionType"/> 値へ変換します。
		/// </summary>
		public static ConditionType ToConditionType(int condition)
		{
			if (condition >= 50) return ConditionType.Brilliant;
			if (condition >= 40) return ConditionType.Normal;
			if (condition >= 30) return ConditionType.Tired;
			if (condition >= 20) return ConditionType.OrangeTired;
			return ConditionType.RedTired;
		}
	}
}
