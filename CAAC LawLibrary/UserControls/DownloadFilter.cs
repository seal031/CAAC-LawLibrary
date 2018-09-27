﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAAC_LawLibrary.Utity;

namespace CAAC_LawLibrary
{
    public partial class DownloadFilter : BaseFilter
    {
        public Form parentForm;

        private bool bindState = false;
        public DownloadFilter()
        {
            InitializeComponent();
        }

        private void btn_manageTask_Click(object sender, EventArgs e)
        {
            menu.Show(btn_manageTask, 0, 20);
        }

        private void cb_downloadState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bindState)
            {
                ((LibraryList)parentForm).downloadPicker(cbb_downloadState.SelectedValue.ToString());
            }
        }

        private void DownloadFilter_Load(object sender, EventArgs e)
        {
            cbb_downloadState.DataSource = new BindingSource(Global.DownloadState, null);
            cbb_downloadState.DisplayMember = "Value";
            cbb_downloadState.ValueMember = "Key";
            bindState = true;
        }

        private void ckb_selectAll_CheckedChanged(object sender, EventArgs e)
        {
            ((LibraryList)parentForm).downloadCheckBoxChange();
        }
    }
}
