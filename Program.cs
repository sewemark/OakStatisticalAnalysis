using OakStatisticalAnalysis.Rules;
using OakStatisticalAnalysis.Rules.FisherCalculatoionStrategies;
using SimpleInjector;
using System;
using System.Windows.Forms;

namespace OakStatisticalAnalysis
{
    static class Program
    {
      
        private static Container container;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();
            Application.Run(container.GetInstance<OakStatisticalAnalisysisForm>());
        }

        private static void Bootstrap()
        {
            container = new Container();
            container.Register<IDatabaseContentParser, DatabaseContentParser>();
            container.Register<IClassifierFactory>(()=> new ClassifierFactory());
            container.Register<ITestClassifierFactory>(() => new TestClassifierFactory());
            container.Register<ITrainTestSetsSplitterFactory>(() => new TrainTestSetsSplitterFactory());
            container.Register<IFeaturesSelectingRules>(() => new FeaturesSelectingRules(RulesFactory.GetRules()));
            container.Register<IFeatureSelector>(() => new FeatureSelector(container.GetInstance<IFeaturesSelectingRules>()));
            container.Register<ISFSFeatureSelector>(() => new SFSFeatureSelector(new TwoDimensionsFisherCalculator()));
            // featureExtractor = new FeatureSelector(featureSelectingRules);
            container.Register<OakStatisticalAnalisysisForm>();
            //container.Verify();
        }
    }
}
