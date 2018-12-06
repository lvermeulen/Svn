using Xunit;
using Xunit.Abstractions;

namespace Svn.Tests
{
    public class SvnInfoShould
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public SvnInfoShould(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData(@"C:\Program Files\TortoiseSVN\bin\svn.exe", @"C:\svnrepo\Saga\XpsDev")]
        public void Work(string pathToSvnExe, string workingDirectory)
        {
            var svnInfo = new SvnInfo(pathToSvnExe, workingDirectory);
            Assert.NotNull(svnInfo.Path);
            Assert.NotNull(svnInfo.Url);
            Assert.NotNull(svnInfo.RelativeUrl);
            Assert.NotNull(svnInfo.RepositoryRoot);
            Assert.NotNull(svnInfo.RepositoryUuid);
            Assert.NotNull(svnInfo.Revision);
            Assert.NotNull(svnInfo.NodeKind);
            Assert.NotNull(svnInfo.LastChangedAuthor);
            Assert.NotNull(svnInfo.LastChangedRev);
            Assert.NotNull(svnInfo.LastChangedDate);
            Assert.NotNull(svnInfo.Schedule);

            _testOutputHelper.WriteLine($"{nameof(SvnInfo.Path)}: {svnInfo.Path}");
            _testOutputHelper.WriteLine($"{nameof(SvnInfo.Url)}: {svnInfo.Url}");
            _testOutputHelper.WriteLine($"{nameof(SvnInfo.RelativeUrl)}: {svnInfo.RelativeUrl}");
            _testOutputHelper.WriteLine($"{nameof(SvnInfo.RepositoryRoot)}: {svnInfo.RepositoryRoot}");
            _testOutputHelper.WriteLine($"{nameof(SvnInfo.RepositoryUuid)}: {svnInfo.RepositoryUuid}");
            _testOutputHelper.WriteLine($"{nameof(SvnInfo.Revision)}: {svnInfo.Revision}");
            _testOutputHelper.WriteLine($"{nameof(SvnInfo.NodeKind)}: {svnInfo.NodeKind}");
            _testOutputHelper.WriteLine($"{nameof(SvnInfo.LastChangedAuthor)}: {svnInfo.LastChangedAuthor}");
            _testOutputHelper.WriteLine($"{nameof(SvnInfo.LastChangedRev)}: {svnInfo.LastChangedRev}");
            _testOutputHelper.WriteLine($"{nameof(SvnInfo.LastChangedDate)}: {svnInfo.LastChangedDate}");
            _testOutputHelper.WriteLine($"{nameof(SvnInfo.Schedule)}: {svnInfo.Schedule}");
            _testOutputHelper.WriteLine($"{nameof(SvnInfo.LockToken)}: {svnInfo.LockToken}");
            _testOutputHelper.WriteLine($"{nameof(SvnInfo.LockOwner)}: {svnInfo.LockOwner}");
            _testOutputHelper.WriteLine($"{nameof(SvnInfo.LockCreated)}: {svnInfo.LockCreated}");
        }
    }
}
