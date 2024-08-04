using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace InjectionViewer
{

    public partial class MainForm : Form
    {
        #region [���������� ��� ����]
        private const int MIN_Y_AXIS = 0;
        private const int MIN_X_AXIS = 0;
        private const int MAX_Y_AXIS = 100;
        private const int MAX_Y2_AXIS = 1500;
        private const int MAX_X_AXIS = 100;
        #endregion


        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }

        private StateForm _state = StateForm.PREPAIRED;

        protected StateForm State
        {
            get
            {
                return _state;
            }
            set
            {
                switch (value)
                {
                    case StateForm.PREPAIRED:
                        DisActiveMenuFormPossibility();
                        ReroizeTextBoxes();
                        ReroizeTextDescriptionChart();
                        InitStateChart();
                        break;
                    case StateForm.CREATEDGRAPH:
                        ActiveMenuFormPossibility();
                        break;
                }
                _state = value;
            }
        }
        #region [����� ��� ���� � ��������]
        protected SKColor _blueColor = new SKColor(25, 118, 210);
        protected SKColor _redColor = new SKColor(229, 57, 53);
        protected SKColor _yellowColor = new SKColor(198, 167, 0);
        protected SKColor _greenColor = new SKColor(0, 171, 0);
        protected SKColor _blackColor = new SKColor(0, 0, 0);
        #endregion

        protected enum StateForm : sbyte
        {
            PREPAIRED,
            CREATEDGRAPH
        }

        protected enum FormatFile : sbyte
        {
            JPG,
            PNG,
            BMP
        }

        private void ActiveMenuFormPossibility()
        {
            formMenuChartSaveJpg.Enabled = true;
            formMenuChartSavePng.Enabled = true;
            formMenuChartSaveBmp.Enabled = true;
            formMenuFormDropState.Enabled = true;
        }

        private void DisActiveMenuFormPossibility()
        {
            formMenuChartSaveJpg.Enabled = false;
            formMenuChartSavePng.Enabled = false;
            formMenuChartSaveBmp.Enabled = false;
            formMenuFormDropState.Enabled = false;
        }

        private void ReroizeTextBoxes()
        {
            timeBegin.Value = DateTime.Now;
            timeEnd.Value = DateTime.Now;
            timeCount.Value = 21;
            pBegin.Text = string.Empty;
            pMiddle.Text = string.Empty;
            pEnd.Text = string.Empty;
            volume.Text = string.Empty;
            volumeInjection.Text = string.Empty;
            name.Text = string.Empty;
            specificWeight.Text = string.Empty;
        }

        private void ReroizeTextDescriptionChart()
        {
            chartName.Text = string.Empty;
            chartDate.Text = string.Empty;
            chartVolume.Text = string.Empty;
        }
        private bool SetState(StateForm state)
        {
            if (state.Equals(State))
                return true;

            var result = MessageBox.Show("�� �������, ��� ������ �������� ��������� �����?", "�������������", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                State = state;
                return true;
            }
            return false;
        }
        public MainForm()
        {
            InitializeComponent();
            InitStateChart();
        }

        public void InitStateChart()
        {
            chart.YAxes = new List<Axis>
            {
                new Axis
                {
                    MinLimit=MIN_Y_AXIS,
                    MaxLimit=MAX_Y2_AXIS,
                    LabelsPaint = new SolidColorPaint(_yellowColor),
                    ShowSeparatorLines = false
                },
                new Axis
                {
                    MinLimit=MIN_Y_AXIS,
                    MaxLimit=MAX_Y_AXIS,
                    LabelsPaint = new SolidColorPaint(_greenColor),
                    ShowSeparatorLines = true,
                    SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray)
                    {
                        StrokeThickness = 2,
                        PathEffect = new DashEffect(new float[] { 3, 3 })
                    }
                },
                new Axis
                {
                    MinLimit=MIN_Y_AXIS,
                    MaxLimit=MAX_Y_AXIS,
                    LabelsPaint = new SolidColorPaint(_blueColor),
                    ShowSeparatorLines = false
                },
                new Axis
                {
                    MinLimit=MIN_Y_AXIS,
                    MaxLimit=MAX_Y_AXIS,
                    LabelsPaint = new SolidColorPaint(_redColor),
                    ShowSeparatorLines = false
                },
            };
            chart.XAxes = new List<Axis>()
                {
                    new Axis
                    {
                        TextSize=10,
                        MinLimit=MIN_X_AXIS,
                        MaxLimit=MAX_X_AXIS,
                        LabelsPaint = new SolidColorPaint(_blackColor),
                        ShowSeparatorLines = true,
                        SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray)
                        {
                            StrokeThickness = 2,
                            PathEffect = new DashEffect(new float[] { 3, 3 })
                        }

                    },
                };
            chart.Series = new List<ISeries>();
        }

        private List<string> GetInterimDates(DateTime startDate, DateTime endDate, int count)
        {
            var interimDates = new List<string>();

            TimeSpan interval = endDate - startDate;
            TimeSpan step = interval / count;

            for (int i = 0; i <= count; i++)
            {
                DateTime intermediateDate = startDate + (step * i);
                interimDates.Add(intermediateDate.ToString("T"));
            }
            return interimDates;
        }

        private List<double> GetInterimDouble(double endDouble, int count, double beginDouble = 0)
        {
            var interimDoubles = new List<double>();

            double interval = endDouble - beginDouble;
            double step = interval / count;

            for (int i = 0; i <= count; i++)
            {
                double intermediateDouble = beginDouble + (step * i);
                interimDoubles.Add(intermediateDouble);
            }
            return interimDoubles;
        }

        private IList<T> SetNewValueInMedium<T>(IList<T> values, T newValue) where T : struct
        {
            var length = values.Count();
            if (length == 0)
                throw new InvalidDataException("��������� ������ ����� ����� �� 1 ��������.");
            else if (length == 1)
                values.Insert(0, newValue);
            else if (length % 2 == 0)
                values.Insert(length / 2 - 1, newValue);
            else if (length % 2 == 1)
                values.Insert(length / 2, newValue);

            return values;
        }

        private ISeries CreateSeries(IEnumerable<double> data, SKColor color, int yAxis)
        {
            return new LineSeries<double>
            {
                Values = new ObservableCollection<double>(data),
                Stroke = new SolidColorPaint(color, 2),
                GeometryStroke = new SolidColorPaint(color, 2),
                Fill = null,
                ScalesYAt = yAxis
            };
        }

        private void SetTextDescriptionChart()
        {
            chartName.Text = name.Text.Trim();
            chartDate.Text = $"����: {timeBegin.Value.ToString("HH:mm:ss dd.MM.yyyy")} / {timeEnd.Value.ToString("HH:mm:ss dd.MM.yyyy")}";
            chartVolume.Text = $"��������� �����: {volume.Text.Trim('0')} �3";
        }

        private void formMenuChartCreate_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("��������� ��� ����������� ���� ��� ���������� �������.", "��������", MessageBoxButtons.OK);
                return;
            }



            if (SetState(StateForm.CREATEDGRAPH))
            {
                chart.XAxes = new List<Axis>()
                {
                    new Axis
                    {
                        UnitWidth=0.1,
                        TextSize=10,
                        Labels=GetInterimDates(timeBegin.Value,timeEnd.Value,(int)timeCount.Value),
                        MinLimit=MIN_X_AXIS,
                        MaxLimit=MAX_X_AXIS,
                        LabelsPaint = new SolidColorPaint(_blackColor),
                        ShowSeparatorLines = true,
                        SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray)
                        {
                            StrokeThickness = 2,
                            PathEffect = new DashEffect(new float[] { 3, 3 })
                        }

                    },
                };

                chart.Series = new ObservableCollection<ISeries>(){
                    CreateSeries(Enumerable.Repeat<double>(double.Parse(specificWeight.Text),(int)timeCount.Value),_yellowColor,0),

                    CreateSeries(GetInterimDouble(double.Parse(volume.Text),(int)timeCount.Value),_greenColor,1),

                    CreateSeries(Enumerable.Repeat<double>(double.Parse(volumeInjection.Text),(int)timeCount.Value),_blueColor,2),

                    CreateSeries(SetNewValueInMedium(GetInterimDouble(double.Parse(pBegin.Text),(int)timeCount.Value,double.Parse(pEnd.Text)),double.Parse(pMiddle.Text)),_redColor,3),
                };

                SetTextDescriptionChart();
            }
        }

        private void SaveScreenshootControl(Control control, FormatFile formatFile)
        {
            Bitmap bmp = new Bitmap(control.Width, control.Height);
            control.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

            var format = string.Empty;
            switch (formatFile)
            {
                case FormatFile.JPG:
                    format = "JPG|*.jpg";
                    break;
                case FormatFile.PNG:
                    format = "PNG|*.png";
                    break;
                case FormatFile.BMP:
                    format = "BMP|*.bmp";
                    break;
                default:
                    format = "BIN|*.bin";
                    break;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = format;
            dialog.Title = "��������� ������";
            dialog.ShowDialog();
            if (dialog.FileName != string.Empty)
            {
                bmp.Save(dialog.FileName);
                MessageBox.Show("������ ������� ��������!");
            }

        }

        private void formMenuChartSaveJpg_Click(object sender, EventArgs e) => SaveScreenshootControl(chartGroup, FormatFile.JPG);

        private void formMenuChartSavePng_Click(object sender, EventArgs e) => SaveScreenshootControl(chartGroup, FormatFile.PNG);

        private void formMenuChartSaveBmp_Click(object sender, EventArgs e) => SaveScreenshootControl(chartGroup, FormatFile.BMP);

        private void formMenuFormDropState_Click(object sender, EventArgs e) => SetState(StateForm.PREPAIRED);

        private bool ValidateTextToDouble(double MaxDouble, string str, double minDouble = 0)
        {
            if (String.IsNullOrWhiteSpace(str))
                return false;

            if (!double.TryParse(str, out double result))
                return false;

            if (result > MaxDouble || result < minDouble)
                return false;

            return true;

        }

        private void DeleteSpace_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
                e.KeyChar = '\0';
        }

        private void pBegin_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateTextToDouble(MAX_Y_AXIS, pBegin.Text, MIN_Y_AXIS))
            {
                validateProvider.SetError(pBegin, $"��������� ������ ���������� ��������� �������� ��������! ����. �� {MIN_Y_AXIS} �� {MAX_Y_AXIS}");
                e.Cancel = true;
            }
            else
                validateProvider.SetError(pBegin, "");
        }

        private void pMiddle_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateTextToDouble(MAX_Y_AXIS, pMiddle.Text, MIN_Y_AXIS))
            {
                validateProvider.SetError(pMiddle, $"��������� ������ ���������� ������� �������� ��������! ����. �� {MIN_Y_AXIS} �� {MAX_Y_AXIS}");
                e.Cancel = true;
            }
            else
                validateProvider.SetError(pMiddle, "");
        }

        private void pEnd_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateTextToDouble(MAX_Y_AXIS, pEnd.Text, MIN_Y_AXIS))
            {
                validateProvider.SetError(pEnd, $"��������� ������ ���������� �������� �������� ��������! ����. �� {MIN_Y_AXIS} �� {MAX_Y_AXIS}");
                e.Cancel = true;
            }
            else
                validateProvider.SetError(pEnd, "");
        }

        private void volume_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateTextToDouble(MAX_Y_AXIS, volume.Text, MIN_Y_AXIS))
            {
                validateProvider.SetError(volume, $"��������� ������ ���������� �������� ������! ����. �� {MIN_Y_AXIS} �� {MAX_Y_AXIS}");
                e.Cancel = true;
            }
            else
                validateProvider.SetError(volume, "");
        }

        private void volumeInjection_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateTextToDouble(MAX_Y_AXIS, volumeInjection.Text, MIN_Y_AXIS))
            {
                validateProvider.SetError(volumeInjection, $"��������� ������ ���������� �������� ������ �������! ����. �� {MIN_Y_AXIS} �� {MAX_Y_AXIS}");
                e.Cancel = true;
            }
            else
                validateProvider.SetError(volumeInjection, "");
        }

        private void specificWeight_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateTextToDouble(MAX_Y2_AXIS, specificWeight.Text, MIN_Y_AXIS))
            {
                validateProvider.SetError(specificWeight, $"��������� ������ ���������� �������� ��������� ����! ����. �� {MIN_Y_AXIS} �� {MAX_Y2_AXIS}");
                e.Cancel = true;
            }
            else
                validateProvider.SetError(specificWeight, "");
        }

        private void name_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(name.Text))
            {
                validateProvider.SetError(name, "��������� ������ ������������ ������� ���������!");
                e.Cancel = true;
            }
            else
                validateProvider.SetError(name, "");
        }

        private void timeEnd_Validating(object sender, CancelEventArgs e)
        {
            if (timeEnd.Value < timeBegin.Value)
            {
                validateProvider.SetError(timeEnd, "�������� ����� ������ ���� ������ ����������!");
                e.Cancel = true;
            }
            else
                validateProvider.SetError(timeEnd, "");
        }

        private void timeBegin_Validating(object sender, CancelEventArgs e)
        {
            if (timeEnd.Value < timeBegin.Value)
            {
                validateProvider.SetError(timeBegin, "��������� ����� ������ ���� ������ ���������!");
                e.Cancel = true;
            }
            else
                validateProvider.SetError(timeBegin, "");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
