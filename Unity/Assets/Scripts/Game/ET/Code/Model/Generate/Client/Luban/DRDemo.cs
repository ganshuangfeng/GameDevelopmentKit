//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;


namespace ET
{
public sealed partial class DRDemo :  Bright.Config.BeanBase 
{
    public DRDemo(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        Name_l10n_key = _buf.ReadString(); Name = _buf.ReadString();
        {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);TestMap = new System.Collections.Generic.Dictionary<string, string>(n0 * 3 / 2);for(var i0 = 0 ; i0 < n0 ; i0++) { string _k0;  _k0 = _buf.ReadString(); string _v0;  _v0 = _buf.ReadString();     TestMap.Add(_k0, _v0);}}
        PostInit();
    }

    public static DRDemo DeserializeDRDemo(ByteBuf _buf)
    {
        return new DRDemo(_buf);
    }

    public int Id { get; private set; }
    /// <summary>
    /// key
    /// </summary>
    public string Name { get; private set; }
    public string Name_l10n_key { get; }
    public System.Collections.Generic.Dictionary<string, string> TestMap { get; private set; }

    public const int __ID__ = 2024637329;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, IDataTable> _tables)
    {
        PostResolve();
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
        Name = translator(Name_l10n_key, Name);
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "Name:" + Name + ","
        + "TestMap:" + Bright.Common.StringUtil.CollectionToString(TestMap) + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}