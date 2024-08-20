using LiveChartsCore;
using LiveChartsCore.Drawing;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using Padding = LiveChartsCore.Drawing.Padding;

namespace InjectionViewer
{

    public partial class MainForm : Form
    {
        #region [Экстремумы для осей]
        private const int MIN_Y_AXIS = 0;
        private const int MIN_X_AXIS = 0;
        private const int MAX_Y_AXIS = 100;
        private const int MAX_Y2_AXIS = 1500;
        private int MAX_X_AXIS = 21;
        #endregion


        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }

        protected static class TypeSeries
        {
            public const string SPECIFIC_WEIGHT = "Pкг/м3";
            public const string VOLUME = "Qсум(м3)";
            public const string VOLUME_INJECTION = "Qмгн(л/сек)";
            public const string P = "Pнап(МПа)";
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
                        DisActiveFormControlPossibility();
                        ReroizeTextBoxes();
                        ReroizeTextDescriptionChart();
                        UnSubscribeEventForm();
                        InitStateChart();
                        break;
                    case StateForm.CREATEDGRAPH:
                        ActiveFormControlPossibility();
                        SubscribeEventForm();
                        break;
                }
                _state = value;
            }
        }
        #region [Цвета для осей и графиков]
        protected SKColor _blueColor = new SKColor(25, 118, 210);
        protected SKColor _redColor = new SKColor(229, 57, 53);
        protected SKColor _vinousColor = new SKColor(145, 0, 72);
        protected SKColor _greenColor = new SKColor(0, 171, 0);
        protected SKColor _blackColor = new SKColor(0, 0, 0);
        #endregion

        protected enum StateForm : sbyte
        {
            PREPAIRED,
            CREATEDGRAPH
        }

        private void ActiveFormControlPossibility()
        {
            formMenuChartSaveA4.Enabled = true;
            formMenuFormDropState.Enabled = true;
            typeSeriesSelect.Enabled = true;
        }

        private void DisActiveFormControlPossibility()
        {
            formMenuChartSaveA4.Enabled = false;
            formMenuFormDropState.Enabled = false;
            typeSeriesSelect.Enabled = false;
        }

        private void ReroizeTextBoxes()
        {
            timeBegin.Value = DateTime.Now;
            timeEnd.Value = DateTime.Now;
            timeCount.Value = 21;
            pBegin.Text = string.Empty;
            pEnd.Text = string.Empty;
            volume.Text = string.Empty;
            volumeInjection.Text = string.Empty;
            name.Text = string.Empty;
            specificWeight.Text = string.Empty;
            typeSeriesSelect.SelectedItem = null;
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

            var result = MessageBox.Show("Вы уверены, что хотите изменить состояние формы?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                State = state;
                return true;
            }
            return false;
        }

        private void SubscribeEventForm()
        {
            chart.MouseDown += chart_MouseClick;
        }

        private void UnSubscribeEventForm()
        {
            chart.MouseDown -= chart_MouseClick;
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
                    TextSize=14,
                    Padding=new Padding(10,0),
                    LabelsPaint = new SolidColorPaint(_vinousColor),
                    ShowSeparatorLines = false
                },
                new Axis
                {
                    MinLimit=MIN_Y_AXIS,
                    MaxLimit=MAX_Y_AXIS,
                    LabelsPaint = new SolidColorPaint(_greenColor),
                    TextSize=14,
                    Padding=new Padding(10,0),
                    ShowSeparatorLines = true,
                    SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray)
                    {
                        StrokeThickness = 2,
                        PathEffect = new DashEffect(new float[] { 3, 3 })
                    },
                },
                new Axis
                {
                    MinLimit=MIN_Y_AXIS,
                    MaxLimit=MAX_Y_AXIS,
                    TextSize=14,
                    Padding=new Padding(10,0),
                    LabelsPaint = new SolidColorPaint(_blueColor),
                    ShowSeparatorLines = false
                },
                new Axis
                {
                    MinLimit=MIN_Y_AXIS,
                    MaxLimit=MAX_Y_AXIS,
                    TextSize=14,
                    Padding=new Padding(10,0),
                    LabelsPaint = new SolidColorPaint(_redColor),
                    ShowSeparatorLines = false
                },
            };
            chart.XAxes = new List<Axis>()
                {
                    new Axis
                    {
                        CustomSeparators=new List<double>(),
                    },
                };
            chart.Series = new List<ISeries>();
        }

        private void chart_MouseClick(object? sender, MouseEventArgs e)
        {
            string? typeSeries = typeSeriesSelect.SelectedItem?.ToString();

            if (typeSeries == null)
            {
                MessageBox.Show("Выбранная линия является невалидной.");
                return;
            }
            ISeries? series = chart.Series.ToList().FirstOrDefault(s => s.Name == typeSeries);

            if (series == null)
            {
                MessageBox.Show("Линия с выбранным именем отсутствует на графике.");
                return;
            }

            LvcPointD coordinatePoint = chart.ScalePixelsToData(new LvcPointD(e.X, e.Y), 0, typeSeriesSelect.SelectedIndex);

            if (coordinatePoint.X < 0)
                return;

            int coordinateIntX = (int)chart.GetPointsAt(new LvcPoint(e.X, e.Y)).First().Coordinate.SecondaryValue;

            var values = series.Values.Cast<double>().ToList();
            values[coordinateIntX] = coordinatePoint.Y;
            series.Values = values;
        }

        private List<string> GetInterimDates(DateTime startDate, DateTime endDate, int count)
        {
            var interimDates = new List<string>();

            TimeSpan interval = endDate - startDate;
            TimeSpan step = interval / (count - 1);

            for (int i = 0; i < count; i++)
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
            double step = interval / (count - 1);

            for (int i = 0; i < count; i++)
            {
                double intermediateDouble = beginDouble + (step * i);
                interimDoubles.Add(intermediateDouble);
            }
            return interimDoubles;
        }

        private ISeries CreateSeries(IEnumerable<double> data, SKColor color, int yAxis, string name = "")
        {
            return new LineSeries<double>
            {
                Name = name,
                Values = new ObservableCollection<double>(data),
                Stroke = new SolidColorPaint(color, 2),
                GeometryStroke = null,
                GeometryFill = null,
                Fill = null,
                ScalesYAt = yAxis,
                LineSmoothness = 0
            };
        }

        private void SetTextDescriptionChart()
        {
            chartName.Text = name.Text.Trim();
            chartDate.Text = $"Дата: {timeBegin.Value.ToString("HH:mm:ss dd.MM.yyyy")} / {timeEnd.Value.ToString("HH:mm:ss dd.MM.yyyy")}";
            chartVolume.Text = $"Суммарный объём: {volume.Text.Trim()} м3";
        }

        private void formMenuChartCreate_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Заполните все необходимые поля для построения графика.", "Проверка", MessageBoxButtons.OK);
                return;
            }



            if (SetState(StateForm.CREATEDGRAPH))
            {
                #region [Значения полей управления]
                var timeBeginVar = timeBegin.Value;
                var timeEndVar = timeEnd.Value;
                var specificWeightVar = double.Parse(specificWeight.Text);
                var timeCountVar = MAX_X_AXIS;
                var volumeVar = double.Parse(volume.Text);
                var volumeInjectionVar = double.Parse(volumeInjection.Text);
                var pBeginVar = double.Parse(pBegin.Text);
                var pEndVar = double.Parse(pEnd.Text);
                #endregion

                #region [Списки значений с заданными диапазонами]
                var timeList = GetInterimDates(timeBeginVar, timeEndVar, timeCountVar);
                var specificWeightList = Enumerable.Repeat<double>(specificWeightVar, timeCountVar);
                var volumeList = GetInterimDouble(volumeVar, timeCountVar);
                var volumeInjectionList = Enumerable.Repeat<double>(volumeInjectionVar, timeCountVar);
                var pList = GetInterimDouble(pEndVar, timeCountVar, pBeginVar);
                #endregion


                chart.XAxes = new List<Axis>()
                {
                    new Axis
                    {
                        TextSize=16,
                        Labels=timeList,
                        MinLimit=MIN_X_AXIS,
                        MaxLimit=timeCountVar - 1,
                        LabelsPaint = new SolidColorPaint(_blackColor),
                        ShowSeparatorLines = true,
                        SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray)
                        {
                            StrokeThickness = 2,
                            PathEffect = new DashEffect(new float[] { 3, 3 })
                        },
                        Padding=new Padding(0,10),
                    },
                };


                chart.Series = new ObservableCollection<ISeries>(){
                    CreateSeries(specificWeightList,_vinousColor,0, TypeSeries.SPECIFIC_WEIGHT),

                    CreateSeries(volumeList,_greenColor,1,TypeSeries.VOLUME),

                    CreateSeries(volumeInjectionList,_blueColor,2,TypeSeries.VOLUME_INJECTION),

                    CreateSeries(pList,_redColor,3, TypeSeries.P),
                };

                SetTextDescriptionChart();
            }
        }

        private void SaveScreenshootControl(Control control)
        {
            Bitmap bmp = new Bitmap(control.Width, control.Height);
            control.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            Size size = new Size(3508, 2480);
            bmp = ResizeBitmap(bmp, size);


            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JPG|*.jpg|PNG|*.png|BMP|*.bmp";
            dialog.Title = "Сохранить график";
            dialog.ShowDialog();
            if (dialog.FileName != string.Empty)
            {
                bmp.Save(dialog.FileName);
                MessageBox.Show("График успешно сохранен!");
            }

        }

        private protected static Bitmap ResizeBitmap(Bitmap bitmap, Size size)
        {
            try
            {
                Bitmap bitmapTemp = new Bitmap(size.Width, size.Height);
                using (Graphics g = Graphics.FromImage(bitmapTemp))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(bitmap, 0, 0, size.Width, size.Height);
                }
                return bitmapTemp;
            }
            catch
            {
                Trace.WriteLine("Размер Bitmap не может быть изменён.");
                return bitmap;
            }
        }

        private void formMenuChartSaveA4_Click(object sender, EventArgs e) => SaveScreenshootControl(chartGroup);

        private void formMenuFormDropState_Click(object sender, EventArgs e) => SetState(StateForm.PREPAIRED);

        private bool ValidateTextToDouble(double MaxDouble, string str, double minDouble = 0)
        {
            if (string.IsNullOrWhiteSpace(str))
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
                validateProvider.SetError(pBegin, $"Требуется ввести правильное начальное значение давления! Прим. от {MIN_Y_AXIS} до {MAX_Y_AXIS}");
                e.Cancel = true;
            }
            else
                validateProvider.SetError(pBegin, "");
        }

        private void pEnd_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateTextToDouble(MAX_Y_AXIS, pEnd.Text, MIN_Y_AXIS))
            {
                validateProvider.SetError(pEnd, $"Требуется ввести правильное конечное значение давления! Прим. от {MIN_Y_AXIS} до {MAX_Y_AXIS}");
                e.Cancel = true;
            }
            else
                validateProvider.SetError(pEnd, "");
        }

        private void volume_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateTextToDouble(MAX_Y_AXIS, volume.Text, MIN_Y_AXIS))
            {
                validateProvider.SetError(volume, $"Требуется ввести правильное значение объёма! Прим. от {MIN_Y_AXIS} до {MAX_Y_AXIS}");
                e.Cancel = true;
            }
            else
                validateProvider.SetError(volume, "");
        }

        private void volumeInjection_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateTextToDouble(MAX_Y_AXIS, volumeInjection.Text, MIN_Y_AXIS))
            {
                validateProvider.SetError(volumeInjection, $"Требуется ввести правильное значение объёма закачки! Прим. от {MIN_Y_AXIS} до {MAX_Y_AXIS}");
                e.Cancel = true;
            }
            else
                validateProvider.SetError(volumeInjection, "");
        }

        private void specificWeight_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateTextToDouble(MAX_Y2_AXIS, specificWeight.Text, MIN_Y_AXIS))
            {
                validateProvider.SetError(specificWeight, $"Требуется ввести правильное значение удельного веса! Прим. от {MIN_Y_AXIS} до {MAX_Y2_AXIS}");
                e.Cancel = true;
            }
            else
                validateProvider.SetError(specificWeight, "");
        }

        private void name_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name.Text))
            {
                validateProvider.SetError(name, "Требуется ввести наименование буровой установки!");
                e.Cancel = true;
            }
            else
                validateProvider.SetError(name, "");
        }

        private void timeEnd_Validating(object sender, CancelEventArgs e)
        {
            if (timeEnd.Value < timeBegin.Value)
            {
                validateProvider.SetError(timeEnd, "Конечное время должно быть больше начального!");
                e.Cancel = true;
            }
            else
                validateProvider.SetError(timeEnd, "");
        }

        private void timeBegin_Validating(object sender, CancelEventArgs e)
        {
            if (timeEnd.Value < timeBegin.Value)
            {
                validateProvider.SetError(timeBegin, "Начальное время должно быть меньше конечного!");
                e.Cancel = true;
            }
            else
                validateProvider.SetError(timeBegin, "");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void timeCount_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown control = sender as NumericUpDown;
            if (control != null)
                MAX_X_AXIS = (int)control.Value;
        }
    }
}
