
namespace FormConvert
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
            Shown += LoadingFormAsync; //событие показа загрузочной формы

        }
        private async void LoadingFormAsync(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value = 0;

                var wrapper = new ViewSelection(progress => Invoke(new MethodInvoker(() =>
                {
                    progressBar1.Value = progress;
                    label2.Text = $"{progress.ToString()}%";
                })));

                await wrapper.ViewSelectionMethod(1, @"C:\XmlFiles\Смена профессии.xml", @"C:\XmlFiles\dan4ikkrasava.xlsx", false, true);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                this.Close();
            }
        }


    }
}
