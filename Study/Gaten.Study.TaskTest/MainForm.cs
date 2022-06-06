using System.Threading;

using Gaten.Net.Windows.Forms;

namespace Gaten.Study.TaskTest
{
    public partial class MainForm : Form
    {
        List<TestResult> results = new List<TestResult>();
        List<string> names = new()
        {
            "Alex",
            "Tom",
            "Santa",
            "Michael"
        };

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < 3; i++)
            {
                names.AddRange(names);
            }
            
            //Task<TestResult> result = 
            //Task <TestResult> result = Parallel.ForEachAsync(names, async (name, token) =>
            //{
            //    Delegater.TextSet(label1, name);
            //    results.Add(new TestResult { Name = name, Age = name.Length });
            //});
        }

        //Task<TestResult> DoWhat(string name)
        //{
        //    Invoke(new Action(delegate ()
        //    {
        //        listBox1.Items.Add(name);
        //    }));
        //    Thread.Sleep(1000);
        //    return new Task<TestResult>(() => new TestResult { Name = name, Age = name.Length });
        //}

        private async void button1_Click(object sender, EventArgs e)
        {
            //var taskList = new List<Task<TestResult>>();

            //foreach (var name in names)
            //{
            //    taskList.Add(DoWhat(name));
            //}

            //foreach (var task in taskList)
            //{
            //    task.Start();
            //}

            //var result = await Task.WhenAll(taskList.ToList());
            var tasks = new List<Task<TestResult>>();

            for(int i = 0; i < 100; i++)
            {
                tasks.Add(Sleep(100 * i));
            }

            var result = await Task.WhenAll(tasks);
        }

        private async Task<TestResult> Sleep(int ms)
        {
            await Task.Delay(ms);
            Invoke(new Action(delegate ()
            {
                listBox1.Items.Add(string.Format("Sleeping for {0} finished at {1}", ms, DateTime.Now.ToShortTimeString()));
            }));
            return new TestResult { Now = DateTime.Now, Interval = ms};
        }
    }

    public class TestResult
    {
        public DateTime Now { get; set; }
        public int Interval { get; set; }
    }
}