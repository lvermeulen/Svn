using Xunit;
using Xunit.Abstractions;

namespace SvnRevision.Tests
{
    public class SvnInfoShould
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public SvnInfoShould(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData(@"C:\Program Files\CollabNet\Subversion Client\svn.exe", @"C:\svnrepo\Saga\XpsDev")]
        [InlineData(@"C:\Program Files\TortoiseSVN\bin\svn.exe", @"C:\svnrepo\Saga\XpsDev")]
        [InlineData(@"C:\Program Files\SlikSvn\bin\svn.exe", @"C:\svnrepo\Saga\XpsDev")]
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

            _testOutputHelper.WriteLine($"Path: {svnInfo.Path}");
            _testOutputHelper.WriteLine($"Url: {svnInfo.Url}");
            _testOutputHelper.WriteLine($"RelativeUrl: {svnInfo.RelativeUrl}");
            _testOutputHelper.WriteLine($"RepositoryRoot: {svnInfo.RepositoryRoot}");
            _testOutputHelper.WriteLine($"RepositoryUuid: {svnInfo.RepositoryUuid}");
            _testOutputHelper.WriteLine($"Revision: {svnInfo.Revision}");
            _testOutputHelper.WriteLine($"NodeKind: {svnInfo.NodeKind}");
            _testOutputHelper.WriteLine($"LastChangedAuthor: {svnInfo.LastChangedAuthor}");
            _testOutputHelper.WriteLine($"LastChangedRev: {svnInfo.LastChangedRev}");
            _testOutputHelper.WriteLine($"LastChangedDate: {svnInfo.LastChangedDate}");
        }
    }
}
