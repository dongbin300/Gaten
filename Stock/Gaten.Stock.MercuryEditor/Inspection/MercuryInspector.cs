﻿using Gaten.Stock.MercuryEditor.Editor;
using Gaten.Stock.MercuryEditor.Inspection.SystemCode;
using Gaten.Net.Diagnostics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Gaten.Stock.MercuryEditor.Enums;
using Gaten.Stock.MercuryEditor.Inspection.V1;
using Gaten.Net.IO;
using System.Text.Json;
using Gaten.Stock.MercuryEditor.IO;
using Gaten.Net.Stock.MercuryTradingModel.TradingModels;
using Newtonsoft.Json;

namespace Gaten.Stock.MercuryEditor.Inspection
{
    internal class MercuryInspector
    {
        public string InspectedPath { get; set; } = string.Empty;
        private List<TextLine> code = new();
        private int lineNumber = 0;
        private int lineCount => code.Count;

        public MercuryInspector()
        {

        }

        public MercuryInspectionResult Run(string codeText)
        {
            try
            {
                code = codeText.Split(Environment.NewLine, StringSplitOptions.None).Select((x, i) => new TextLine(i + 1, x.Trim())).ToList();
                lineNumber = 0;

                var systemCodes = GetSystemCode();

                switch (systemCodes.CodeVersion)
                {
                    case 1:
                        switch (systemCodes.MarketPlatform)
                        {
                            case MarketPlatform.binancefutures:
                                switch (systemCodes.ModelType)
                                {
                                    case ModelType.backtest:
                                        var inspector = new MercuryBinanceFuturesBackTestInspector(lineNumber);
                                        var backTestResult = inspector.Run(code);
                                        if (backTestResult != string.Empty)
                                        {
                                            throw new Exception(backTestResult);
                                        }

                                        var jsonString = JsonConvert.SerializeObject(inspector.TradingModel, new JsonSerializerSettings
                                        {
                                             NullValueHandling = NullValueHandling.Ignore,
                                             TypeNameHandling = TypeNameHandling.Auto,
                                             Formatting = Formatting.Indented
                                        });
                                        //var jsonString = JsonSerializer.Serialize<object>(inspector.TradingModel);
                                        InspectedPath = TradingModelPath.InspectedBackTestDirectory.Down(TmFile.TmName + ".json");
                                        GFile.Write(InspectedPath, jsonString);
                                        break;

                                    case ModelType.mocktrade:
                                        break;

                                    case ModelType.realtrade:
                                        break;

                                    default:
                                        throw new Exception("알 수 없는 Model Type입니다.");
                                }
                                break;

                            default:
                                throw new Exception("알 수 없는 Market Platform입니다.");
                        }
                        break;

                    default:
                        throw new Exception("알 수 없는 Code Version입니다.");
                }

                return new MercuryInspectionResult();
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
            lineNumber = systemCodeText.Max(x => x.LineNumber);

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