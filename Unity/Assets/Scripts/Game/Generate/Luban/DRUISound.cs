
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;

namespace Game
{
public sealed partial class DRUISound : Luban.BeanBase
{
    public DRUISound(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        AssetName = _buf.ReadString();
        Priority = _buf.ReadInt();
        Volume = _buf.ReadFloat();
        PostInit();
    }

    public static DRUISound DeserializeDRUISound(ByteBuf _buf)
    {
        return new DRUISound(_buf);
    }

    /// <summary>
    /// 声音编号
    /// </summary>
    public readonly int Id;
    /// <summary>
    /// 资源名称
    /// </summary>
    public readonly string AssetName;
    /// <summary>
    /// 优先级（默认0，128最高，-128最低）
    /// </summary>
    public readonly int Priority;
    /// <summary>
    /// 音量（0~1）
    /// </summary>
    public readonly float Volume;
    public const int __ID__ = -1172887923;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(TablesComponent tables)
    {
        PostResolveRef();
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "AssetName:" + AssetName + ","
        + "Priority:" + Priority + ","
        + "Volume:" + Volume + ","
        + "}";
    }

    partial void PostInit();
    partial void PostResolveRef();
}
}
