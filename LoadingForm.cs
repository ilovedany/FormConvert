
namespace FormConvert
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
            Shown += LoadingFormAsync; //������� ������ ����������� 
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

                await wrapper.ViewSelectionMethod(1, @"path to xml", @"path to xlsx", true, true); //�������� ���������
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������: {ex.Message}");
                this.Close();
            }
        }


    }
}
