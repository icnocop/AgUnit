namespace AgUnit.Runner.Resharper90.UnitTestFramework
{
    using AgUnit.Runner.Resharper90.UnitTestFramework.SilverlightPlatform;

    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.UnitTestFramework;

    public class HostProviderWrapper<TWrappedHostProvider> : IHostProvider
        where TWrappedHostProvider : IHostProvider
    {
        public TWrappedHostProvider WrappedHostProvider { get; private set; }

        public HostProviderWrapper(TWrappedHostProvider wrappedHostProvider)
        {
            this.WrappedHostProvider = wrappedHostProvider;
        }

        public ITaskRunnerHostController CreateHostController(
            ISolution solution,
            IUnitTestLaunchManager launchManager,
            IUnitTestResultManager resultManager,
            IUnitTestAgentManager agentManager,
            IUnitTestLaunch launch)
        {
            var hostController = this.CreateWrappedHostController(solution, launchManager, resultManager, agentManager, launch);

            var providers = solution.GetComponent<UnitTestProviders>();
            launch.EnsureSilverlightPlatformSupport(providers, hostController);

            return hostController;
        }

        public string ID
        {
            get { return this.WrappedHostProvider.ID; }
        }

        public bool Available()
        {
            return this.WrappedHostProvider.Available();
        }

        public bool Available(IUnitTestElement element)
        {
            return this.WrappedHostProvider.Available(element);
        }

        public bool SupressBuild()
        {
            return this.WrappedHostProvider.SupressBuild();
        }

        protected virtual ITaskRunnerHostController CreateWrappedHostController(ISolution solution, IUnitTestLaunchManager launchManager, IUnitTestResultManager resultManager, IUnitTestAgentManager agentManager, IUnitTestLaunch launch)
        {
            return this.WrappedHostProvider.CreateHostController(solution, launchManager, resultManager, agentManager, launch);
        }
    }
}   