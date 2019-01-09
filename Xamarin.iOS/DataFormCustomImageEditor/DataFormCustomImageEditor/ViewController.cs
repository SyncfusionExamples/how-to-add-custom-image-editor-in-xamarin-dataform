using System;
using Syncfusion.iOS.DataForm;
using UIKit;
using System.ComponentModel.DataAnnotations;
using Syncfusion.iOS.DataForm.Editors;

namespace DataFormCustomImageEditor
{
    public partial class ViewController : UIViewController
    {
        SfDataForm dataForm;
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            dataForm = new SfDataForm();
            dataForm.DataObject = new ContactForm();
            dataForm.RegisterEditor("ImageEditor", new DataFormCustomImageEditor(dataForm));
            dataForm.RegisterEditor("Image", "ImageEditor");

            //dataForm.LayoutManager = new DataFormLayoutManagerExt(dataForm);
            // Set our view from the "main" layout resource
            dataForm.BackgroundColor = (UIColor.White);
            dataForm.Frame = new CoreGraphics.CGRect(0,50,400,1000);
            UIView uIView = new UIView();
            uIView.Frame = new CoreGraphics.CGRect(0, 0, 50, 50);
            dataForm.ColumnCount = 2;
            View.AddSubview(uIView);
            View.AddSubview(dataForm);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }

    public class DataFormLayoutManagerExt : DataFormLayoutManager
    {
        public DataFormLayoutManagerExt(SfDataForm dataForm) : base(dataForm)
        {

        }

        protected override nfloat GetLeftPaddingForEditor(DataFormItem dataFormItem)
        {
            var item = base.GetLeftPaddingForEditor(dataFormItem);
            if (dataFormItem.Name == "Image")
                return -300;

            return item;
        }
    }
    public class ContactForm
    {

        [DisplayOptions(ShowLabel = false, RowSpan =5)]
        public string Image { get; set; }

        [DisplayOptions(ColumnSpan =2)]
        [Display(ShortName = "Name")]
        public string Name { get; set; } = "John";

        [DisplayOptions(ColumnSpan = 2)]
        [Display(Name = "Contact Number")]
        public string Number { get; set; }

        [DisplayOptions(ColumnSpan = 2)]
        public string Email { get; set; }

        [DisplayOptions(ColumnSpan = 2)]
        public string Address { get; set; }

        [DisplayOptions(ColumnSpan = 2)]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }

    }
    public class DataFormCustomImageEditor : DataFormEditor<UIImageView>
    {
        public DataFormCustomImageEditor(SfDataForm dataForm) : base(dataForm)
        {
        }

        protected override UIImageView OnCreateEditorView()
        {
            return new UIImageView();
        }
        protected override void OnInitializeView(DataFormItem dataFormItem, UIImageView view)
        {
            base.OnInitializeView(dataFormItem, view);
            view.Image =  UIImage.FromFile("Person.png");
        }
    }

}
