namespace VmProject.Core;

/// <summary>Состояние CPU и цикл выполнения виртуальной машины.</summary>
public sealed class Cpu
{
    public ulong[] Registers { get; } = new ulong[16];
    public ulong PC { get; set; }
    public VmState State { get; private set; } = VmState.Running;

    // TODO: реализовать Step/Run и семантику ISA.
}
