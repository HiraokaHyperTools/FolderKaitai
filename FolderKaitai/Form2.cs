using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FolderKaitai {
    public partial class Form2 : Form {
        String fp;

        public Form2(String fp) {
            InitializeComponent();

            this.fp = fp;
        }

        private void Form2_Load(object sender, EventArgs e) {
            bwRun.RunWorkerAsync();
        }

        private void bwRun_DoWork(object sender, DoWorkEventArgs e) {
            DS1 ds1 = new DS1();
            DS1 tmp = new DS1();
            tmp.ReadXml(fp);
            ds1.Merge(tmp);

            foreach (DS1.TFolderKaitaiRow row in ds1.TFolderKaitai.Select()) {
                Regex rex = new Regex(row.Pat, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (String dir in Directory.GetDirectories(row.Dir)) {
                    if (bwRun.CancellationPending) throw new ApplicationException("キャンセルしました。");
                    if (rex.IsMatch(Path.GetFileName(dir))) {
                        String fpx = Path.Combine(dir, "Thumbs.db");
                        if (File.Exists(fpx))
                            File.Delete(fpx);
                        foreach (String fp1 in Directory.GetFiles(dir)) {
                            if (bwRun.CancellationPending) throw new ApplicationException("キャンセルしました。");
                            int x = 0, cx = 1000;
                            for (; x < cx; x++) {
                                String suffix = (x == 0) ? "" : "~" + x;
                                String fp2 = Path.Combine(row.Dir, Path.GetFileNameWithoutExtension(fp1) + suffix + Path.GetExtension(fp1));
                                if (File.Exists(fp2)) continue;
                                File.Move(fp1, fp2);
                                break;
                            }
                        }
                        Directory.Delete(dir);
                    }
                }
            }
        }

        private void bwRun_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            lWip.Hide();
            if (e.Error == null) {
                lDone.Show();
            }
            else {
                lErr.Show();
                lErr.Text += e.Error + "";
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e) {
            bwRun.CancelAsync();
        }
    }
}
