using HyperEmpoloyees.Code.Models;
using HyperEmpoloyees.Data.EF;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;


namespace HyperEmpoloyees.Gui.HomeGui
{
    public partial class HomeUserControl : UserControl
    {
        private static HomeUserControl? homeUserControl;
        public HomeUserControl()
        {
            InitializeComponent();
            labelWelcome.Text = $"Добро пожаловать, {LocalUser.FullName}";
            labelCompanyName.Text = Properties.Settings.Default.CompanyName;

            this.Load += HomeUserControl_Load;
            LoadSalaryByJobChart();
        }

        public static HomeUserControl Instance()
        {
            return homeUserControl ?? (homeUserControl = new HomeUserControl());
        }
        #region events
        private void HomeUserControl_Load(object sender, EventArgs e)
        {
            RefreshCharts();
        }
        #endregion
        #region Methods
        private void LoadSalaryByJobChart()
        {
            using var dbContext = new HyperEmpoloyeesDbContext();

            var data = dbContext.Employees
                .GroupBy(e => e.JobTitle)
                .Select(g => new
                {
                    Job = g.Key,
                    AvgSalary = g.Average(x => x.CurrentSalary)
                })
                .ToList();
            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Средняя зарплата",
                    Values = new ChartValues<double>(data.Select(x =>(double) x.AvgSalary))
                }
            };
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Должность",
                Labels = data.Select(x => x.Job).ToArray()
            });

            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Зарплата"
            });
        }

        private void LoadEmployeeStatusChart()
        {
            using var dbContext = new HyperEmpoloyeesDbContext();

            int active = dbContext.Employees.Count(e => e.EmploymentState == "Активен");
            int onLeave = dbContext.Employees.Count(e => e.EmploymentState == "В отпуске");

            pieChart1.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Активен",
                    Values = new ChartValues<int> { active },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "В отпуске",
                    Values = new ChartValues<int> { onLeave },
                    DataLabels = true
                }
            };
        }

        public void RefreshCharts()
        {
            LoadSalaryByJobChart();
            LoadEmployeeStatusChart();

            cartesianChart1.Update(true, true);
            pieChart1.Update(true, true);
        }
        #endregion
    }
}
