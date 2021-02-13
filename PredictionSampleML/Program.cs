using ConsoleApp2.Data;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using System;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static readonly string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "iris.data");
        static readonly string _modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "IrisClusteringModel.zip");
        static void Main(string[] args)
        {
            Console.WriteLine("Hello ML!");

            var mlContext = new MLContext(seed: 0);

            //var dataView = mlContext.Data.LoadFromTextFile<IrisData>(_dataPath, hasHeader: false, separatorChar: ',');

            //string featuresColumnName = "Features";

            //var pipline = mlContext.Transforms
            //              .Concatenate(featuresColumnName, "SepalLength", "SepalWidth", "PetalLength", "PetalWidth")
            //              .Append(mlContext.Clustering.Trainers.KMeans(featuresColumnName, numberOfClusters: 3));

            //var model = pipline.Fit(dataView);

            //var predictor = mlContext.Model.CreatePredictionEngine<IrisData, ClusterPrediction>(model);

            //using (var fileStream = new FileStream(_modelPath, FileMode.Create, FileAccess.Write, FileShare.Write))
            //{
            //    mlContext.Model.Save(model, dataView.Schema, fileStream);
            //}

            DataViewSchema modelSchema;

            ITransformer trainedModel = mlContext.Model.Load(_modelPath, out modelSchema);

            var predictor = mlContext.Model.CreatePredictionEngine<IrisData, ClusterPrediction>(trainedModel);

            var prediction = predictor.Predict(TestIrisData.Setosa);
            Console.WriteLine($"Cluster: {prediction.PredictedClusterId}");
            Console.WriteLine($"Distances: {string.Join(" ", prediction.Distances)}");

        }
    }
}
