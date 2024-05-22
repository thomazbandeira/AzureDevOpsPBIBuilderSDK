using AzureDevOpsUtils;
using AzureDevOpsUtils.Services;
using RtfPipe;
using System.Text;

namespace AzureDevOpsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var test = Encoding.GetEncoding("utf-8");
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
           AzureDevOpsManager manager = new AzureDevOpsManager(new AzureDevOpsService(txtUrlAzureDevOps.Text, txtToken.Text,txtProjeto.Text));
            //

            string[] tokens = null;
            if(!string.IsNullOrWhiteSpace(txtTags.Text))
            {
                tokens = txtTags.Text.Split('|');
            }
            
            var ok = manager.CreateWorkItemAsync(AzureDevOpsUtils.Enums.WorkItemTypeEnum.Task, txtTitulo.Text, RtfPipe.Rtf.ToHtml(rtxtDescricao.Rtf), Rtf.ToHtml(rtxtComentario.Rtf), tokens).ConfigureAwait(false);
        }
    }
}
