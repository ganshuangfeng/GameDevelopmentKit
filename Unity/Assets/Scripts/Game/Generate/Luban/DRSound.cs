//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;


namespace Game
{
public sealed partial class DRSound :  Bright.Config.BeanBase 
{
    public DRSound(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        AssetName = _buf.ReadString();
        Priority = _buf.ReadInt();
        Loop = _buf.ReadBool();
        Volume = _buf.ReadFloat();
        SpatialBlend = _buf.ReadFloat();
        MaxDistance = _buf.ReadFloat();
        PostInit();
    }

    public static DRSound DeserializeDRSound(ByteBuf _buf)
    {
        return new DRSound(_buf);
    }

    /// <summary>
    /// 声音编号
    /// </summary>
    public int Id { get; private set; }
    /// <summary>
    /// 资源名称
    /// </summary>
    public string AssetName { get; private set; }
    /// <summary>
    /// 优先级（默认0，128最高，-128最低）
    /// </summary>
    public int Priority { get; private set; }
    /// <summary>
    /// 是否循环
    /// </summary>
    public bool Loop { get; private set; }
    /// <summary>
    /// 音量（0~1）
    /// </summary>
    public float Volume { get; private set; }
    /// <summary>
    /// 声音空间混合量（0为2D，1为3D，中间值混合效果）
    /// </summary>
    public float SpatialBlend { get; private set; }
    /// <summary>
    /// 声音最大距离
    /// </summary>
    public float MaxDistance { get; private set; }

    public const int __ID__ = -1646593759;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, object> _tables)
    {
        PostResolve();
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "AssetName:" + AssetName + ","
        + "Priority:" + Priority + ","
        + "Loop:" + Loop + ","
        + "Volume:" + Volume + ","
        + "SpatialBlend:" + SpatialBlend + ","
        + "MaxDistance:" + MaxDistance + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}