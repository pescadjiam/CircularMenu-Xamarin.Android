using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace CircularMenu
{
    public class CircularMenu
    {
        private RelativeLayout parent_layout, circular_parent_layout;
        private LinearLayout circular_inner_circle;
        private TextView circular_inner_circle_text;

        private string DEFAULT_CIRCULAR_INNER_CIRCLE_TEXT = string.Empty;
        private Color DEFAULT_BACKGROUND_INNER_CIRCLE = Color.White;
        private Color DEFAULT_INNER_CIRCLE_TEXT_COLOR = Color.Black;

        public event EventHandler InnerCircleClick;

        private ViewGroup container;

        public CircularMenu(Context context, ViewGroup container)
        {
            this.container = container;
            InitializeViews(context, container);
        }

        private void InitializeViews(Context context, ViewGroup container)
        {
            View view = LayoutInflater.FromContext(context).Inflate(Resource.Layout.circular_menu, container);
            //RELATIVE LAYOUTS
            parent_layout = view.FindViewById<RelativeLayout>(Resource.Id.parent_layout);
            circular_parent_layout = view.FindViewById<RelativeLayout>(Resource.Id.circular_parent_layout);

            //LINEAR LAYOUTS
            circular_inner_circle = view.FindViewById<LinearLayout>(Resource.Id.circular_inner_circle);
            
            //TEXTVIEWS
            circular_inner_circle_text = view.FindViewById<TextView>(Resource.Id.circular_inner_circle_text);

            //DEFAULT VALUES
            InnerCircleBackgroundColor = DEFAULT_BACKGROUND_INNER_CIRCLE;
            InnerCircleText = DEFAULT_CIRCULAR_INNER_CIRCLE_TEXT;
            InnerCircleTextColor = DEFAULT_INNER_CIRCLE_TEXT_COLOR;

            //CLICK HANDLERS
            circular_inner_circle.Click += delegate
            {
                if (InnerCircleClick != null)
                    InnerCircleClick(this, EventArgs.Empty);
            };
        }

        //PROPERTIES
        public Color InnerCircleBackgroundColor
        {
            set
            {
                GradientDrawable shapeBg = circular_inner_circle.Background as GradientDrawable;
                shapeBg.SetColor(value);
            }
        }

        public string InnerCircleText
        {
            get { return circular_inner_circle_text.Text; }
            set { circular_inner_circle_text.Text = value; }
        }

        public Color InnerCircleTextColor
        {
            set { circular_inner_circle_text.SetTextColor(value); }
        }

        public bool Visibility
        {
            get { return parent_layout.Visibility == ViewStates.Visible ? true : false; }
            set { parent_layout.Visibility = value == true ? ViewStates.Visible : ViewStates.Gone; }
        }

        //METHODS
        public void SetVisible(bool visible, bool anim = false)
        {
            if (anim)
            {

            }
            else
            {
                Visibility = visible;
            }
        }

    }
}