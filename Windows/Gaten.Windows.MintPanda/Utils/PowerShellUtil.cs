using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

namespace Gaten.Windows.MintPanda.Utils
{
    public class PowerShellUtil
    {
        public static string Run(string script)
        {
            var runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            var pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(script);

            var results = pipeline.Invoke();
            runspace.Close();

            var stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }
            return stringBuilder.ToString();
        }
    }
}
