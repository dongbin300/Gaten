using Microsoft.ML.Probabilistic.Algorithms;
using Microsoft.ML.Probabilistic.Math;
using Microsoft.ML.Probabilistic.Models;

using Range = Microsoft.ML.Probabilistic.Models.Range;

/*
var firstCoin = Variable.Bernoulli(0.5);
var secondCoin = Variable.Bernoulli(0.5);
var bothHeads = firstCoin & secondCoin;

var engine = new InferenceEngine();
Console.WriteLine(engine.Infer(bothHeads));

bothHeads.ObservedValue = false;
Console.WriteLine(engine.Infer(firstCoin));
*/

/*
var threshold = Variable.New<double>().Named("threshold");
var x = Variable.GaussianFromMeanAndVariance(0, 1).Named("x");
Variable.ConstrainTrue(x > threshold);

var engine = new InferenceEngine();
engine.Algorithm = new ExpectationPropagation();

for (double i = 0; i <= 4; i += 0.1)
{
    threshold.ObservedValue = i;
    Console.WriteLine(engine.Infer(x));
}
*/


double[] data = new double[1000];
for (int i = 0; i < data.Length; i++)
    data[i] = Rand.Normal(0, 1);
Range dataRange = new Range(data.Length).Named("n");
VariableArray<double> x = Variable.Array<double>(dataRange);
Variable<double> mean = Variable.GaussianFromMeanAndVariance(0, 100);
Variable<double> precision = Variable.GammaFromShapeAndScale(1, 1);
x[dataRange] = Variable.GaussianFromMeanAndPrecision(mean, precision).ForEach(dataRange);
x.ObservedValue = data;

InferenceEngine engine = new InferenceEngine();
Console.WriteLine("mean=" + engine.Infer(mean));
Console.WriteLine("prec=" + engine.Infer(precision));


