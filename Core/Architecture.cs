namespace VmProject.Core;

/// <summary>Коды команд MISC VM (6-битный opcode).</summary>
public enum Opcode : byte
{
    // Системные
    Nop   = 0x00, // Пустая операция / выравнивание
    Halt  = 0x01, // Штатный останов процессора
    Hcf   = 0x02, // Halt and Catch Fire! Жесткая блокировка ядра (вечный цикл / прерывание / паника / смерть / кровь / синий экран)

    // Память и константы (стек данных)
    Ldi   = 0x03, // Положить число на стек данных (T)
    Load  = 0x04, // Чтение из RAM: [T] -> T
    Store = 0x05, // Запись в RAM: S -> [T]
    ToR   = 0x06, // Перенести из стека данных в стек возвратов (T -> R)
    FromR = 0x07, // Перенести из стека возвратов в стек данных (R -> T)

    // Арифметика и логика (над T и S)
    Add   = 0x08, // T = S + T
    And   = 0x09, // T = S & T
    Xor   = 0x0A, // T = S ^ T (заменяет инверсию Not)
    Shr   = 0x0B, // T = T >> 1 (сдвиг строго на 1 бит)

    // Управление потоком
    Jmp   = 0x0C, // Безусловный переход
    Jz    = 0x0D, // Переход, если T == 0
    Call  = 0x0E, // Вызов функции (адрес возврата -> стек возвратов)
    Ret   = 0x0F  // Возврат из функции
}

public enum InstructionFormat { Simple, R, I, J, S }

[Flags]
public enum CpuFlags { None = 0, Zero = 1, Negative = 2, Carry = 4, Overflow = 8 }

public enum CpuError
{
    Assembly, InvalidInstruction, MemoryAccess, StackOverflow, StackUnderflow,
    DivisionByZero, StepAfterHalt, StepLimit, HaltAndCatchFire
}

/// <summary>Поля, извлечённые из 32-битной команды.</summary>
public readonly record struct DecodedInstruction(
    Opcode Opcode,
    int Rd,
    int Rs1,
    int Rs2,
    int Immediate);
