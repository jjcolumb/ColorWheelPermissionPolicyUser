using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Utils;
using SkinColorPermissionModuleWin.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SkinColorPermissionModuleWin
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    [ToolboxTabName(XafAssemblyInfo.DXTabXafModules)]
    [ToolboxItemFilter("Xaf.Platform.Win")]
    [Description("Customize your Application Skin Color")]
    [ToolboxItem(true)]
    public sealed partial class SkinColorPermissionModuleWinModule : ModuleBase
    {
        public SkinColorPermissionModuleWinModule()
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
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
        }

        protected override IEnumerable<Type> GetDeclaredControllerTypes()
        {

            return new Type[] {
                typeof(ColorWheelControllerWin),typeof(ColorWheelPermissionUserControllerWin),


            };
        }
    }
}
