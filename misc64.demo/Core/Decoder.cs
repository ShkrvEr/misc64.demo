namespace VmProject.Core;

/// <summary>Извлекает поля из 32-битного машинного слова.</summary>
public static class Decoder
{
	private const uint  OpcodeMask        = 0b11_1111;
	private const uint  RegisterMask      = 0b1111;
	private const uint  ImmediateMask     = 0b11_1111_1111_1111;
	private const int   ImmediateSignBit  = 1 << 13;
	private const int   ImmediateModulus  = 1 << 14;

	public static DecodedInstruction Decode(uint word)
	{
		byte opcodeValue = (byte)((word >> 26) & OpcodeMask);
		if (!Enum.IsDefined(typeof(Opcode), opcodeValue))
			throw new ArgumentException($"Unknown opcode: 0x{opcodeValue:X2}.", nameof(word));

		int immediateBits = (int)(word & ImmediateMask);
		int immediate = (immediateBits & ImmediateSignBit) != 0
			? immediateBits - ImmediateModulus
			: immediateBits;

		return new DecodedInstruction(
			(Opcode)opcodeValue,
			(int)((word >> 22) & RegisterMask),
			(int)((word >> 18) & RegisterMask),
			(int)((word >> 14) & RegisterMask),
			immediate);
	}
}
