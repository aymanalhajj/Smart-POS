using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Smart_POS
{
    internal class Utils
    {
        static public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        static public void OpenPdfBytes(byte[] pdfBytes, string fileNameHint = "report")
        {
            var path = Path.Combine(Path.GetTempPath(), $"{fileNameHint}_{Guid.NewGuid():N}.pdf");
            File.WriteAllBytes(path, pdfBytes);
            Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
        }
    }
}
