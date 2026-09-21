using System.Globalization;
using Backend;

namespace Frontend.Windows
{
    public partial class Form1 : Form
    {
        private bool showingResult = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSymbol_Click(object sender, EventArgs e)
        {
            if (showingResult)
            {
                txtDisplay.Text = string.Empty;
                showingResult = false;
            }
            txtDisplay.Text += ((Button)sender).Text;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (showingResult)
            {
                txtDisplay.Text = string.Empty;
                showingResult = false;
                return;
            }
            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text[..^1];
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = string.Empty;
            showingResult = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (showingResult)
            {
                return;
            }
            var expression = txtDisplay.Text;
            try
            {
                var result = ExpressionEvaluator.Evalute(expression);
                txtDisplay.Text = $"{expression}={result.ToString(CultureInfo.InvariantCulture)}";
                showingResult = true;
                // scroll so a long result stays visible
                txtDisplay.SelectionStart = txtDisplay.Text.Length;
                txtDisplay.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
