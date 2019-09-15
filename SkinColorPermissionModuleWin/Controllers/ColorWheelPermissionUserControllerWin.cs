using DevExpress.ExpressApp;
using DevExpress.LookAndFeel;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using System;
using System.Drawing;

namespace SkinColorPermissionModuleWin.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppWindowControllertopic.aspx.
    public partial class ColorWheelPermissionUserControllerWin : WindowController
    {
        public ColorWheelPermissionUserControllerWin()
        {
            InitializeComponent();
            // Target required Windows (via the TargetXXX properties) and create their Actions.
            this.TargetWindowType = WindowType.Any;
        }
        protected override void OnActivated()
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            var employee = objectSpace.GetObjectByKey<PermissionPolicyUser>(SecuritySystem.CurrentUserId);
            if (!ReferenceEquals(null, employee))
            {

                int color1 = 0;
                int color2 = 0;

                try
                {
                    color1 = (Int32)employee.GetMemberValue("Color");
                    color2 = (Int32)employee.GetMemberValue("Color2");

                }
                catch (Exception)
                {

                }
                Color Color1 = Color.FromArgb(color1);
                Color Color2 = Color.FromArgb(color2);

                if (Color1.Name != "0")
                {
                    UserLookAndFeel.Default.SkinMaskColor = Color1;
                    if (Color2.Name != "0")
                    {
                        UserLookAndFeel.Default.SkinMaskColor2 = Color2;
                    }
                }
            }
            base.OnActivated();
            // Perform various tasks depending on the target Window.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
