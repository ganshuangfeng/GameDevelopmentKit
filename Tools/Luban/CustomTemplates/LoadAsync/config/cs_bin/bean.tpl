﻿using Bright.Serialization;
using System.Collections.Generic;
{{
    name = x.name
    parent_def_type = x.parent_def_type
    export_fields = x.export_fields
    hierarchy_export_fields = x.hierarchy_export_fields
}}

{{cs_start_name_space_grace x.namespace_with_top_module}}
{{~if x.comment != '' ~}}
/// <summary>
/// {{x.escape_comment}}
/// </summary>
{{~end~}}
public {{x.cs_class_modifier}} partial class {{name}} : {{if parent_def_type}} {{x.parent}} {{else}} Bright.Config.BeanBase {{end}}
{
    public {{name}}(ByteBuf _buf) {{if parent_def_type}} : base(_buf) {{end}}
    {
        {{~ for field in export_fields ~}}
        {{cs_deserialize '_buf' field.convention_name field.ctype}}
        {{~if field.index_field~}}
        foreach(var _v in {{field.convention_name}})
        { 
            {{field.convention_name}}_Index.Add(_v.{{field.index_field.convention_name}}, _v);
        }
        {{~end~}}
        {{~end~}}
        PostInit();
    }

    public static {{name}} Deserialize{{name}}(ByteBuf _buf)
    {
    {{~if x.is_abstract_type~}}
        switch (_buf.ReadInt())
        {
        {{~for child in x.hierarchy_not_abstract_children~}}
            case {{child.full_name}}.__ID__: return new {{child.full_name}}(_buf);
        {{~end~}}
            default: throw new SerializationException();
        }
    {{~else~}}
        return new {{x.full_name}}(_buf);
    {{~end~}}
    }

    {{~ for field in export_fields ~}}
{{~if field.comment != '' ~}}
    /// <summary>
    /// {{field.escape_comment}}
    /// </summary>
{{~end~}}
    public {{cs_define_type field.ctype}} {{field.convention_name}} { get; private set; }
    {{~if field.index_field~}} 
    public readonly Dictionary<{{cs_define_type field.index_field.ctype}}, {{cs_define_type field.ctype.element_type}}> {{field.convention_name}}_Index = new Dictionary<{{cs_define_type field.index_field.ctype}}, {{cs_define_type field.ctype.element_type}}>();
    {{~end~}}
    {{~if field.gen_ref~}}
    public {{field.cs_ref_validator_define}}
    {{~end~}}
    {{~if (gen_datetime_mills field.ctype) ~}}
    public long {{field.convention_name}}_Millis => {{field.convention_name}} * 1000L;
    {{~end~}}
    {{~if field.gen_text_key~}}
    public {{cs_define_text_key_field field}} { get; }
    {{~end~}}
    {{~end~}}

{{~if !x.is_abstract_type~}}
    public const int __ID__ = {{x.id}};
    public override int GetTypeId() => __ID__;
{{~end~}}

    public {{x.cs_method_modifier}} void Resolve(Dictionary<string, IDataTable> _tables)
    {
        {{~if parent_def_type~}}
        base.Resolve(_tables);
        {{~end~}}
        {{~ for field in export_fields ~}}
        {{~if field.gen_ref~}}
        {{cs_ref_validator_resolve field}}
        {{~else if field.has_recursive_ref~}}
        {{cs_recursive_resolve field '_tables'}}
        {{~end~}}
        {{~end~}}
        PostResolve();
    }

    public {{x.cs_method_modifier}} void TranslateText(System.Func<string, string, string> translator)
    {
        {{~if parent_def_type~}}
        base.TranslateText(translator);
        {{~end~}}
        {{~ for field in export_fields ~}}
        {{~if field.gen_text_key~}}
        {{cs_translate_text field 'translator'}}
        {{~else if field.has_recursive_text~}}
        {{cs_recursive_translate_text field 'translator'}}
        {{~end~}}
        {{~end~}}
    }

    public override string ToString()
    {
        return "{{full_name}}{ "
    {{~for field in hierarchy_export_fields ~}}
        + "{{field.convention_name}}:" + {{cs_to_string field.convention_name field.ctype}} + ","
    {{~end~}}
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}

{{cs_end_name_space_grace x.namespace_with_top_module}}