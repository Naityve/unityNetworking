using System.Runtime.InteropServices;

public static class StructExtensions
{
    public static T ToStruct<T>(this byte[] data) where T: struct
    {
        var size = Marshal.SizeOf(typeof(T));
        var ptr = Marshal.AllocHGlobal(size);
        Marshal.Copy(data, 0, ptr, size);

        var copyData = (T)Marshal.PtrToStructure(ptr, typeof(T));
        Marshal.FreeHGlobal(ptr);
        return copyData;
    }

    public static byte[] ToArray (this object data)
    {
        var size = Marshal.SizeOf(data);
        byte[] buf = new byte[size];
        var ptr = Marshal.AllocHGlobal(size);

        Marshal.StructureToPtr(data, ptr, true);
        Marshal.Copy(ptr, buf, 0, size);

        Marshal.FreeHGlobal(ptr);
        return buf;
    }
}