using Gaten.Language.Mercury.Editor;
using Gaten.Language.Mercury.Inspection.SystemCode;
using Gaten.Net.Diagnostics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gaten.Language.Mercury.Inspection
{
    internal class MercuryInspector
    {
        private List<TextLine> code = new();
        private int i = 0;
        private int lineCount => code.Count;

        public MercuryInspector()
        {

        }

        public MercuryInspectionResult Run(string codeText)
        {
            try
            {
                var result = new MercuryInspectionResult();

                code = codeText.Split(Environment.NewLine, StringSplitOptions.None).Select((x, i) => new TextLine(i + 1, x.Trim())).ToList();
                i = 0;

                var systemCodes = GetSystemCode();

                return result;
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(MercuryInspector), MethodBase.GetCurrentMethod()?.Name, ex);
                return new MercuryInspectionResult(ex.Message);
            }
        }

        private MercurySystemCodeFormat GetSystemCode()
        {
            var systemCodeText = code.FindAll(x => x.Text.StartsWith('#')).ToList();
            var systemCodeParseResult = MercurySystemCodeCollection.Parse(systemCodeText);

            if (!systemCodeParseResult.IsOk)
            {
                throw new Exception(systemCodeParseResult.ErrorMessage);
            }

            if (systemCodeParseResult.SystemCode == null)
            {
                throw new SystemException("시스템 오류입니다.");
            }

            return systemCodeParseResult.SystemCode;
        }
    }
}
