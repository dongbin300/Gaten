using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;

namespace Gaten.Study.GeneticAlgorithm
{
    public partial class MainForm : Form
    {
        float maxWidth = 998f;
        float maxHeight = 680f;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //var selection = new EliteSelection();
            //var crossover = new UniformCrossover();
            //var mutation = new UniformMutation(true);

            //var fitness = new MyProblemFitness();
            //var chromosome = new MyProblemChromosome();

            //var chromosome = new FloatingPointChromosome(
            //new double[] { 0, 0, 0, 0 },
            //new double[] { maxWidth, maxHeight, maxWidth, maxHeight },
            //new int[] { 10, 10, 10, 10 },
            //new int[] { 0, 0, 0, 0 });

            //var chromosome = new FloatingPointChromosome(-100, 100, 8, 0);
            var chromosome = new IntegerChromosome(-100, 100);
            var population = new Population(50, 100, chromosome);

            var fitness = new FuncFitness((c) =>
            {
                var fc = c as IntegerChromosome;
                var value = fc.ToInteger();

                return value / 2 + 11;
            });

            var selection = new EliteSelection();
            var crossover = new UniformCrossover(0.5f);
            var mutation = new FlipBitMutation();
            var termination = new FitnessStagnationTermination(100);
            var ga = new GeneticSharp.Domain.GeneticAlgorithm(
                population,
                fitness,
                selection,
                crossover,
                mutation);
            ga.Termination = termination;
            ga.Start();

            var latestFitness = 0.0;
            ga.GenerationRan += (sender, e) =>
            {
                var bestChromosome = ga.BestChromosome as IntegerChromosome;
                var bestFitness = bestChromosome.Fitness.Value;

                if (bestFitness != latestFitness)
                {
                    latestFitness = bestFitness;
                    var phenotype = bestChromosome.ToInteger();

                    listBox1.Items.Add(string.Format(
                        "Generation {0,3}: ({1}) = {2}\n",
                        ga.GenerationsNumber,
                        phenotype,
                        bestFitness
                    ));
                }
            };
            ga.Start();

            //var ga = new GeneticSharp.Domain.GeneticAlgorithm(population, fitness, selection, crossover, mutation);
            //ga.Termination = new FitnessStagnationTermination(100);
            //ga.GenerationRan += (s, e) => Console.WriteLine($"Generation {ga.GenerationsNumber}. Best fitness: {ga.BestChromosome.Fitness.Value}");

            //label1.Text = "GA running...";
            //ga.Start();

            //label1.Text += $"\nBest solution found has fitness: {ga.BestChromosome.Fitness}";
            //label1.Text += $"\nElapsed time: {ga.TimeEvolving}";
        }
    }
}