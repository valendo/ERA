namespace My.Content {
    
    
    [Composite.Data.AutoUpdatebleAttribute()]
    [Composite.Data.DataScopeAttribute("public")]
    [Composite.Data.RelevantToUserTypeAttribute("Developer")]
    [Composite.Data.CodeGeneratedAttribute()]
    [Composite.Data.Hierarchy.DataAncestorProviderAttribute(typeof(Composite.Data.Hierarchy.DataAncestorProviders.NoAncestorDataAncestorProvider))]
    [Composite.Data.ImmutableTypeIdAttribute("46f9597f-1ff5-4a1d-9689-ab6cbe4c0af9")]
    [Composite.Core.WebClient.Renderings.Data.KeyTemplatedXhtmlRendererAttribute(Composite.Core.WebClient.Renderings.Data.XhtmlRenderingType.Embedable, "<span>{label}</span>")]
    [Composite.Data.KeyPropertyNameAttribute("Id")]
    [Composite.Data.TitleAttribute("Partners")]
    [Composite.Data.LabelPropertyNameAttribute("Name")]
    public interface Partner : Composite.Data.IData {
        
        [Composite.Data.ImmutableFieldIdAttribute("1ddfd285-968e-4c70-aa2e-403623e12c2f")]
        [Composite.Data.FunctionBasedNewInstanceDefaultFieldValueAttribute("<f:function name=\"Composite.Utils.Guid.NewGuid\" xmlns:f=\"http://www.composite.net" +
            "/ns/function/1.0\" />")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.Guid)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(-1)]
        System.Guid Id {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("8b2307fe-2853-4903-a4b2-9bb5ade7365b")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 256)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(0)]
        [Composite.Data.Validation.Validators.StringSizeValidatorAttribute(0, 256)]
        [Composite.Data.DefaultFieldStringValueAttribute("")]
        string Name {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("4aeacbcd-ec01-4f82-9e5c-679b9e467fb2")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 2048)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(1)]
        [Composite.Data.Validation.Validators.StringSizeValidatorAttribute(0, 2048)]
        [Composite.Data.DefaultFieldStringValueAttribute("")]
        [Composite.Data.ForeignKeyAttribute("Composite.Data.Types.IImageFile,Composite", AllowCascadeDeletes=true, NullReferenceValue=null)]
        string Logo {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("aff899c2-9577-43d5-a3b7-0736cd453f2e")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 1024, IsNullable=true)]
        [Composite.Data.FieldPositionAttribute(2)]
        [Composite.Data.Validation.Validators.NullStringLengthValidatorAttribute(0, 1024)]
        string Url {
            get;
            set;
        }
    }
}
