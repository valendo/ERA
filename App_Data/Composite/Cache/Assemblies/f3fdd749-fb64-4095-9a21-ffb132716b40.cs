namespace My.Media {
    
    
    [Composite.Data.AutoUpdatebleAttribute()]
    [Composite.Data.DataScopeAttribute("public")]
    [Composite.Data.RelevantToUserTypeAttribute("Developer")]
    [Composite.Data.CodeGeneratedAttribute()]
    [Composite.Data.Hierarchy.DataAncestorProviderAttribute(typeof(Composite.Data.Hierarchy.DataAncestorProviders.NoAncestorDataAncestorProvider))]
    [Composite.Data.ImmutableTypeIdAttribute("f3fdd749-fb64-4095-9a21-ffb132716b40")]
    [Composite.Core.WebClient.Renderings.Data.KeyTemplatedXhtmlRendererAttribute(Composite.Core.WebClient.Renderings.Data.XhtmlRenderingType.Embedable, "<span>{label}</span>")]
    [Composite.Data.KeyPropertyNameAttribute("Id")]
    [Composite.Data.TitleAttribute("Slider")]
    [Composite.Data.LabelPropertyNameAttribute("Image")]
    public interface Slider : Composite.Data.IData {
        
        [Composite.Data.ImmutableFieldIdAttribute("8211a2b0-fe47-4b77-bad4-7c5c0683cfb2")]
        [Composite.Data.FunctionBasedNewInstanceDefaultFieldValueAttribute("<f:function name=\"Composite.Utils.Guid.NewGuid\" xmlns:f=\"http://www.composite.net" +
            "/ns/function/1.0\" />")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.Guid)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(-1)]
        System.Guid Id {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("412ae4a4-ca8c-4962-9329-607d3074c65d")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 2048)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(0)]
        [Composite.Data.Validation.Validators.StringSizeValidatorAttribute(0, 2048)]
        [Composite.Data.DefaultFieldStringValueAttribute("")]
        [Composite.Data.ForeignKeyAttribute("Composite.Data.Types.IImageFile,Composite", AllowCascadeDeletes=true, NullReferenceValue=null)]
        string Image {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("04c070e6-4d5c-49b4-b6c8-422bd4a4a16e")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 1024, IsNullable=true)]
        [Composite.Data.FieldPositionAttribute(1)]
        [Composite.Data.Validation.Validators.NullStringLengthValidatorAttribute(0, 1024)]
        string Link {
            get;
            set;
        }
    }
}
