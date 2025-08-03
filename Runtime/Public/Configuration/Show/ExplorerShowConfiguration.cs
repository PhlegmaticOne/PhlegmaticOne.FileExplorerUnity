namespace PhlegmaticOne.FileExplorer
{
    public sealed class ExplorerShowConfiguration
    {
        public string StartupLocation { get; private set; } = string.Empty;

        public ExplorerSceneConfiguration SceneConfiguration { get; private set; } =
            ExplorerSceneConfiguration.Default();
        
        public ExplorerShowTypePayload ShowTypePayload { get; private set; } = 
            ExplorerShowTypePayload.InvestigateFiles();

        public ExplorerShowConfiguration WithStartupLocation(string startupLocation)
        {
            StartupLocation = startupLocation;
            return this;
        }

        public ExplorerShowConfiguration WithSceneConfiguration(ExplorerSceneConfiguration sceneConfiguration)
        {
            SceneConfiguration = sceneConfiguration;
            return this;
        }

        public ExplorerShowConfiguration WithShowType(ExplorerShowTypePayload showPayload)
        {
            ShowTypePayload = showPayload;
            return this;
        }
    }
}