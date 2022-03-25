﻿/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.StyleGuide
{
    // IExample inehrited class will be automatically added in the main examples list.
    internal class RadioButtonExample : ContentPage, IExample
    {
        private View rootContent;
        private View left;
        private View right;
        private View leftbody;
        private View rightbody;

        private TextLabel[] createText = new TextLabel[2];
        private TextLabel[] modeText = new TextLabel[4];
        private TextLabel[] modeText2 = new TextLabel[4];

        private RadioButton[] utilityRadioButton = new RadioButton[4];
        private RadioButton[] familyRadioButton = new RadioButton[4];
        private RadioButton[] foodRadioButton = new RadioButton[4];
        private RadioButton[] kitchenRadioButton = new RadioButton[4];
        private RadioButtonGroup[] group = new RadioButtonGroup[4];

        private RadioButton[] utilityRadioButton2 = new RadioButton[4];
        private RadioButton[] familyRadioButton2 = new RadioButton[4];
        private RadioButton[] foodRadioButton2 = new RadioButton[4];
        private RadioButton[] kitchenRadioButton2 = new RadioButton[4];
        private RadioButtonGroup[] group2 = new RadioButtonGroup[4];

        private static string[] mode = new string[]
        {
            "Style A",
            "Style B",
            "Style C",
            "Style D",
        };

        public void Activate()
        {
        }
        public void Deactivate()
        {
        }

        /// Modify this method for adding other examples.
        public RadioButtonExample() : base()
        {
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;

            // Navigator bar title is added here.
            AppBar = new AppBar()
            {
                Title = "RadioButton Default Style",
            };

            var path = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

            // Example root content view.
            // you can decorate, add children on this view.
            rootContent = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,

                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(10, 20),
                },
            };

            // RadioButton examples.
            // Create by Property
            left = new View()
            {
                Weight = 0.5f,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical
                }
            };

            //Create left description text.
            createText[0] = new TextLabel();
            createText[0].Text = "Create RadioButton just by properties";
            createText[0].TextColor = Color.White;
            createText[0].Size = new Size(800, 100);
            left.Add(createText[0]);

            leftbody = new View();
            leftbody.Layout = new GridLayout() { Columns = 4 };
            int num = 4;
            for (int i = 0; i < num; i++)
            {
                group[i] = new RadioButtonGroup();
                modeText[i] = new TextLabel();
                modeText[i].Text = mode[i];
                modeText[i].Size = new Size(200, 48);
                modeText[i].HorizontalAlignment = HorizontalAlignment.Center;
                modeText[i].VerticalAlignment = VerticalAlignment.Center;
                leftbody.Add(modeText[i]);
            }

            for (int i = 0; i < num; i++)
            {
                int index = i + 1;

                // create utility radio button.
                utilityRadioButton[i] = new RadioButton();
                utilityRadioButton[i].SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
                {
                    global::System.Console.WriteLine($"Left {index}th Utility RadioButton's IsSelected is changed to {args.IsSelected}.");
                };
                var utilityStyle = utilityRadioButton[i].Style;
                utilityStyle.Icon.Opacity = new Selector<float?>
                {
                    Normal = 1.0f,
                    Selected = 1.0f,
                    Disabled = 0.4f,
                    DisabledSelected = 0.4f
                };
                utilityStyle.Icon.BackgroundImage = "";
                utilityStyle.Icon.ResourceUrl = new Selector<string>
                {
                    Normal = path + "/radiobutton/controller_btn_radio_off.png",
                    Selected = path + "/radiobutton/controller_btn_radio_on.png",
                    Disabled = path + "/radiobutton/controller_btn_radio_off.png",
                    DisabledSelected = path + "/radiobutton/controller_btn_radio_on.png",
                };
                utilityRadioButton[i].ApplyStyle(utilityStyle);
                utilityRadioButton[i].Size = new Size(48, 48);
                utilityRadioButton[i].Icon.Size = new Size(48, 48);
                group[0].Add(utilityRadioButton[i]);

                // create family radio button.
                familyRadioButton[i] = new RadioButton();
                familyRadioButton[i].SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
                {
                    global::System.Console.WriteLine($"Left {index}th Family RadioButton's IsSelected is changed to {args.IsSelected}.");
                };
                var familyStyle = familyRadioButton[i].Style;
                familyStyle.Icon.Opacity = new Selector<float?>
                {
                    Normal = 1.0f,
                    Selected = 1.0f,
                    Disabled = 0.4f,
                    DisabledSelected = 0.4f
                };
                familyStyle.Icon.BackgroundImage = "";
                familyStyle.Icon.ResourceUrl = new Selector<string>
                {
                    Normal = path + "/radiobutton/controller_btn_radio_off.png",
                    Selected = path + "/radiobutton/[Controller] App Primary Color/controller_btn_radio_on_24c447.png",
                    Disabled = path + "/radiobutton/controller_btn_radio_off.png",
                    DisabledSelected = path + "/radiobutton/[Controller] App Primary Color/controller_btn_radio_on_24c447.png",
                };
                familyRadioButton[i].ApplyStyle(familyStyle);
                familyRadioButton[i].Size = new Size(48, 48);
                familyRadioButton[i].Icon.Size = new Size(48, 48);

                group[1].Add(familyRadioButton[i]);

                // create food radio button.
                foodRadioButton[i] = new RadioButton();
                foodRadioButton[i].SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
                {
                    global::System.Console.WriteLine($"Left {index}th Food RadioButton's IsSelected is changed to {args.IsSelected}.");
                };
                var foodStyle = foodRadioButton[i].Style;
                foodStyle.Icon.Opacity = new Selector<float?>
                {
                    Normal = 1.0f,
                    Selected = 1.0f,
                    Disabled = 0.4f,
                    DisabledSelected = 0.4f
                };
                foodStyle.Icon.BackgroundImage = "";
                foodStyle.Icon.ResourceUrl = new Selector<string>
                {
                    Normal = path + "/radiobutton/controller_btn_radio_off.png",
                    Selected = path + "/radiobutton/[Controller] App Primary Color/controller_btn_radio_on_ec7510.png",
                    Disabled = path + "/radiobutton/controller_btn_radio_off.png",
                    DisabledSelected = path + "/radiobutton/[Controller] App Primary Color/controller_btn_radio_on_ec7510.png",
                };
                foodRadioButton[i].ApplyStyle(foodStyle);
                foodRadioButton[i].Size = new Size(150, 48);
                foodRadioButton[i].Icon.Size = new Size(48, 48);

                group[2].Add(foodRadioButton[i]);

                // create kitchen radio button.
                kitchenRadioButton[i] = new RadioButton();
                kitchenRadioButton[i].SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
                {
                    global::System.Console.WriteLine($"Left {index}th Kitchen RadioButton's IsSelected is changed to {args.IsSelected}.");
                };
                var kitchenStyle = kitchenRadioButton[i].Style;
                kitchenStyle.Icon.Opacity = new Selector<float?>
                {
                    Normal = 1.0f,
                    Selected = 1.0f,
                    Disabled = 0.4f,
                    DisabledSelected = 0.4f
                };
                kitchenStyle.Icon.BackgroundImage = "";
                kitchenStyle.Icon.ResourceUrl = new Selector<string>
                {
                    Normal = path + "/radiobutton/controller_btn_radio_off.png",
                    Selected = path + "/radiobutton/[Controller] App Primary Color/controller_btn_radio_on_9762d9.png",
                    Disabled = path + "/radiobutton/controller_btn_radio_off.png",
                    DisabledSelected = path + "/radiobutton/[Controller] App Primary Color/controller_btn_radio_on_9762d9.png",
                };
                kitchenRadioButton[i].ApplyStyle(kitchenStyle);
                kitchenRadioButton[i].Size = new Size(48, 48);
                kitchenRadioButton[i].Icon.Size = new Size(48, 48);

                group[3].Add(kitchenRadioButton[i]);

                leftbody.Add(utilityRadioButton[i]);
                leftbody.Add(familyRadioButton[i]);
                leftbody.Add(foodRadioButton[i]);
                leftbody.Add(kitchenRadioButton[i]);
            }

            // Create by Attributes
            right = new View()
            {
                Weight = 0.5f,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                }
            };

            rightbody = new View();
            rightbody.Layout = new GridLayout() { Columns = 4 };
            createText[1] = new TextLabel();
            createText[1].Text = "Create RadioButton just by styles";
            createText[1].TextColor = Color.White;
            createText[1].Size = new Size(800, 100);
            right.Add(createText[1]);

            for (int i = 0; i < num; i++)
            {
                group2[i] = new RadioButtonGroup();
                modeText2[i] = new TextLabel();
                modeText2[i].Text = mode[i];
                modeText2[i].Size = new Size(200, 48);
                modeText2[i].HorizontalAlignment = HorizontalAlignment.Center;
                modeText2[i].VerticalAlignment = VerticalAlignment.Center;
                rightbody.Add(modeText2[i]);
            }

            //Create utility style of radio button.
            ButtonStyle utilityStyle2 = new ButtonStyle
            {
                Icon = new ImageViewStyle
                {
                    Size = new Size(48, 48),
                    Opacity = new Selector<float?>
                    {
                        Normal = 1.0f,
                        Selected = 1.0f,
                        Disabled = 0.4f,
                        DisabledSelected = 0.4f
                    },
                    ResourceUrl = new Selector<string>
                    {
                        Normal = path + "/radiobutton/controller_btn_radio_off.png",
                        Selected = path + "/radiobutton/controller_btn_radio_on.png",
                        Disabled = path + "/radiobutton/controller_btn_radio_off.png",
                        DisabledSelected = path + "/radiobutton/controller_btn_radio_on.png",
                    },
                },
            };
            //Create family style of radio button.
            ButtonStyle familyStyle2 = new ButtonStyle
            {
                Icon = new ImageViewStyle
                {
                    Size = new Size(48, 48),
                    Opacity = new Selector<float?>
                    {
                        Normal = 1.0f,
                        Selected = 1.0f,
                        Disabled = 0.4f,
                        DisabledSelected = 0.4f
                    },
                    ResourceUrl = new Selector<string>
                    {
                        Normal = path + "/radiobutton/controller_btn_radio_off.png",
                        Selected = path + "/radiobutton/[Controller] App Primary Color/controller_btn_radio_on_24c447.png",
                        Disabled = path + "/radiobutton/controller_btn_radio_off.png",
                        DisabledSelected = path + "/radiobutton/[Controller] App Primary Color/controller_btn_radio_on_24c447.png",
                    },
                },
            };
            //Create food style of radio button.
            ButtonStyle foodStyle2 = new ButtonStyle
            {
                Icon = new ImageViewStyle
                {
                    Size = new Size(48, 48),
                    Opacity = new Selector<float?>
                    {
                        Normal = 1.0f,
                        Selected = 1.0f,
                        Disabled = 0.4f,
                        DisabledSelected = 0.4f
                    },
                    ResourceUrl = new Selector<string>
                    {
                        Normal = path + "/radiobutton/controller_btn_radio_off.png",
                        Selected = path + "/radiobutton/[Controller] App Primary Color/controller_btn_radio_on_ec7510.png",
                        Disabled = path + "/radiobutton/controller_btn_radio_off.png",
                        DisabledSelected = path + "/radiobutton/[Controller] App Primary Color/controller_btn_radio_on_ec7510.png",
                    },
                },
            };
            //Create kitchen style of radio button.
            ButtonStyle kitchenStyle2 = new ButtonStyle
            {
                Icon = new ImageViewStyle
                {
                    Size = new Size(48, 48),
                    Opacity = new Selector<float?>
                    {
                        Normal = 1.0f,
                        Selected = 1.0f,
                        Disabled = 0.4f,
                        DisabledSelected = 0.4f
                    },
                    ResourceUrl = new Selector<string>
                    {
                        Normal = path + "/radiobutton/controller_btn_radio_off.png",
                        Selected = path + "/radiobutton/[Controller] App Primary Color/controller_btn_radio_on_9762d9.png",
                        Disabled = path + "/radiobutton/controller_btn_radio_off.png",
                        DisabledSelected = path + "/radiobutton/[Controller] App Primary Color/controller_btn_radio_on_9762d9.png",
                    },
                },
            };
            for (int i = 0; i < num; i++)
            {
                int index = i + 1;

                utilityRadioButton2[i] = new RadioButton(utilityStyle2);
                utilityRadioButton2[i].SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
                {
                    global::System.Console.WriteLine($"Right {index}th Utility RadioButton's IsSelected is changed to {args.IsSelected}.");
                };
                utilityRadioButton2[i].Size = new Size(48, 48);
                group2[0].Add(utilityRadioButton2[i]);

                familyRadioButton2[i] = new RadioButton(familyStyle2);
                familyRadioButton2[i].SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
                {
                    global::System.Console.WriteLine($"Right {index}th Family RadioButton's IsSelected is changed to {args.IsSelected}.");
                };
                familyRadioButton2[i].Size = new Size(48, 48);
                group2[1].Add(familyRadioButton2[i]);

                foodRadioButton2[i] = new RadioButton(foodStyle2);
                foodRadioButton2[i].SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
                {
                    global::System.Console.WriteLine($"Right {index}th Food RadioButton's IsSelected is changed to {args.IsSelected}.");
                };
                foodRadioButton2[i].Size = new Size(48, 48);
                group2[2].Add(foodRadioButton2[i]);

                kitchenRadioButton2[i] = new RadioButton(kitchenStyle2);
                kitchenRadioButton2[i].SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
                {
                    global::System.Console.WriteLine($"Right {index}th Kitchen RadioButton's IsSelected is changed to {args.IsSelected}.");
                };
                kitchenRadioButton2[i].Size = new Size(48, 48);
                group2[3].Add(kitchenRadioButton2[i]);

                rightbody.Add(utilityRadioButton2[i]);
                rightbody.Add(familyRadioButton2[i]);
                rightbody.Add(foodRadioButton2[i]);
                rightbody.Add(kitchenRadioButton2[i]);
            }

            rootContent.Add(left);
            rootContent.Add(right);
            left.Add(leftbody);
            right.Add(rightbody);

            utilityRadioButton[2].IsEnabled = false;
            familyRadioButton[2].IsEnabled = false;
            foodRadioButton[2].IsEnabled = false;
            kitchenRadioButton[2].IsEnabled = false;

            utilityRadioButton2[2].IsEnabled = false;
            familyRadioButton2[2].IsEnabled = false;
            foodRadioButton2[2].IsEnabled = false;
            kitchenRadioButton2[2].IsEnabled = false;

            utilityRadioButton[3].IsEnabled = false;
            familyRadioButton[3].IsEnabled = false;
            foodRadioButton[3].IsEnabled = false;
            kitchenRadioButton[3].IsEnabled = false;
            utilityRadioButton[3].IsSelected = true;
            familyRadioButton[3].IsSelected = true;
            foodRadioButton[3].IsSelected = true;
            kitchenRadioButton[3].IsSelected = true;

            utilityRadioButton2[3].IsEnabled = false;
            familyRadioButton2[3].IsEnabled = false;
            foodRadioButton2[3].IsEnabled = false;
            kitchenRadioButton2[3].IsEnabled = false;
            utilityRadioButton2[3].IsSelected = true;
            familyRadioButton2[3].IsSelected = true;
            foodRadioButton2[3].IsSelected = true;
            kitchenRadioButton2[3].IsSelected = true;

            Content = rootContent;
        }
    }
}
