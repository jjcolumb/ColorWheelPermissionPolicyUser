using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using System;

namespace SkinColorPermissionModule.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ColorWheelController : ViewController
    {


        private SimpleAction _colorWheelSimpleAction;
        public ColorWheelController()
        {
            InitializeComponent();
            ActionSetup();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }

        protected void ActionSetup()
        {
            _colorWheelSimpleAction = new SimpleAction(this, "ColorWheelAction", PredefinedCategory.Tools);
            _colorWheelSimpleAction.Caption = "Color Wheel";
            _colorWheelSimpleAction.ImageName = "Action_ChooseSkin";
        }

        public SimpleAction ColorWheelAction => _colorWheelSimpleAction;
    
        protected override void OnActivated()
        {
            base.OnActivated();
            _colorWheelSimpleAction.Execute += _colorWheelSimpleAction_Execute;
            // Perform various tasks depending on the target View.
        }

        protected virtual void _colorWheelSimpleAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            throw new NotImplementedException("Implement this action at platform level");
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
            _colorWheelSimpleAction.Execute -= _colorWheelSimpleAction_Execute;
        }
    }
}
