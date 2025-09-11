using Smart_POS.Models;
using Smart_POS.Validators;
using Smart_POS.ViewModels;
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Smart_POS.Repository;

namespace Smart_POS
{
    /// <summary>
    /// Interaction logic for AddEditAccountsPage.xaml
    /// </summary>
    public partial class AddEditAccountsPage : Window
    {
        AccAccountsViewModel viewModel;
        public AddEditAccountsPage()
        {
            InitializeComponent();
            LoadView();
            viewModel = (AccAccountsViewModel)LayoutRoot.DataContext;
            //viewModel.ValidateCallback += new AccAccountsViewModel.ValidateCallbackEventHandler(ValidateForm);
        }
        private void LoadView()
        {
            TestData data = new TestData();
            data.Load();
            GroupView.ItemsSource = data.Groups;
        }
        public bool ValidateForm()
        {
            var valid = Validator.IsValid(this);
            if (!valid)
            {
                MessageBox.Show("عذرا، يجب التاكد من اكمال ادخال البيانات");
            }
            return valid;
        }
    }
    public class Entry
    {
        public decimal Key { get; set; }
        public string Name { get; set; }
    }
    public class Group
    {
        public decimal Key { get; set; }
        public string Name { get; set; }
        //public IList<object> Items
        //{
        //    get
        //    {
        //        IList<object> childNodes = new List<object>();
        //        foreach (var group in this.SubGroups)
        //            childNodes.Add(group);
        //        foreach (var entry in this.Entries)
        //            childNodes.Add(entry);

        //        return childNodes;
        //    }
        //}
        public IEnumerable<object> Items
        {
            get
            {
                foreach (var group in this.SubGroups)
                    yield return group;
                foreach (var entry in this.Entries)
                    yield return entry;
            }
        }
        public IList<Group> SubGroups { get; set; }
        public IList<Entry> Entries { get; set; }
    }
    public class TestData
    {
        public TestData()
        {
            repo = new AccAccountsRepo();
            InitLists();
        }
        private AccAccountsRepo repo { get; set; }
        public ObservableCollection<TreeAccountsListItemModel> _TreeListItems;
        public ObservableCollection<TreeAccountsListItemModel> TreeListItems
        {
            get
            {
                return _TreeListItems;
            }
            set
            {
                _TreeListItems = value;
            }
        }
        public void InitLists()
        {
            TreeListItems = repo.GetAllAccounts();
        }
        public IList<Group> Groups = new List<Group>();
        public List<object> ValParent = new List<object>();
        public List<object> ValChild = new List<object>();
        public List<object> ValChild2 = new List<object>();
        public List<object> ValChild3 = new List<object>();
        public void Load()
        {
            Group grp1;
            Group grp2;
            Group grp3;
            Group grp4;
            //grp1 = new Group() { Key = 1, Name = "", SubGroups = new List<Group>(), Entries = new List<Entry>() };
            //grp2 = new Group() { Key = 1, Name = "", SubGroups = new List<Group>(), Entries = new List<Entry>() };
            //grp3 = new Group() { Key = 1, Name = "", SubGroups = new List<Group>(), Entries = new List<Entry>() };
            //grp4 = new Group() { Key = 1, Name = "", SubGroups = new List<Group>(), Entries = new List<Entry>() };
            for (int j = 0; j < TreeListItems.Count; j++)
            {
                if (Convert.ToInt64(TreeListItems[j].Level) == 1 && TreeListItems[j].ParentId == null)
                {
                    ValParent.Add(TreeListItems[j].Value);
                }
            }
            for (int a = 0; a < ValParent.Count; a++)
            {
                //for (int i = 0; i < TreeListItems.Count; i++)
                //{
                //    if (Convert.ToInt64(TreeListItems[i].Level) == 1 && TreeListItems[i].ParentId == null)
                //    {
                //        grp1 = new Group() { Key = Convert.ToInt64(TreeListItems[i].Value), Name = TreeListItems[i].Title, SubGroups = new List<Group>(), Entries = new List<Entry>() };
                //    }
                //    if (Convert.ToInt64(TreeListItems[i].ParentId) == Convert.ToInt64(ValParent[a]))
                //    {
                //        grp2 = new Group() { Key = Convert.ToInt64(TreeListItems[i].Value), Name = TreeListItems[i].Title, SubGroups = new List<Group>(), Entries = new List<Entry>() };
                //        ValChild.Add(TreeListItems[i].Value);
                //    }
                //    for (int b = 0; b < ValChild.Count; b++)
                //    {
                //        for (int l = 0; l < TreeListItems.Count; l++)
                //        {
                //            if (Convert.ToInt64(TreeListItems[l].ParentId) == Convert.ToInt64(ValChild[b]))
                //            {
                //                grp3 = new Group() { Key = Convert.ToInt64(TreeListItems[l].Value), Name = TreeListItems[l].Title, SubGroups = new List<Group>(), Entries = new List<Entry>() };
                //                ValChild2.Add(TreeListItems[l].Value);
                //            }
                //            for (int c = 0; c < ValChild2.Count; c++)
                //            {
                //                for (int m = 0; m < TreeListItems.Count; m++)
                //                {
                //                    if (Convert.ToInt64(TreeListItems[m].ParentId) == Convert.ToInt64(ValChild2[c]))
                //                    {
                //                        grp4 = new Group() { Key = Convert.ToInt64(TreeListItems[m].Value), Name = TreeListItems[m].Title, SubGroups = new List<Group>(), Entries = new List<Entry>() };
                //                        ValChild3.Add(TreeListItems[m].Value);
                //                    }
                //                    for (int d = 0; d < ValChild3.Count; d++)
                //                    {
                //                        for (int n = 0; n < TreeListItems.Count; n++)
                //                        {
                //                            if (Convert.ToInt64(TreeListItems[n].ParentId) == Convert.ToInt64(ValChild3[d]) && Convert.ToInt64(TreeListItems[n].Level) == 5)
                //                            {
                //                                grp4.Entries.Add(new Entry() { Key = Convert.ToInt64(TreeListItems[n].Value), Name = TreeListItems[n].Title });
                //                            }
                //                        }
                //                    }
                //                }
                //            }
                //        }
                //    }
                //}
                //grp3.SubGroups.Add(grp4);
                //grp2.SubGroups.Add(grp3);
                //grp1.SubGroups.Add(grp2);

                //Groups.Add(grp1);
            }

            grp1 = new Group() { Key = 1, Name = "الاصول", SubGroups = new List<Group>(), Entries = new List<Entry>() };
            //grp2 = new Group() { Key = 2, Name = "الاصول الثابتة", SubGroups = new List<Group>(), Entries = new List<Entry>() };
            grp2 = new Group() { Key = 2, Name = "الاصول المتداولة", SubGroups = new List<Group>(), Entries = new List<Entry>() };
            grp3 = new Group() { Key = 3, Name = "المصروفات", SubGroups = new List<Group>(), Entries = new List<Entry>() };
            grp4 = new Group() { Key = 4, Name = "الايرادات", SubGroups = new List<Group>(), Entries = new List<Entry>() };
            //Group grp5 = new Group() { Key = 4, Name = "Group 5", SubGroups = new List<Group>(), Entries = new List<Entry>() };

            grp4.Entries.Add(new Entry() { Key=12, Name = "الصندوق الرئيسي" });

            //grp1
            //grp1.Entries.Add(new Entry() { Key=1, Name="Entry number 1" });
            //grp1.Entries.Add(new Entry() { Key=2, Name="Entry number 2" });
            //grp1.Entries.Add(new Entry() { Key=3, Name="Entry number 3" });

            //grp2
            grp2.Entries.Add(new Entry() { Key=4, Name = "Entry number 4" });
            //grp2.Entries.Add(new Entry() { Key=5, Name = "Entry number 5" });
            //grp2.Entries.Add(new Entry() { Key=6, Name = "Entry number 6" });

            //grp3
            //grp3.Entries.Add(new Entry() { Key=7, Name = "Entry number 7" });
            //grp3.Entries.Add(new Entry() { Key=8, Name = "Entry number 8" });
            //grp3.Entries.Add(new Entry() { Key=9, Name = "Entry number 9" });

            //grp4
            grp4.Entries.Add(new Entry() { Key=10, Name = "Entry number 10" });
            //grp4.Entries.Add(new Entry() { Key=11, Name = "Entry number 11" });
            //grp4.Entries.Add(new Entry() { Key=12, Name = "Entry number 12" });

            //grp4.SubGroups.Add(grp5);
            grp3.SubGroups.Add(grp4);
            grp2.SubGroups.Add(grp3);
            grp1.SubGroups.Add(grp2);

            Groups.Add(grp1);
            //Groups.Add(grp1);
        }
    }
}
