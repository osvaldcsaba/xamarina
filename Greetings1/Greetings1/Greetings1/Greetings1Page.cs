using Android.Content.PM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Greetings1
{
    public class Greetings1Page : ContentPage
    {

        //Button addButton, removeButton;
        //StackLayout loggerLayout = new StackLayout();

        public Greetings1Page()
        {
            //Content = new Label
            //{
            //Text = "Greetings1 Xamarin forms!",
            //HorizontalOptions = LayoutOptions.Center,
            //VerticalOptions = LayoutOptions.Center,

            ////HorizontalTextAlignment = TextAlignment.Center,
            ////VerticalTextAlignment = TextAlignment.Center,

            //FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            //FontAttributes = FontAttributes.Bold | FontAttributes.Italic,

            //BackgroundColor = Color.Yellow,
            //TextColor = Color.Blue

            //};
            // Padding = new Thickness(0, 20, 0, 0);

            //--------------------------------------------------------------------------------------------------------------------

            //var colors = new[] 
            //{
            //    new { value = Color.White, name = "White" },
            //    new { value = Color.Silver, name = "Silver" },
            //    new { value = Color.Gray, name = "Gray" },
            //    new { value = Color.Black, name = "Black" },
            //    new { value = Color.Red, name = "Red" },
            //    new { value = Color.Maroon, name = "Maroon" },
            //    new { value = Color.Yellow, name = "Yellow" },
            //    new { value = Color.Olive, name = "Olive" },
            //    new { value = Color.Lime, name = "Lime" },
            //    new { value = Color.Green, name = "Green" },
            //    new { value = Color.Aqua, name = "Aqua" },
            //    new { value = Color.Teal, name = "Teal" },
            //    new { value = Color.Blue, name = "Blue" },
            //    new { value = Color.Navy, name = "Navy" },
            //    new { value = Color.Pink, name = "Pink" },
            //    new { value = Color.Fuchsia, name = "Fuchsia" },
            //    new { value = Color.Purple, name = "Purple" }
            //};
            //StackLayout stackLayout = new StackLayout();

            //foreach (var color in colors)
            //{
            //    stackLayout.Children.Add(new Label
            //    {
            //        Text = color.name,
            //        TextColor = color.value,
            //        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            //    });
            //}
            //Padding = new Thickness(5, Device.OnPlatform(20, 5, 5), 5, 5);
            //Content = stackLayout;

            // -------------------------------------------------------------------------------------------------------------

            //Color[] colors = { Color.Yellow, Color.Blue };
            //int flipFlopper = 0;
            //// Create Labels sorted by LayoutAlignment property. 
            //IEnumerable<Label> labels = from field in typeof(LayoutOptions).GetRuntimeFields()
            //                            where field.IsPublic && field.IsStatic
            //                            orderby ((LayoutOptions)field.GetValue(null)).Alignment
            //                            select new Label
            //                            {
            //                                Text = "VerticalOptions = " + field.Name,
            //                                VerticalOptions = (LayoutOptions)field.GetValue(null),
            //                                HorizontalTextAlignment = TextAlignment.Center,
            //                                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            //                                TextColor = colors[flipFlopper],
            //                                BackgroundColor = colors[flipFlopper = 1 - flipFlopper]
            //                            };
            //StackLayout stackLayout = new StackLayout();
            //foreach (Label label in labels)
            //{
            //    stackLayout.Children.Add(label);
            //}
            //Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0); Content = stackLayout;

            // -------------------------------------------------------------------------------------------------------------

            //Padding = new Thickness(20);
            //Content = new Frame
            //{
            //    OutlineColor = Color.Accent,
            //    Content = new Label
            //    {
            //        Text = "I've been framed!",
            //        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            //        HorizontalOptions = LayoutOptions.Center,
            //        VerticalOptions = LayoutOptions.Center
            //    }
            //};

            // -------------------------------------------------------------------------------------------------------------

            //Padding = new Thickness(20);
            //Content = new Frame
            //{
            //    OutlineColor = Color.Accent,
            //    HorizontalOptions = LayoutOptions.Center,
            //    VerticalOptions = LayoutOptions.Center,
            //    Content = new Label
            //    {
            //        Text = "I've been framed!",
            //        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            //    }
            //};

            // -------------------------------------------------------------------------------------------------------------

            //BackgroundColor = Color.Aqua;
            //Content = new Frame
            //{
            //    OutlineColor = Color.Black,
            //    BackgroundColor = Color.Yellow,
            //    HorizontalOptions = LayoutOptions.Center,
            //    VerticalOptions = LayoutOptions.Center,
            //    Content = new Label
            //    {
            //        Text = "I've been framed!",
            //        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            //        FontAttributes = FontAttributes.Italic,
            //        TextColor = Color.Blue
            //    }
            //};

            // -------------------------------------------------------------------------------------------------------------

            //BackgroundColor = Color.Green;

            //Content = new BoxView
            //{
            //    Color = Color.Blue,
            //    HorizontalOptions = LayoutOptions.Center,
            //    VerticalOptions = LayoutOptions.Center,
            //    WidthRequest = 200,
            //    HeightRequest = 100
            //};

            // -------------------------------------------------------------------------------------------------------------

            //StackLayout mainStack = new StackLayout();
            //StackLayout textStack = new StackLayout
            //{
            //    Padding = new Thickness(5),
            //    Spacing = 10
            //};

            //// Get access to the text resource. 
            //Assembly assembly = GetType().GetTypeInfo().Assembly;
            //string resource = "Greetings1.Texts.TheBlackCat.txt";

            //using (Stream stream = assembly.GetManifestResourceStream(resource))
            //{
            //    using (StreamReader reader = new StreamReader(stream))
            //    {
            //        bool gotTitle = false;
            //        string line;

            //        // Read in a line (which is actually a paragraph).
            //        while (null != (line = reader.ReadLine()))
            //        {
            //            Label label = new Label
            //            {
            //                Text = line,
            //                // Black text for ebooks! 
            //                TextColor = Color.Black
            //            };
            //            if (!gotTitle)
            //            {
            //                // Add first label (the title) to mainStack. 
            //                label.HorizontalOptions = LayoutOptions.Center;
            //                label.FontSize = Device.GetNamedSize(NamedSize.Large, label);
            //                label.FontAttributes = FontAttributes.Bold;
            //                mainStack.Children.Add(label);
            //                gotTitle = true;
            //            }
            //            else
            //            {
            //                // Add subsequent labels to textStack. 
            //                textStack.Children.Add(label);
            //            }
            //        }
            //    }
            //}

            //// Put the textStack in a ScrollView with FillAndExpand. 
            //ScrollView scrollView = new ScrollView
            //{
            //    Content = textStack,
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    Padding = new Thickness(5, 0),
            //};

            //// Add the ScrollView as a second child of mainStack. 
            //mainStack.Children.Add(scrollView);

            //// Set page content to mainStack. 
            //Content = mainStack;

            //// White background for ebooks! 
            //BackgroundColor = Color.White;

            //// Add some iOS padding for the page. 
            //Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

            // -------------------------------------------------------------------------------------------------------------

            //Label clockLabel = new Label
            //{
            //    HorizontalOptions = LayoutOptions.Center,
            //    VerticalOptions = LayoutOptions.Center
            //};

            //Content = clockLabel;

            //// Handle the SizeChanged event for the page. 
            //SizeChanged += (sender, e) => 
            //{
            //    // Scale the font size to the page width 
            //    // (based on 11 characters in the displayed string). 
            //    if (this.Width > 0)
            //        clockLabel.FontSize = this.Width / 8;
            //};

            //// Start the timer going. 
            //Device.StartTimer(TimeSpan.FromSeconds(1), () => 
            //{
            //    // Set the Text property of the Label. 
            //    clockLabel.Text = DateTime.Now.ToString("HH:mm:ss");
            //    return true;
            //});

            // -------------------------------------------------------------------------------------------------------------

            //    // Create the Button views and attach Clicked handlers. 
            //    addButton = new Button
            //    {
            //        Text = "Add",
            //        HorizontalOptions = LayoutOptions.CenterAndExpand
            //    };

            //    addButton.Clicked += OnButtonClicked;

            //    removeButton = new Button
            //    {
            //        Text = "Remove",
            //        HorizontalOptions = LayoutOptions.CenterAndExpand,
            //        IsEnabled = false
            //    };

            //    removeButton.Clicked += OnButtonClicked;

            //    this.Padding = new Thickness(5, Device.OnPlatform(20, 0, 0), 5, 0);

            //    // Assemble the page. 
            //    this.Content = new StackLayout
            //    {
            //        Children =
            //        {
            //            new StackLayout
            //            {
            //                Orientation = StackOrientation.Horizontal,
            //                Children =
            //                {
            //                    addButton,
            //                    removeButton
            //                }
            //            },
            //            new ScrollView
            //            {
            //                VerticalOptions = LayoutOptions.FillAndExpand,
            //                Content = loggerLayout
            //            }
            //        }
            //    };


            //}

            //void OnButtonClicked(object sender, EventArgs args)
            //{
            //    Button button = (Button)sender;
            //    if (button == addButton)
            //    {
            //        // Add Label to scrollable StackLayout. 
            //        loggerLayout.Children.Add(new Label
            //        {
            //            Text = "Button clicked at " + DateTime.Now.ToString("T")
            //        });
            //    } else
            //    {
            //        // Remove topmost Label from StackLayout. 
            //        loggerLayout.Children.RemoveAt(0);
            //    }

            //    // Enable "Remove" button only if children are present. 
            //    removeButton.IsEnabled = loggerLayout.Children.Count > 0;
            //}

            // -------------------------------------------------------------------------------------------------------------

            // Number to manipulate. 
            double number = 1;
            
            // Create the Label for display. 
            Label label = new Label
            {
                Text = number.ToString(),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Create the first Button and attach Clicked handler. 
            Button timesButton = new Button
            {
                Text = "Double",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            timesButton.Clicked += (sender, args) =>
            {
                number *= 2;
                label.Text = number.ToString();
            };

            // Create the second Button and attach Clicked handler. 
            Button divideButton = new Button
            {
                Text = "Half",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            divideButton.Clicked += (sender, args) =>
            {
                number /= 2;
                label.Text = number.ToString();
            };

            // Assemble the page. 
            this.Content = new StackLayout
            {
                Children =
                    {
                        label,
                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            VerticalOptions = LayoutOptions.CenterAndExpand,
                            Children =
                            {
                                timesButton,
                                divideButton
                            }
                        }
                    }
            };

            // -------------------------------------------------------------------------------------------------------------



            // -------------------------------------------------------------------------------------------------------------



            // -------------------------------------------------------------------------------------------------------------

        }

    }
}
