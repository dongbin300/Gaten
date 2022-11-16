using Gaten.Net.ML;
using Gaten.Net.ML.GaussianProcess;

using Microsoft.ML.Probabilistic.Distributions;
using Microsoft.ML.Probabilistic.Distributions.Kernels;
using Microsoft.ML.Probabilistic.Math;
using Microsoft.ML.Probabilistic.Models;

namespace Gaten.Study.GaussianProcess
{
    class Program
    {
        static void Main()
        {
            FitDataset(true, 10, 0.3);
        }

        static void FitDataset(bool useMock, int numData, double corrupt)
        {
            Vector[] trainingInputs;
            double[] trainingOutputs;

            if (useMock)
            {
                trainingInputs = new Vector[]
                {
                    Vector.Constant(1, 0.1),
                    Vector.Constant(1, 0.2),
                    Vector.Constant(1, 0.3),
                    Vector.Constant(1, 0.4),
                    Vector.Constant(1, 0.5),
                    Vector.Constant(1, 0.6),
                    Vector.Constant(1, 0.7),
                    Vector.Constant(1, 0.8),
                    Vector.Constant(1, 0.9),
                    Vector.Constant(1, 1.0)
                };

                trainingOutputs = new double[]
                {
                    0.1,
                    0.2,
                    0.3,
                    0.4,
                    0.5,
                    0.6,
                    0.7,
                    0.8,
                    0.9,
                    1.0
                };

                //(trainingInputs, trainingOutputs) = GaussianProcessDataGenerator.GenerateRandomData(numData, corrupt);
            }
            else
            {
                var trainingData = Utils.LoadAISDataset();
                trainingInputs = trainingData.Select(tup => Vector.FromArray(new double[1] { tup.x })).ToArray();
                trainingOutputs = trainingData.Select(tup => tup.y).ToArray();
            }

            InferenceEngine engine = Utils.GetInferenceEngine();

            // First fit standard GP, then fit Student-T GP
            //foreach (var useStudentTLikelihood in new[] { false, true })
            //{

            var gaussianProcessRegressor = new GaussianProcessRegressor(trainingInputs, false, trainingOutputs);

            // Log length scale estimated as -1
            var noiseVariance = 0.8;
            var kf = new SummationKernel(new SquaredExponential(-1)) + new WhiteNoise(Math.Log(noiseVariance) / 2);
            Microsoft.ML.Probabilistic.Distributions.GaussianProcess gp = new Microsoft.ML.Probabilistic.Distributions.GaussianProcess(new ConstantFunction(0), kf);

            // Convert SparseGP to full Gaussian Process by evaluating at all the training points
            gaussianProcessRegressor.Prior.ObservedValue = new SparseGP(new SparseGPFixed(gp, trainingInputs.ToArray()));
            double logOdds = engine.Infer<Bernoulli>(gaussianProcessRegressor.Evidence).LogOdds;
            Console.WriteLine($"{kf} evidence = {logOdds:g4}");

            // Infer the posterior Sparse GP
            SparseGP sgp = engine.Infer<SparseGP>(gaussianProcessRegressor.F);

#if WINDOWS
                string datasetName = useSynthetic ? "Synthetic" : "AIS";
                Utilities.PlotPredictions(sgp, trainingInputs, trainingOutputs, useStudentTLikelihood, datasetName);
#endif
            //}
        }
    }
}