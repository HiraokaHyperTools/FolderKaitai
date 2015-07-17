using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FolderKaitai {
    static class Program {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(String[] args) {
            String fp = null;
            bool run = false;
            for (int x = 0; x < args.Length; x++) {
                if ("/e".Equals(args[x])) {
                    x++;
                    if (x < args.Length) {
                        fp = args[x];
                    }
                }
                if ("/r".Equals(args[x])) {
                    x++;
                    if (x < args.Length) {
                        fp = args[x];
                        run = true;
                    }
                }
            }

            if (run) {
                FileInfo fi = new FileInfo(fp);
                run &= (fi.Exists && fi.Length != 0);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (fp != null) Application.Run(run ? (Form)new Form2(fp) : new Form1(fp));
        }
    }
}
