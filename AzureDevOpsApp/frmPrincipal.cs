using AzureDevOps.Model.Enum;
using AzureDevOpsUtils;
using AzureDevOpsUtils.Services;
using RtfPipe;
using System.Text;

namespace AzureDevOpsApp
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
           AzureDevOpsManager manager = new AzureDevOpsManager(new AzureDevOpsService(txtUrlAzureDevOps.Text, txtToken.Text,txtProjeto.Text));
            

            string[] tags = new string[0];
            if(!string.IsNullOrWhiteSpace(txtTags.Text))
            {
                tags = txtTags.Text.Split('|');
            }
            
            var ok = manager.CreateWorkItemAsync(WorkItemTypeEnum.Task, txtTitulo.Text, RtfPipe.Rtf.ToHtml(rtxtDescricao.Rtf), Rtf.ToHtml(rtxtComentario.Rtf), tags).ConfigureAwait(false);
        }
    }
}
