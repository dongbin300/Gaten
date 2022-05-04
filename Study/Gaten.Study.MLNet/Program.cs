using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using static Microsoft.ML.DataOperationsCatalog;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms.Text;

namespace Gaten.Study.MLNet
{
    class Program
    {
        // 최근에 다운로드한 파일을 유지
        static readonly string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "yelp_labelled.txt");

        static void Main(string[] args)
        {
            MLContext mlContext = new MLContext();

            // 분할된 학습 및 테스트 데이터 세트
            TrainTestData splitDataView = LoadData(mlContext);

            // 평가에 사용하기 위해 학습된 모델
            ITransformer model = BuildAndTrainModel(mlContext, splitDataView.TrainSet);

            // 테스트 데이터를 사용하여 모델의 성능 유효성 검사
            Evaluate(mlContext, model, splitDataView.TestSet);

            // 테스트 데이터의 결과를 예측
            UseModelWithSingleItem(mlContext, model);

            // 일괄처리 테스트 데이터의 결과를 예측
            UseModelWithBatchItems(mlContext, model);
        }

        /// <summary>
        /// 데이터를 로드합니다.
        /// 로드된 데이터 세트를 학습 및 테스트 세트로 분할합니다.
        /// 분할된 학습 및 테스트 데이터 세트를 반환합니다.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static TrainTestData LoadData(MLContext mlContext)
        {
            // 데이터 스키마를 정의하고 파일에서 읽음
            IDataView dataView = mlContext.Data.LoadFromTextFile<SentimentData>(_dataPath, hasHeader: false);

            // 로드된 데이터를 필요한 데이터 세트로 분할
            TrainTestData splitDataView = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);

            // 테스트 데이터 세트 반환
            return splitDataView;
        }


        /// <summary>
        /// 데이터를 추출하고 변환합니다.
        /// 모델을 학습시킵니다.
        /// 테스트 데이터를 기반으로 감정을 예측합니다.
        /// 모델을 반환합니다.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="splitTrainSet"></param>
        /// <returns></returns>
        public static ITransformer BuildAndTrainModel(MLContext mlContext, IDataView splitTrainSet)
        {
            // 데이터 추출 및 변환 후 학습
            var estimator = mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features", inputColumnName: nameof(SentimentData.SentimentText))
                .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));

            Console.WriteLine("=============== Create and Train the Model ===============");
            // 데이터 세트를 변환하고 학습을 적용하여 모델을 학습
            var model = estimator.Fit(splitTrainSet);
            Console.WriteLine("=============== End of training ===============");
            Console.WriteLine();

            // 모델 반환
            return model;
        }

        /// <summary>
        /// 테스트 데이터 세트를 로드합니다.
        /// BinaryClassification 평가자를 만듭니다.
        /// 모델을 평가하고 메트릭을 만듭니다.
        /// 메트릭을 표시합니다.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="model"></param>
        /// <param name="splitTestSet"></param>
        public static void Evaluate(MLContext mlContext, ITransformer model, IDataView splitTestSet)
        {
            Console.WriteLine("=============== Evaluating Model accuracy with Test data===============");
            // 여러 제공된 테스트 데이터 세트 입력 행에 대한 예측
            IDataView predictions = model.Transform(splitTestSet);

            // 모델 평가
            CalibratedBinaryClassificationMetrics metrics = mlContext.BinaryClassification.Evaluate(predictions, "Label");

            // 메트릭 표시
            Console.WriteLine();
            Console.WriteLine("Model quality metrics evaluation");
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
            Console.WriteLine($"Auc: {metrics.AreaUnderRocCurve:P2}");
            Console.WriteLine($"F1Score: {metrics.F1Score:P2}");
            Console.WriteLine("=============== End of model evaluation ===============");
        }

        /// <summary>
        /// 테스트 데이터의 단일 댓글을 만듭니다.
        /// 테스트 데이터를 기반으로 감정을 예측합니다.
        /// 보고를 위해 테스트 데이터 및 예측을 결합합니다.
        /// 예측 결과를 표시합니다.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="model"></param>
        private static void UseModelWithSingleItem(MLContext mlContext, ITransformer model)
        {
            // 데이터의 단일 인스턴스에 대한 예측
            PredictionEngine<SentimentData, SentimentPrediction> predictionFunction = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);

            // 학습된 모델의 예측을 테스트
            SentimentData sampleStatement = new SentimentData
            {
                SentimentText = "This was a very bad steak"
            };

            var resultPrediction = predictionFunction.Predict(sampleStatement);

            Console.WriteLine();
            Console.WriteLine("=============== Prediction Test of model with a single sample and test dataset ===============");

            Console.WriteLine();
            Console.WriteLine($"Sentiment: {resultPrediction.SentimentText} | Prediction: {(Convert.ToBoolean(resultPrediction.Prediction) ? "Positive" : "Negative")} | Probability: {resultPrediction.Probability} ");

            Console.WriteLine("=============== End of Predictions ===============");
            Console.WriteLine();
        }

        /// <summary>
        /// 일괄 처리 테스트 데이터를 만듭니다.
        /// 테스트 데이터를 기반으로 감정을 예측합니다.
        /// 보고를 위해 테스트 데이터 및 예측을 결합합니다.
        /// 예측 결과를 표시합니다.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="model"></param>
        public static void UseModelWithBatchItems(MLContext mlContext, ITransformer model)
        {
            // 학습된 모델의 예측을 테스트
            IEnumerable<SentimentData> sentiments = new[]
            {
                new SentimentData
                {
                    SentimentText = "When I'm in the vicinity, motherfucker, you better duck."
                },
                new SentimentData
                {
                    SentimentText = "I'm undebatable, I'm unavoidable, I'm unevadable."
                }
            };

            // 주석 데이터 감정 예측
            IDataView batchComments = mlContext.Data.LoadFromEnumerable(sentiments);

            IDataView predictions = model.Transform(batchComments);

            IEnumerable<SentimentPrediction> predictedResults = mlContext.Data.CreateEnumerable<SentimentPrediction>(predictions, reuseRowObject: false);

            // 예측 결과 표시
            Console.WriteLine();
            Console.WriteLine("=============== Prediction Test of loaded model with multiple samples ===============");
            foreach (SentimentPrediction prediction in predictedResults)
            {
                Console.WriteLine($"Sentiment: {prediction.SentimentText} | Prediction: {(Convert.ToBoolean(prediction.Prediction) ? "Positive" : "Negative")} | Probability: {prediction.Probability} ");
            }
            Console.WriteLine("=============== End of predictions ===============");
        }
    }
}
