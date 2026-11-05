using VmProject.Core;

uint word = 0x0C345678;
DecodedInstruction instruction = Decoder.Decode(word);

Console.WriteLine($"Opcode: {(byte)instruction.Opcode}");
Console.WriteLine($"rd: {instruction.Rd}");
Console.WriteLine($"rs1: {instruction.Rs1}");
Console.WriteLine($"rs2: {instruction.Rs2}");
Console.WriteLine($"Immediate: {instruction.Immediate}");
