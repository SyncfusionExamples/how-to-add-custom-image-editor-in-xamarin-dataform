using Syncfusion.XForms.DataForm;
using Syncfusion.XForms.DataForm.Editors;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DataFormCustomImageEditor
{
    public class DataFormBehavior : Behavior<ContentPage>
    {
        SfDataForm dataForm = null;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            dataForm = bindable.FindByName<SfDataForm>("dataForm");
            dataForm.DataObject = new ContactForm();
            dataForm.RegisterEditor("ImageEditor", new DataFormCustomImageEditor(dataForm));
            dataForm.RegisterEditor("Image", "ImageEditor");

            dataForm.LayoutManager = new DataFormLayoutManagerExt(dataForm);
        }

    }

    public class DataFormLayoutManagerExt : DataFormLayoutManager
    {
        public DataFormLayoutManagerExt(SfDataForm dataForm) : base(dataForm)
        {

        }

        protected override int GetLeftPaddingForEditor(DataFormItem dataFormItem)
        {
            var item = base.GetLeftPaddingForEditor(dataFormItem);
            if (dataFormItem.Name == "Image")
                return -350;

            return item;
        }
    }
    public class ContactForm
    {

        [DisplayOptions(ShowLabel = false)]
        public string Image { get; set; }

        [Display(ShortName = "Name")]
        public string Name { get; set; } = "John";

        [Display(Name = "Contact Number")]
        public string Number { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }

    }
    public class DataFormCustomImageEditor : DataFormEditor<Image>
    {
        public DataFormCustomImageEditor(SfDataForm dataForm) : base(dataForm)
        {

        }

        protected override Image OnCreateEditorView(DataFormItem dataFormItem)
        {
            return new Image();
        }
        protected override void OnInitializeView(DataFormItem dataFormItem, Image view)
        {
            base.OnInitializeView(dataFormItem, view);
            view.Source = "Person.png";
        }
    }

}
