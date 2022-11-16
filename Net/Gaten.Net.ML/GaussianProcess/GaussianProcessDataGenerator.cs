// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// https://github.com/dotnet/infer/tree/main/src/Examples/RobustGaussianProcess
using Microsoft.ML.Probabilistic.Distributions;
using Microsoft.ML.Probabilistic.Distributions.Kernels;
using Microsoft.ML.Probabilistic.Math;
using Microsoft.ML.Probabilistic.Models;

using Vector = Microsoft.ML.Probabilistic.Math.Vector;

namespace Gaten.Net.ML.GaussianProcess
{
    public class GaussianProcessDataGenerator
    {
        public static (Vector[] dataX, double[] dataY) GenerateRandomData(int numData, double proportionCorrupt)
        {
            int randomSeed = 9876;

            Random rng = new Random(randomSeed);
            Rand.Restart(randomSeed);

            InferenceEngine engine = Utils.GetInferenceEngine();

            // The points to evaluate
            Vector[] randomInputs = Utils.VectorRange(0, 1, numData, null);

            var gaussianProcessGenerator = new GaussianProcessRegressor(randomInputs);

            // The basis
            Vector[] basis = Utils.VectorRange(0, 1, 6, rng);

            // The kernel
            var kf = new SummationKernel(new SquaredExponential(-1)) + new WhiteNoise();

            // Fill in the sparse GP prior
            Microsoft.ML.Probabilistic.Distributions.GaussianProcess gp = new Microsoft.ML.Probabilistic.Distributions.GaussianProcess(new ConstantFunction(0), kf);
            gaussianProcessGenerator.Prior.ObservedValue = new SparseGP(new SparseGPFixed(gp, basis));

            // Infer the posterior Sparse GP, and sample a random function from it
            SparseGP sgp = engine.Infer<SparseGP>(gaussianProcessGenerator.F);
            var randomFunc = sgp.Sample();

            double[] randomOutputs = new double[randomInputs.Length];
            int numCorrupted = (int)Math.Ceiling(numData * proportionCorrupt);
            var subset = Enumerable.Range(0, randomInputs.Length + 1).OrderBy(x => rng.Next()).Take(numCorrupted);

            // get random data
            for (int i = 0; i < randomInputs.Length; i++)
            {
                double post = randomFunc.Evaluate(randomInputs[i]);
                // corrupt data point if it we haven't exceed the proportion we wish to corrupt
                if (subset.Contains(i))
                {
                    double sign = rng.NextDouble() > 0.5 ? 1 : -1;
                    double distance = rng.NextDouble() * 1;
                    post = sign * distance + post;
                }

                randomOutputs[i] = post;
            }

            Console.WriteLine("Model complete: Generated {0} points with {1} corrupted", numData, numCorrupted);

            return (randomInputs, randomOutputs);
        }
    }
}