using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Utils;
using SkinColorPermissionModule.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SkinColorPermissionModule
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    [ToolboxTabName(XafAssemblyInfo.DXTabXafModules)]
    [Description("Customize your Application Skin Color")]
    [ToolboxItem(true)]
    public sealed partial class SkinColorPermissionModuleModule : ModuleBase
    {
        public SkinColorPermissionModuleModule()
        {
            InitializeComponent();
            BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }
        public override void Setup(XafApplication application)
        {
            base.Setup(application);
            // Manage various aspects of the application UI and behavior at the module level.
        }
        public override void CustomizeTypesInfo(ITypesInfo typesInfo)
        {
            base.CustomizeTypesInfo(typesInfo);
            //CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
            ITypeInfo typeInfoDomainObject1 = XafTypesInfo.Instance.FindTypeInfo(typeof(PermissionPolicyUser));
            typeInfoDomainObject1.CreateMember("Color", typeof(Int32));
            IMemberInfo typeInfoDomainObject1Metadata = typeInfoDomainObject1.FindMember("Color");
            typeInfoDomainObject1Metadata.AddAttribute(new VisibleInReportsAttribute(false));
            typeInfoDomainObject1Metadata.AddAttribute(new VisibleInDetailViewAttribute(false));
            typeInfoDomainObject1Metadata.AddAttribute(new VisibleInListViewAttribute(false));
            typeInfoDomainObject1Metadata.AddAttribute(new VisibleInLookupListViewAttribute(false));

            typeInfoDomainObject1.CreateMember("Color2", typeof(Int32));
            IMemberInfo typeInfoDomainObject1Metadata2 = typeInfoDomainObject1.FindMember("Color2");
            typeInfoDomainObject1Metadata2.AddAttribute(new VisibleInReportsAttribute(false));
            typeInfoDomainObject1Metadata2.AddAttribute(new VisibleInDetailViewAttribute(false));
            typeInfoDomainObject1Metadata2.AddAttribute(new VisibleInListViewAttribute(false));
            typeInfoDomainObject1Metadata2.AddAttribute(new VisibleInLookupListViewAttribute(false));

        }

        protected override IEnumerable<Type> GetDeclaredControllerTypes()
        {
            //return base.GetDeclaredControllerTypes();
            return new Type[] {
                typeof(ColorWheelController),


            };
        }
    }
}
