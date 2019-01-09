using Android.App;
using Android.Widget;
using Android.OS;
using Syncfusion.Android.DataForm;
using System;
using System.ComponentModel.DataAnnotations;
using Syncfusion.Android.DataForm.Editors;
using Android.Content;
using Android.Graphics;

namespace DataFormCustomImageEditor
{
    [Activity(Label = "DataFormCustomImageEditor", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        SfDataForm dataForm;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            dataForm = new SfDataForm(this);
            dataForm.DataObject = new ContactForm();
            dataForm.RegisterEditor("ImageEditor", new DataFormCustomImageEditor(dataForm,this));
            dataForm.RegisterEditor("Image", "ImageEditor");
            dataForm.LayoutManager = new DataFormLayoutManagerExt(dataForm);
            dataForm.SetBackgroundColor(Color.White);
            SetContentView(dataForm);

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
    public class DataFormCustomImageEditor : DataFormEditor<ImageView>
    {
        Context context;
        public DataFormCustomImageEditor(SfDataForm dataForm, Context mainContext) : base(dataForm)
        {
            context = mainContext;
        }

        protected override ImageView OnCreateEditorView()
        {
            return new ImageView(context);
        }
        protected override void OnInitializeView(DataFormItem dataFormItem, ImageView view)
        {
            base.OnInitializeView(dataFormItem, view);
            view.SetImageResource(Resource.Drawable.Person);

        }
    }

}

