namespace My.Navigation {
    
    
    [Composite.Data.AutoUpdatebleAttribute()]
    [Composite.Data.DataScopeAttribute("public")]
    [Composite.Data.RelevantToUserTypeAttribute("Developer")]
    [Composite.Data.CodeGeneratedAttribute()]
    [Composite.Data.Hierarchy.DataAncestorProviderAttribute(typeof(Composite.Data.Hierarchy.DataAncestorProviders.NoAncestorDataAncestorProvider))]
    [Composite.Data.ImmutableTypeIdAttribute("faad0943-49a0-4443-b2be-40936a0e95c2")]
    [Composite.Core.WebClient.Renderings.Data.KeyTemplatedXhtmlRendererAttribute(Composite.Core.WebClient.Renderings.Data.XhtmlRenderingType.Embedable, "<span>{label}</span>")]
    [Composite.Data.KeyPropertyNameAttribute("Id")]
    [Composite.Data.TitleAttribute("Footer Links")]
    [Composite.Data.LabelPropertyNameAttribute("Page")]
    public interface FooterLink : Composite.Data.IData {
        
        [Composite.Data.ImmutableFieldIdAttribute("ffc9b3ed-02e1-4860-ad0a-8b045993b333")]
        [Composite.Data.FunctionBasedNewInstanceDefaultFieldValueAttribute("<f:function name=\"Composite.Utils.Guid.NewGuid\" xmlns:f=\"http://www.composite.net" +
            "/ns/function/1.0\" />")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.Guid)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(-1)]
        System.Guid Id {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("70df9164-35d9-448e-abcd-ac7455297892")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.Guid)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.Validation.Validators.GuidNotEmptyAttribute()]
        [Composite.Data.FieldPositionAttribute(0)]
        [Composite.Data.DefaultFieldGuidValueAttribute("00000000-0000-0000-0000-000000000000")]
        [Composite.Data.ForeignKeyAttribute("Composite.Data.Types.IPage,Composite", AllowCascadeDeletes=true, NullReferenceValue="{00000000-0000-0000-0000-000000000000}")]
        System.Guid Page {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("98ed51db-4512-4a5b-8318-de328ad7f690")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.Integer, IsNullable=true)]
        [Composite.Data.FieldPositionAttribute(1)]
        [Composite.Data.Validation.Validators.NullIntegerRangeValidatorAttribute(-2147483648, 2147483647)]
        [Composite.Data.TreeOrderingAttribute(1)]
        System.Nullable<int> Order {
            get;
            set;
        }
    }
}
