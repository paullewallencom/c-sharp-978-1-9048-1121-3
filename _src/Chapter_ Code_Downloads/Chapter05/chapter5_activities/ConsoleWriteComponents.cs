using System;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Design;
using System.Drawing;
using System.Workflow.ComponentModel;
using System.Drawing.Drawing2D;

namespace OdeToCode.WF.CustomActivities
{
    public class ConsoleWriteValidator : ActivityValidator 
    {
        public override ValidationErrorCollection Validate(
            ValidationManager manager, object obj)
        {
            ValidationErrorCollection errors = base.Validate(manager, obj);

            ConsoleWriteActivity activity = obj as ConsoleWriteActivity;

            if (activity.Parent != null && String.IsNullOrEmpty(activity.Text))
            {
                errors.Add(ValidationError.GetNotSetValidationError("Text"));
            }

            return errors;
        }
    }

    public class ConsoleWriteDesigner : ActivityDesigner
    {
        ConsoleWriteActivity _activity;

        protected override void Initialize(Activity activity)
        {
            _activity = activity as ConsoleWriteActivity;
            base.Initialize(activity);
        }

        protected override Size OnLayoutSize(ActivityDesignerLayoutEventArgs e)
        {
            return new Size(120, 70);
        }

        protected override void OnPaint(ActivityDesignerPaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Black, Location.X, 
                                     Location.Y, Size.Width, Size.Height);

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;

            Rectangle rect = new Rectangle(Location.X, Location.Y, 
                                           Size.Width, 15);
            e.Graphics.DrawString(Activity.QualifiedName, DesignerTheme.Font, 
                                    Brushes.Yellow, rect, format);
                        
            using(Font font = new Font("Lucida Console", 7))
            {
                e.Graphics.DrawString("> " + _activity.Text, font, 
                                    Brushes.White, rect.X, rect.Y + 20);
            }
        }        
    }
}