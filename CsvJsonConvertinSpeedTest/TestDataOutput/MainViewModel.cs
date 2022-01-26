using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestDataOutput
{
    /// <summary>
    /// MainViewModel
    /// </summary>
    public class MainViewModel : BindableBase
    {
        /// <summary>
        /// タイトル。
        /// </summary>
        public string Title { get; private set; } = nameof(TestDataOutput);

        /// <summary>
        /// データ数。
        /// </summary>
        private int _dataCount = 1;
        public int DataCount
        {
            get => _dataCount;
            set => SetProperty(ref _dataCount, value);
        }

        /// <summary>
        /// 実行状況。
        /// </summary>
        private string _executionStatus = "";
        public string ExecutionStatus
        {
            get => _executionStatus;
            set => SetProperty(ref _executionStatus, value);
        }
        

        /// <summary>
        /// CSVファイルを出力する。
        /// </summary>
        public ICommand OutputCsvComand { get; set; }

        public MainViewModel()
        {
            OutputCsvComand = new DelegateCommand(() => OutputCsvComandExecute());
        }

        /// <summary>
        /// CSVファイルを出力する。
        /// </summary>
        private void OutputCsvComandExecute()
        {
            ExecutionStatus = "";

            if (DataCount == 0)
            {
                return;
            }

            var random = new Random();

            using (var writer = new StreamWriter("test.csv"))
            {
                writer.WriteLine(String.Join(",", new string[] { "a", "b", "x", "y" }));

                for (int i = 0; i < DataCount; i++)
                {
                    writer.WriteLine(String.Join(",", new string[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Math.Round((random.NextDouble() * 100), 2, MidpointRounding.ToZero).ToString(), Math.Round((random.NextDouble() * 100), 2, MidpointRounding.ToZero).ToString() }));
                }
            }

            ExecutionStatus = "出力完了";
        }
    }
}
