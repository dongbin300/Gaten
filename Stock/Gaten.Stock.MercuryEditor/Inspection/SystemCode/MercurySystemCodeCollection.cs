using Gaten.Stock.MercuryEditor.Editor;
using Gaten.Stock.MercuryEditor.Enums;
using Gaten.Net.Diagnostics;

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Gaten.Stock.MercuryEditor.Inspection.SystemCode
{
    internal class MercurySystemCodeCollection
    {
        private static List<MercurySystemCode> mercurySystemCodes = new()
        {
            new MercurySystemCode("v1", 1, 1),
            new MercurySystemCode("binancefutures", 2, 1),
            new MercurySystemCode("backtest", 3, 1),
            new MercurySystemCode("mocktrade", 3, 1),
            new MercurySystemCode("realtrade", 3, 1),
        };

        public static MercurySystemCodeParseResult Parse(List<TextLine> code)
        {
            try
            {
                var systemCodeCollection = new MercurySystemCodeFormat();

                foreach (var t in code)
                {
                    var temp = mercurySystemCodes.Find(x => x.Keyword.Equals(t.Text[1..]));

                    if (temp == null)
                    {
                        return new MercurySystemCodeParseResult($"존재하지 않는 시스템 코드입니다. :: {t}");
                    }

                    switch (temp.CodeType)
                    {
                        case 1:
                            if (systemCodeCollection.CodeVersion != 0)
                            {
                                return new MercurySystemCodeParseResult($"Code Version이 중복됩니다. :: {t}");
                            }
                            systemCodeCollection.CodeVersion = temp.SupportedMinimumVersion;
                            break;
                        case 2:
                            if (systemCodeCollection.MarketPlatform != MarketPlatform.None)
                            {
                                return new MercurySystemCodeParseResult($"Market Platform이 중복됩니다. :: {t}");
                            }
                            if (systemCodeCollection.CodeVersion < temp.SupportedMinimumVersion)
                            {
                                return new MercurySystemCodeParseResult($"더 높은 버전에서 사용할 수 있습니다. :: {t}");
                            }
                            systemCodeCollection.MarketPlatform = (MarketPlatform)Enum.Parse(typeof(MarketPlatform), temp.Keyword);
                            break;
                        case 3:
                            if (systemCodeCollection.ModelType != ModelType.None)
                            {
                                return new MercurySystemCodeParseResult($"Model Type이 중복됩니다. :: {t}");
                            }
                            if (systemCodeCollection.CodeVersion < temp.SupportedMinimumVersion)
                            {
                                return new MercurySystemCodeParseResult($"더 높은 버전에서 사용할 수 있습니다. :: {t}");
                            }
                            systemCodeCollection.ModelType = (ModelType)Enum.Parse(typeof(ModelType), temp.Keyword);
                            break;
                        default:
                            throw new SystemException($"시스템 오류입니다. :: {t}");
                    }
                }

                if (systemCodeCollection.CodeVersion < 1 || systemCodeCollection.MarketPlatform == MarketPlatform.None || systemCodeCollection.ModelType == ModelType.None)
                {
                    return new MercurySystemCodeParseResult("시스템 데이터가 부족합니다.");
                }

                return new MercurySystemCodeParseResult
                {
                    SystemCode = systemCodeCollection
                };
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(MercurySystemCodeCollection), MethodBase.GetCurrentMethod()?.Name, ex);
                return new MercurySystemCodeParseResult($"시스템 오류입니다.");
            }
        }
    }
}
