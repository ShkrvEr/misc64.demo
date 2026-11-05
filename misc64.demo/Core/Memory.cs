namespace VmProject.Core;

/// <summary>Раздельные области памяти команд и данных.</summary>
public sealed class Memory
{
    public byte[] Code { get; } = new byte[65_536];
    public byte[] Data { get; } = new byte[65_536];

    // TODO: добавить проверки диапазона, little-endian чтение/запись и memory-mapped I/O.
}
