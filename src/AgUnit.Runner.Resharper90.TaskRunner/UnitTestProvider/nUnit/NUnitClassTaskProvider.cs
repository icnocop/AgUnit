namespace AgUnit.Runner.Resharper90.TaskRunner.UnitTestProvider.nUnit
{
    using AgUnit.Runner.Resharper90.TaskRunner.UnitTestRunner.Silverlight.Providers;
    using JetBrains.ReSharper.TaskRunnerFramework;
    using JetBrains.ReSharper.UnitTestRunner.nUnit;

    public class NUnitClassTaskProvider : IClassTaskProvider
    {
        public bool IsClassTask(RemoteTask task)
        {
            return task is NUnitTestFixtureTask;
        }

        private NUnitTestFixtureTask GetTask(RemoteTask task)
        {
            return (NUnitTestFixtureTask)task;
        }

        public string GetFullClassName(RemoteTask task)
        {
            var classTask = GetTask(task);

            return classTask.TypeName;
        }
    }
}