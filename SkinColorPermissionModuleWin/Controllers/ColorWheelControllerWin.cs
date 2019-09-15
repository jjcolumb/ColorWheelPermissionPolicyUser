using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.LookAndFeel;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.XtraEditors.ColorWheel;
using SkinColorPermissionModule.Controllers;
using System;

namespace SkinColorPermissionModuleWin.Controllers
{
    public class ColorWheelControllerWin : ColorWheelController
    {
        protected override void _colorWheelSimpleAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            ColorWheelForm cwForm = new ColorWheelForm();
            cwForm.ShowDialog();
        }

        private void Default_StyleChanged(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.Design.UserLookAndFeelDefault ulfd = sender as DevExpress.LookAndFeel.Design.UserLookAndFeelDefault;            
            var user = this.ObjectSpace.GetObjectByKey<PermissionPolicyUser>(SecuritySystem.CurrentUserId);

            if (ulfd != null && user != null)
            {

                System.Drawing.Color color = ulfd.SkinMaskColor;
                System.Drawing.Color color2 = ulfd.SkinMaskColor2;
                user.SetMemberValue("Color", color.ToArgb());
                user.SetMemberValue("Color2", color2.ToArgb());
            }

            if (this.ObjectSpace.IsModified) { this.View.ObjectSpace.CommitChanges(); }
        }
        protected override void OnActivated()
        {
            UserLookAndFeel.Default.StyleChanged += Default_StyleChanged;
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            UserLookAndFeel.Default.StyleChanged -= Default_StyleChanged;
            base.OnDeactivated();
        }
    }
}
