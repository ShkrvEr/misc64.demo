namespace VmProject.Core;

/// <summary>Кодирует opcode и операндные поля в 32-битное машинное слово.</summary>
public static class Encoder
{
	private const int MinImmediate = -(1 << 13);
	private const int MaxImmediate =  (1 << 13) - 1;

	/// <summary>
	/// Общая раскладка: opcode [31:26], rd [25:22], rs1 [21:18],
	/// rs2 [17:14], signed immediate [13:0]. Неиспользуемые поля передавать нулём.
	/// </summary>
	public static uint Encode(
		Opcode opcode,
		int rd 			= 0,
		int rs1 		= 0,
		int rs2 		= 0,
		int immediate 	= 0)
	{
		if (!Enum.IsDefined(typeof(Opcode), opcode))
			throw new ArgumentOutOfRangeException(nameof(opcode));

		ValidateField(rd,  nameof(rd));
		ValidateField(rs1, nameof(rs1));
		ValidateField(rs2, nameof(rs2));

		if (immediate < MinImmediate || immediate > MaxImmediate)
			throw new ArgumentOutOfRangeException(
				nameof(immediate), "Immediate must fit in signed 14 bits.");

		return ((uint)opcode 	<< 26)
			 | ((uint)rd     	<< 22)
			 | ((uint)rs1 	 	<< 18)
			 | ((uint)rs2 	 	<< 14)
			 | ((uint)immediate & 0x3FFF);
	}

	private static void ValidateField(int value, string name)
	{
		if (value is < 0 or > 15)
			throw new ArgumentOutOfRangeException(name, "Field must fit in 4 bits.");
	}
}
