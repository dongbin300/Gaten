using Gaten.Windows.MintChoco3.Model;
using Gaten.Windows.MintChoco3.Resources.Texts;

using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gaten.Windows.MintChoco3
{
    /// <summary>
    /// MenuSetting.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MenuSetting : Window
    {
        Model.Menu menu;
        IMenuItem currentModule;

        public MenuSetting()
        {
            InitializeComponent();
            menu = new Model.Menu();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        void RefreshMenu()
        {
            MenuListBox.Items.Clear();
            foreach (var item in menu.MenuItems)
            {
                MenuListBox.Items.Add(item);
            }
        }

        ModuleCollection GetParent(Module module)
        {
            return menu.ModuleCollections.Find(mc => mc.Modules.Any(m => m.Name.Equals(module.Name)));
        }

        void MoveModuleToAnotherCollection(Module module, ModuleCollection sourceCollection, ModuleCollection destinationCollection)
        {
            Module module1 = new Module();
            module1.Name = module.Name;
            module1.HotKey = module.HotKey;
            module1.Path = module.Path;
            module1.Ischild = true;
            module1.Index = destinationCollection.Modules.Count + 1;
            destinationCollection.Modules.Add(module1);

            var targetModules = sourceCollection.Modules.Where(mo => mo.Index > module.Index);
            foreach (var targetModule in targetModules)
            {
                targetModule.Index--;
            }
            sourceCollection.Modules.Remove(module);

            currentModule = module1;
        }

        void MoveModuleToCollection(Module module, ModuleCollection destinationCollection)
        {
            Module module1 = new Module();
            module1.Name = module.Name;
            module1.HotKey = module.HotKey;
            module1.Path = module.Path;
            module1.Ischild = true;
            module1.Index = destinationCollection.Modules.Count + 1;
            destinationCollection.Modules.Add(module1);

            var targetModules = menu.Modules.Where(mo => mo.Index > module.Index);
            foreach (var targetModule in targetModules)
            {
                targetModule.Index--;
            }
            menu.Modules.Remove(module);

            currentModule = module1;
        }

        void MoveModuleToMenu(Module module, ModuleCollection sourceCollection)
        {
            Module module1 = new Module();
            module1.Name = module.Name;
            module1.HotKey = module.HotKey;
            module1.Path = module.Path;
            module1.Ischild = false;
            module1.Index = menu.Modules.Count + 1;
            menu.Modules.Add(module1);

            var targetModules = sourceCollection.Modules.Where(mo => mo.Index > module.Index);
            foreach (var targetModule in targetModules)
            {
                targetModule.Index--;
            }
            sourceCollection.Modules.Remove(module);

            currentModule = module1;
        }

        private void SetModuleButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModuleNameText.Text.Length <= 0)
            {
                MessageBox.Show("이름을 입력하세요.");
                return;
            }

            if (ModuleHotKeyText.Text.Length != 1)
            {
                MessageBox.Show("단축키는 한 글자의 영문자(A~Z), 숫자(0~9)만 가능합니다.");
                return;
            }

            if (!(ModuleHotKeyText.Text[0] >= 'A' && ModuleHotKeyText.Text[0] <= 'Z')
                && !(ModuleHotKeyText.Text[0] >= '0' && ModuleHotKeyText.Text[0] <= '9'))
            {
                MessageBox.Show("단축키는 한 글자의 영문자(A~Z), 숫자(0~9)만 가능합니다.");
                return;
            }

            if (currentModule is Module m)
            {
                m.Name = ModuleNameText.Text;
                m.HotKey = ModuleHotKeyText.Text;
                m.Path = ModulePathText.Text;
            }
            else if (currentModule is ModuleCollection mc)
            {
                mc.Name = ModuleNameText.Text;
                mc.HotKey = ModuleHotKeyText.Text;
            }

            RefreshMenu();
        }

        private void DeleteModuleButton_Click(object sender, RoutedEventArgs e)
        {
            if (MenuListBox.SelectedItem == null)
            {
                return;
            }

            if (currentModule is Module m)
            {
                if (m.Ischild)
                {
                    var parent = GetParent(m);
                    var targetModules = parent.Modules.Where(mo => mo.Index > m.Index);
                    foreach (var targetModule in targetModules)
                    {
                        targetModule.Index--;
                    }
                    parent.Modules.Remove(m);
                }
                else
                {
                    foreach (var module in menu.Modules)
                    {
                        module.Index--;
                    }
                    menu.Modules.Remove(m);
                }
            }
            else if (currentModule is ModuleCollection mc)
            {
                var targetCollections = menu.ModuleCollections.Where(moc => moc.Index > mc.Index);
                foreach (var targetCollection in targetCollections)
                {
                    targetCollection.Index--;
                }

                foreach (var module in mc.Modules)
                {
                    var module1 = new Module();
                    module1.Name = module.Name;
                    module1.HotKey = module.HotKey;
                    module1.Path = module.Path;
                    module1.Ischild = false;
                    module1.Index = menu.Modules.Count + 1;
                    menu.Modules.Add(module);
                }

                menu.ModuleCollections.Remove(mc);
            }

            ModuleNameText.Text = "";
            ModuleHotKeyText.Text = "";
            ModulePathText.Text = "";
            currentModule = null;

            RefreshMenu();
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentModule is Module m)
            {
                if (m.Index == 1)
                {
                    return;
                }

                if (m.Ischild)
                {
                    var parent = GetParent(m);

                    var swapModule = parent.Modules.Find(mo => mo.Index == m.Index - 1);
                    swapModule.Index++;
                    m.Index--;
                }
                else
                {
                    var swapModule = menu.Modules.Find(mo => mo.Index == m.Index - 1);
                    swapModule.Index++;
                    m.Index--;
                }
            }
            else if (currentModule is ModuleCollection mc)
            {
                if (mc.Index == 1)
                {
                    return;
                }

                var swapModuleCollection = menu.ModuleCollections.Find(moc => moc.Index == mc.Index - 1);
                swapModuleCollection.Index++;
                mc.Index--;
            }

            RefreshMenu();
            MenuListBox.SelectedItem = currentModule;
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentModule is Module m)
            {
                if (m.Ischild)
                {
                    var parent = GetParent(m);

                    if (m.Index == parent.Modules.Count)
                    {
                        return;
                    }

                    var swapModule = parent?.Modules.Find(mo => mo.Index == m.Index + 1);
                    swapModule.Index--;
                    m.Index++;
                }
                else
                {
                    if (m.Index == menu.Modules.Count)
                    {
                        return;
                    }

                    var swapModule = menu.Modules.Find(mo => mo.Index == m.Index + 1);
                    swapModule.Index--;
                    m.Index++;
                }
            }
            else if (currentModule is ModuleCollection mc)
            {
                if (mc.Index == 1)
                {
                    return;
                }

                var swapModuleCollection = menu.ModuleCollections.Find(moc => moc.Index == mc.Index + 1);
                swapModuleCollection.Index--;
                mc.Index++;
            }

            RefreshMenu();
            MenuListBox.SelectedItem = currentModule;
        }

        private void CollectionUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentModule is Module m)
            {
                if (m.Ischild)
                {
                    var parent = GetParent(m);

                    if (parent.Index == 1)
                    {
                        return;
                    }

                    var destinationCollection = menu.ModuleCollections.Find(moc => moc.Index == parent.Index - 1);
                    MoveModuleToAnotherCollection(m, parent, destinationCollection);
                }
                else
                {
                    MoveModuleToCollection(m, menu.LastModuleCollection);
                }
            }

            RefreshMenu();
            MenuListBox.SelectedItem = currentModule;
        }

        private void CollectionDownButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentModule is Module m)
            {
                if (m.Ischild)
                {
                    var parent = GetParent(m);

                    if (parent.Index == menu.LastModuleCollection.Index)
                    {
                        MoveModuleToMenu(m, parent);
                    }
                    else
                    {
                        var destinationCollection = menu.ModuleCollections.Find(moc => moc.Index == parent.Index + 1);
                        MoveModuleToAnotherCollection(m, parent, destinationCollection);
                    }
                }
                else
                {
                    return;
                }
            }

            RefreshMenu();
            MenuListBox.SelectedItem = currentModule;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Setting.Save(menu.ModuleCollections, menu.Modules);
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddModuleButton_Click(object sender, RoutedEventArgs e)
        {
            var module = new Model.Module();
            module.Name = "모듈 " + (menu.Modules.Count + 1);
            module.Index = menu.Modules.Count + 1;
            menu.Modules.Add(module);

            ModulePathGrid.Visibility = Visibility.Visible;
            RefreshMenu();
            MenuListBox.SelectedItem = module;
            ModuleNameText.Focus();
            ModuleNameText.CaretIndex = ModuleNameText.Text.Length;
        }

        private void AddModuleCollectionButton_Click(object sender, RoutedEventArgs e)
        {
            var moduleCollection = new Model.ModuleCollection();
            moduleCollection.Name = "모듈 컬렉션 " + (menu.ModuleCollections.Count + 1);
            moduleCollection.Index = menu.ModuleCollections.Count + 1;
            menu.ModuleCollections.Add(moduleCollection);

            ModulePathGrid.Visibility = Visibility.Collapsed;
            RefreshMenu();
            MenuListBox.SelectedItem = moduleCollection;
            ModuleNameText.Focus();
            ModuleNameText.CaretIndex = ModuleNameText.Text.Length;
        }

        private void MenuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0)
            {
                return;
            }

            currentModule = e.AddedItems[0] as IMenuItem;

            if (currentModule is Module m)
            {
                ModulePathGrid.Visibility = Visibility.Visible;
                ModuleNameText.Text = m.Name;
                ModuleHotKeyText.Text = m.HotKey;
                ModulePathText.Text = m.Path;
                CollectionUpButton.Visibility = Visibility.Visible;
                CollectionDownButton.Visibility = Visibility.Visible;
            }
            else if (currentModule is ModuleCollection mc)
            {
                ModulePathGrid.Visibility = Visibility.Collapsed;
                ModuleNameText.Text = mc.Name;
                ModuleHotKeyText.Text = mc.HotKey;
                CollectionUpButton.Visibility = Visibility.Collapsed;
                CollectionDownButton.Visibility = Visibility.Collapsed;
            }

        }

        private void ModulePathText_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Filter = "exe files (*.exe)|*.exe";
            if (dialog.ShowDialog().Value)
            {
                ModulePathText.Text = dialog.FileName;
            }
        }
    }
}
