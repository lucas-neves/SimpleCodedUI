using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace CodedUITestProject1
{
    public class BasePage
    {
    
        public HtmlControl GetElementByName(UITestControl parent, string name)
        {
            HtmlControl control = new HtmlControl(parent);
            control.SearchProperties.Add(HtmlControl.PropertyNames.Name, name);
            return control;
        }

        public void Click<T>(UITestControl parent, PropertyType type, string typeC) where T: HtmlControl
        {
            HtmlControl control = (T)Activator.CreateInstance(typeof(T), new object[] { parent });
            AddPropertyControl(control, type, typeC);
            Mouse.Click(control);
        }

        public void EnterText<T>(UITestControl parent, PropertyType type, string typeC, string text) where T : HtmlControl
        {
            HtmlControl control = (T)Activator.CreateInstance(typeof(T), new object[] { parent });
            AddPropertyControl(control, type, typeC);            
            Keyboard.SendKeys(control, text);
        }

        public void HoverInMenu<T>(UITestControl parent, PropertyType type, string typeC) where T : HtmlControl
        {
            HtmlControl control = (T)Activator.CreateInstance(typeof(T), new object[] { parent });
            AddPropertyControl(control, type, typeC);
            control.WaitForControlExist();
            Mouse.HoverDuration = 1000;
            Mouse.Hover(control);
        }

        public void SelectComboBoxItemList(UITestControl parent, string id, string item)
        {
            var list = new HtmlComboBox(parent);
            list.SearchProperties.Add(HtmlHyperlink.PropertyNames.Id, id);

            list.SelectedItem = item;
        }

        public void SelectRadioItemList(UITestControl parent, string name)
        {
            var item = new HtmlRadioButton(parent);
            item.SearchProperties.Add(HtmlRadioButton.PropertyNames.Name, name);

            Mouse.Click(item);
        }

        public void CheckItemCbx(UITestControl parent, string name)
        {
            var cbx = new HtmlCheckBox(parent);
            cbx.SearchProperties.Add(HtmlHyperlink.PropertyNames.Name, name);

            if (cbx.Checked == false)
            {
                cbx.Checked = true;
            }
            else
            {
                cbx.Checked = false;
            }
        }

        public void ScrollAndClick<T>(UITestControl parent, PropertyType type, string typeC) where T : HtmlControl
        {
            HtmlControl control = (T)Activator.CreateInstance(typeof(T), new object[] { parent });
            AddPropertyControl(control, type, typeC);

            bool isClickable = false;
            if (control.TryFind())
            {
                while (!isClickable)
                {
                    try
                    {
                        control.EnsureClickable();
                        Mouse.Click(control);
                        isClickable = true;
                    }
                    catch (FailedToPerformActionOnHiddenControlException)
                    {
                        Mouse.MoveScrollWheel(-1);
                        throw;
                    }

                }
            }
            else
            {
                throw new AssertInconclusiveException("Control Not Found");
            }

        }

        public enum PropertyType
        {
            Id,
            Name,
            ClassName,
            InnerText,
            TagName,
            ValueAttribute
        }

        private void AddPropertyControl(HtmlControl control, PropertyType type, string typeC)
        {
            if (type == PropertyType.Id)
            {
                control.SearchProperties.Add(HtmlControl.PropertyNames.Id, typeC);
            }
            else if (type == PropertyType.Name)
            {
                control.SearchProperties.Add(HtmlControl.PropertyNames.Name, typeC);
            }
            else if (type == PropertyType.ClassName)
            {
                control.SearchProperties.Add(HtmlControl.PropertyNames.ClassName, typeC);
            }
            else if (type == PropertyType.InnerText)
            {
                control.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, typeC);
            }
            else if (type == PropertyType.TagName)
            {
                control.SearchProperties.Add(HtmlControl.PropertyNames.TagName, typeC);
            }
            else if (type == PropertyType.ValueAttribute)
            {
                control.SearchProperties.Add(HtmlControl.PropertyNames.ValueAttribute, typeC);
            }
        }
    }
}
