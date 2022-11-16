using Microsoft.ML.Probabilistic.Algorithms;
using Microsoft.ML.Probabilistic.Distributions;
using Microsoft.ML.Probabilistic.Distributions.Kernels;
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


//double[] data = new double[1000];
//for (int i = 0; i < data.Length; i++)
//    data[i] = Rand.Normal(0, 1);
//Range dataRange = new Range(data.Length).Named("n");
//VariableArray<double> x = Variable.Array<double>(dataRange);
//Variable<double> mean = Variable.GaussianFromMeanAndVariance(0, 100);
//Variable<double> precision = Variable.GammaFromShapeAndScale(1, 1);
//x[dataRange] = Variable.GaussianFromMeanAndPrecision(mean, precision).ForEach(dataRange);
//x.ObservedValue = data;

//InferenceEngine engine = new InferenceEngine();
//Console.WriteLine("mean=" + engine.Infer(mean));
//Console.WriteLine("prec=" + engine.Infer(precision));

//void BayesPointMachine(double[] incomes, double[] ages, Variable<Vector> w, VariableArray<bool> y)
//{
//    Range j = y.Range; 
//    Vector[] xdata = new Vector[incomes.Length];
//    for (int i = 0; i < xdata.Length; i++)
//        xdata[i] = Vector.FromArray(incomes[i], ages[i], 1);
//    VariableArray<Vector> x = Variable.Observed(xdata, j);
//    double noise = 0.1;
//    y[j] = Variable.GaussianFromMeanAndVariance(Variable.InnerProduct(w, x[j]), noise) > 0;
//}

//double[] incomes = { 63, 16, 28, 55, 22, 20 };
//double[] ages = { 38, 23, 40, 27, 18, 40 };
//bool[] willBuy = { true, false, true, true, false, false };
//Vector[] xdata = new Vector[incomes.Length];
//for (int i = 0; i < xdata.Length; i++)
//    xdata[i] = Vector.FromArray(incomes[i], ages[i], 1);
//VariableArray<Vector> x = Variable.Observed(xdata);
//VariableArray<bool> y = Variable.Observed(willBuy, x.Range);
//Variable<Vector> w = Variable.Random(new VectorGaussian(Vector.Zero(3), PositiveDefiniteMatrix.Identity(3)));
//Range j = y.Range;
//double noise = 0.1;
//y[j] = Variable.GaussianFromMeanAndVariance(Variable.InnerProduct(w, x[j]), noise) > 0;
//InferenceEngine engine = new InferenceEngine(new ExpectationPropagation());
//VectorGaussian wPosterior = engine.Infer<VectorGaussian>(w);
//Console.WriteLine("Dist over w=\n" + wPosterior);

//double[] incomesTest = { 58, 18, 22 };
//double[] agesTest = { 36, 24, 37 };
//VariableArray<bool> ytest = Variable.Array<bool>(new Range(agesTest.Length));
//BayesPointMachine(incomesTest, agesTest, Variable.Random(wPosterior), ytest);
//Console.WriteLine("output=\n" + engine.Infer(ytest));


//Variable<string> str1 = Variable.StringUniform().Named("str1");
//Variable<string> str2 = Variable.StringUniform().Named("str2");

//Variable<string> text = (str1 + " " + str2).Named("text");
//text.ObservedValue = "DB 초기화 및 인증 관련 서비스";

//var engine = new InferenceEngine();

//Console.WriteLine("str1: {0}", engine.Infer(str1));
//Console.WriteLine("str2: {0}", engine.Infer(str2));


Vector[] inputs = new Vector[] {
  Vector.FromArray(new double[2] {0, 0}),
  Vector.FromArray(new double[2] {0, 1}),
  Vector.FromArray(new double[2] {1, 0}),
  Vector.FromArray(new double[2] {0, 0.2}),
  Vector.FromArray(new double[2] {1.5, 0}),
};
bool[] outputs = { false, false, true, false, true };

VariableArray<Vector> x = Variable.Observed(inputs).Named("x");
Range j = x.Range.Named("j");
VariableArray<bool> y = Variable.Observed(outputs, j).Named("y");
Variable<SparseGP> p = Variable.New<SparseGP>().Named("p");
Variable<IFunction> f = Variable<IFunction>.Random(p).Named("f");

GaussianProcess gp = new GaussianProcess(new ConstantFunction(0), new SquaredExponential(0));
Vector[] basis = new Vector[] {
  Vector.FromArray(new double[2] {0.2, 0.2}),
  Vector.FromArray(new double[2] {0.2, 0.8}),
  Vector.FromArray(new double[2] {0.8, 0.2}),
  Vector.FromArray(new double[2] {0.8, 0.8})
};
p.ObservedValue = new SparseGP(new SparseGPFixed(gp, basis));

Variable<double> score = Variable.FunctionEvaluate(f, x[j]);
y[j] = (Variable.GaussianFromMeanAndVariance(score, 0.1) > 0);

InferenceEngine engine = new InferenceEngine(new ExpectationPropagation());
SparseGP sgp = engine.Infer<SparseGP>(f);

for (int i = 0; i < outputs.Length; i++)
{
    Gaussian post = sgp.Marginal(inputs[i]);
    double postMean = post.GetMean();
    string comment = (outputs[i] == (postMean > 0.0)) ? "correct" : "incorrect";
    Console.WriteLine("f({0}) = {1} ({2})", inputs[i], post, comment);
}