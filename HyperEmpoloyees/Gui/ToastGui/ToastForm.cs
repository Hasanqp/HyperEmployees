namespace HyperEmpoloyees.Gui.ToastGui
{
    public partial class ToastForm : Form
    {
        private static ToastForm? toastForm;
        private string _title;
        private string _description;
        public ToastForm()
        {
            InitializeComponent();
        }
        #region events
        private void timerToast_Tick(object sender, EventArgs e)
        {
            this.Hide();
            timerToast.Enabled = false;
        }
        #endregion
        #region Methods
        public static ToastForm Instance(string title, string description)
        {
            if (toastForm == null || toastForm.IsDisposed)
            {
                toastForm = new ToastForm();
            }

            toastForm.SetData(title, description);
            return toastForm;
        }

        private void SetData(string title, string description)
        {
            _title = title;
            _description = description;

            labelTitle.Text = _title;
            labelDescription.Text = _description;

            timerToast.Stop();
            timerToast.Interval = Properties.Settings.Default.ToastDuration;
            timerToast.Start();
        }
        #endregion
    }
}
