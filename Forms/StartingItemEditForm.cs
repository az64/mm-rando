using MMRando.Extensions;
using MMRando.Utils;
using MMRando.GameObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMRando.Models.Settings;

namespace MMRando.Forms
{
    public partial class StartingItemEditForm : Form
    {
        private readonly List<Item> _startingItems;
        private readonly SettingsObject _settings;
        private bool updating = false;
        private const int ItemGroupCount = 3;

        public string ExternalLabel { get; private set; }

        public StartingItemEditForm(SettingsObject settings)
        {
            InitializeComponent();

            _settings = settings;
            _startingItems = ItemUtils.StartingItems().Where(item => !item.Name().Contains("Heart")).ToList();

            foreach (var item in _startingItems)
            {
                lStartingItems.Items.Add(item.Name());
            }

            if (_settings.CustomStartingItemList != null)
            {
                UpdateString(_settings.CustomStartingItemList);
                ExternalLabel = $"{_settings.CustomStartingItemList.Count}/{_startingItems.Count} items selected";
            }
            else
            {
                tStartingItemsString.Text = "--";
            }
        }

        private void StartingItemEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void UpdateString(List<Item> selections)
        {
            int[] n = new int[3];
            string[] ns = new string[3];
            foreach (var item in selections)
            {
                var i = _startingItems.IndexOf(item);
                int j = i / 32;
                int k = i % 32;
                n[j] |= (int)(1 << k);
                ns[j] = Convert.ToString(n[j], 16);
            }
            tStartingItemsString.Text = ns[2] + "-" + ns[1] + "-" + ns[0];
            _settings.CustomStartingItemListString = tStartingItemsString.Text;
        }

        public void UpdateChecks(string c)
        {
            updating = true;
            try
            {
                tStartingItemsString.Text = c;
                _settings.CustomStartingItemListString = c;
                _settings.CustomStartingItemList.Clear();
                string[] v = c.Split('-');
                int[] vi = new int[ItemGroupCount];
                if (v.Length != vi.Length)
                {
                    ExternalLabel = "Invalid custom starting item string";
                    return;
                }
                for (int i = 0; i < ItemGroupCount; i++)
                {
                    if (v[ItemGroupCount - 1 - i] != "")
                    {
                        vi[i] = Convert.ToInt32(v[ItemGroupCount - 1 - i], 16);
                    }
                }
                for (int i = 0; i < 32 * ItemGroupCount; i++)
                {
                    int j = i / 32;
                    int k = i % 32;
                    if (((vi[j] >> k) & 1) > 0)
                    {
                        if (i >= ItemUtils.AllLocations().Count())
                        {
                            throw new IndexOutOfRangeException();
                        }
                        _settings.CustomStartingItemList.Add(_startingItems[i]);
                    }
                }
                foreach (ListViewItem l in lStartingItems.Items)
                {
                    if (_settings.CustomStartingItemList.Contains(_startingItems[l.Index]))
                    {
                        l.Checked = true;
                    }
                    else
                    {
                        l.Checked = false;
                    }
                }
                ExternalLabel = $"{_settings.CustomStartingItemList.Count}/{_startingItems.Count} items selected";
            }
            catch
            {
                _settings.CustomStartingItemList.Clear();
                ExternalLabel = "Invalid custom starting item string";
            }
            finally
            {
                updating = false;
            }
        }

        private void tStartingItemsString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                UpdateChecks(tStartingItemsString.Text);
            }
        }

        private void lStartingItems_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (updating)
            {
                return;
            }
            updating = true;
            if (e.Item.Checked)
            {
                _settings.CustomStartingItemList.Add(_startingItems[e.Item.Index]);
            }
            else
            {
                _settings.CustomStartingItemList.Remove(_startingItems[e.Item.Index]);
            }
            UpdateString(_settings.CustomStartingItemList);
            updating = false;
        }
    }
}
