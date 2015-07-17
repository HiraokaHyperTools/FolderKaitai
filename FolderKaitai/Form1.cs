using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FolderKaitai {
    public partial class Form1 : Form {
        String fp;

        public Form1(String fp) {
            InitializeComponent();

            this.fp = fp;
        }

        private void bSave_Click(object sender, EventArgs e) {
            tFolderKaitaiBindingSource.EndEdit();
            if (!ValidateChildren()) return;

            ds1.AcceptChanges();
            ds1.WriteXml(fp);
            MessageBox.Show(this, "保存しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripContainer1_Click(object sender, EventArgs e) {

        }

        private void Form1_Load(object sender, EventArgs e) {
            FileInfo fi = new FileInfo(fp);
            if (fi.Exists && fi.Length != 0) {
                DS1 tmp = new DS1();
                tmp.ReadXml(fp);
                ds1.Merge(tmp);
            }
            if (ds1.TFolderKaitai.Select().Length == 0)
                ds1.TFolderKaitai.AddTFolderKaitaiRow((String)null, null);
            foreach (DataRow dr in ds1.TFolderKaitai.Select()) {
                foreach (DataColumn dc in ds1.TFolderKaitai.Columns) {
                    if (dr[dc] is DBNull)
                        dr[dc] = dc.DefaultValue;
                }
            }
            ds1.AcceptChanges();
        }

        private void bRef_Click(object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "フォルダを選択してください。";
            fbd.SelectedPath = tbDir.Text;
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                tbDir.Text = fbd.SelectedPath;
            }
        }

        private void bRun_Click(object sender, EventArgs e) {
            if (!NeedSave())
                return;

            using (Form2 form = new Form2(fp)) {
                form.ShowDialog();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            tbPat.Text = "^DOC[0-9]{6}$";
            tbPat.DataBindings["Text"].WriteValue();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            tbPat.Text = "^[0-9]{14}$";
            tbPat.DataBindings["Text"].WriteValue();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = !NeedSave();
        }

        bool NeedSave() {
            if (!ValidateChildren())
                return false;
            if (ds1.HasChanges()) {
                switch (MessageBox.Show(this, "変更されています。保存?", Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)) {
                    case System.Windows.Forms.DialogResult.Yes:
                        bSave_Click(bSave, EventArgs.Empty);
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        ds1.RejectChanges();
                        break;
                    default:
                        return false;
                }
            }
            return true;
        }
    }
}
