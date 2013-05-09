namespace Composite.Community.Newsletter {
    
    
    [Composite.Data.AutoUpdatebleAttribute()]
    [Composite.Data.DataScopeAttribute("public")]
    [Composite.Data.RelevantToUserTypeAttribute("Developer")]
    [Composite.Data.CodeGeneratedAttribute()]
    [Composite.Data.Hierarchy.DataAncestorProviderAttribute(typeof(Composite.Data.Hierarchy.DataAncestorProviders.NoAncestorDataAncestorProvider))]
    [Composite.Data.ImmutableTypeIdAttribute("ceeb1576-3468-4bd2-b50d-a04783ba9410")]
    [Composite.Core.WebClient.Renderings.Data.KeyTemplatedXhtmlRendererAttribute(Composite.Core.WebClient.Renderings.Data.XhtmlRenderingType.Embedable, "<span>{label}</span>")]
    [Composite.Data.KeyPropertyNameAttribute("Id")]
    [Composite.Data.TitleAttribute("ConfirmEmailTemplate")]
    [Composite.Data.LabelPropertyNameAttribute("Name")]
    public interface ConfirmEmailTemplate : Composite.Data.IData, Composite.Data.ProcessControlled.ILocalizedControlled, Composite.Data.ProcessControlled.IProcessControlled {
        
        [Composite.Data.ImmutableFieldIdAttribute("5ff67086-b140-4738-a111-ca62626aa10d")]
        [Composite.Data.FunctionBasedNewInstanceDefaultFieldValueAttribute("<f:function name=\"Composite.Utils.Guid.NewGuid\" xmlns:f=\"http://www.composite.net" +
            "/ns/function/1.0\" />")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.Guid)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(-1)]
        System.Guid Id {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("20d7ebaf-b266-4403-887d-04ad38cd91f1")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 128)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(0)]
        [Composite.Data.Validation.Validators.StringSizeValidatorAttribute(0, 128)]
        [Composite.Data.DefaultFieldStringValueAttribute("")]
        string Name {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("d879d67e-04c1-4800-ba4b-ddd6b08c7169")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 128)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(1)]
        [Composite.Data.Validation.Validators.StringSizeValidatorAttribute(0, 128)]
        [Composite.Data.DefaultFieldStringValueAttribute("")]
        string Subject {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("9efba134-62d2-48fb-b2bd-950885b93370")]
        [Composite.Data.FunctionBasedNewInstanceDefaultFieldValueAttribute(@"<f:function xmlns:f=""http://www.composite.net/ns/function/1.0"" name=""Composite.Constant.String""><f:param name=""Constant"" value=""&lt;html xmlns=&quot;http://www.w3.org/1999/xhtml&quot;&gt;&#xA;&#x9;&lt;head&gt;&lt;/head&gt;&#xA;&#x9;&lt;body&gt;&#xA;&#x9;&#x9;&lt;h2&gt;Hi,&#xA;&#x9;&#x9;&#x9;&lt;data:fieldreference fieldname=&quot;Name&quot; typemanagername=&quot;Composite.Community.Newsletter.SubjectBased.IMember,Composite.Community.Newsletter.SubjectBased&quot; xmlns:data=&quot;http://www.composite.net/ns/dynamicdata/1.0&quot; /&gt;.&#xA;&#x9;&#x9;&lt;/h2&gt;&#xA;&#x9;&#x9;&lt;p&gt;Please confirm your subscription by clicking this link: &lt;/p&gt;&#xA;&#x9;&#x9;&lt;f:function name=&quot;Composite.Community.Newsletter.SubjectBased.ConfirmLink&quot; xmlns:f=&quot;http://www.composite.net/ns/function/1.0&quot; /&gt;&#xA;&#x9;&lt;/body&gt;&#xA;&lt;/html&gt;"" /></f:function>")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.LargeString)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(2)]
        [Composite.Data.DefaultFieldStringValueAttribute("")]
        string Template {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("73150dfc-f3c8-45db-84e8-e258912a0bd5")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 64)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(3)]
        [Composite.Data.Validation.Validators.StringSizeValidatorAttribute(0, 64)]
        [Composite.Data.DefaultFieldStringValueAttribute("")]
        string FromName {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("fd1640ee-e295-4917-a82c-573736a1d186")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 64)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(4)]
        [Composite.Data.Validation.Validators.StringSizeValidatorAttribute(0, 64)]
        [Composite.Data.DefaultFieldStringValueAttribute("")]
        string FromEmail {
            get;
            set;
        }
    }
}
