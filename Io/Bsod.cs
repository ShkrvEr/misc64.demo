namespace VmProject.Io;

/// <summary>Диагностический экран, показываемый при HCF.</summary>
public static class Bsod
{
    public static void Show(string details) =>
        Console.WriteLine($"\n*** VM PANIC: HCF ***\n{details}\n");
}
