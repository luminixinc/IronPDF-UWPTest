
using PDFPrinterLib;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.System;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace IronPDF_UWPTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // Run IronPDF "Hello World" test ...
            _ = RunIronPDFTest();
        }

        async Task RunIronPDFTest()
        {
            var baseFolder = ApplicationData.Current.LocalFolder;
            var basePath = baseFolder.Path;

            var bytes = PDFPrinter.GetPDFData(html: "<html>Hello World</html>", baseurl: basePath);

            StorageFile pdfFile = await baseFolder.CreateFileAsync("test.pdf", CreationCollisionOption.ReplaceExisting);
            using (var stream = await pdfFile.OpenStreamForWriteAsync())
            {
                await stream.WriteAsync(bytes, 0, bytes.Length);
            }

            await Launcher.LaunchFileAsync(pdfFile);
        }
    }
}
