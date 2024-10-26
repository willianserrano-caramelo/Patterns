using Patterns.DesignPatterns.BehavioralPatterns.CommandPattern;
using Patterns.DesignPatterns.BehavioralPatterns.CommandPattern.Commands;
using Patterns.DesignPatterns.Tests.Attributes;
using Serilog;
using System.Security.AccessControl;

namespace Patterns.DesignPatterns.Tests.BehavioralPatterns.CommandPattern
{
    public class FileCommandTests : IClassFixture<LoggingFixture>
    {
        private readonly ILogger _logger;
        private readonly FileReceiver _fileReceiver;
        private readonly FileInvoker _fileInvoker;
        private readonly string _testFilePath = "testFile.txt";
        private readonly string _nonExistentTestFilePath = "nonExistentTestFile.txt";
        private readonly string _nonExistentPath = "nonExistentDir/testFile.txt";

        public FileCommandTests(LoggingFixture fixture)
        {
            _logger = fixture.GetSerilogLogger();
            _fileReceiver = new FileReceiver(fixture.GetSerilogLogger());
            _fileInvoker = new FileInvoker();
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Command)]
        [PriorityTraits(Enums.TraitPriority.High)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void CreateFileCommand_ShouldCreateAndUndoDeleteFile()
        {
            var command = new CreateFileCommand(_fileReceiver, _testFilePath);

            _fileInvoker.ExecuteCommand(command);
            Assert.True(File.Exists(_testFilePath));

            _fileInvoker.UndoLastCommand();
            Assert.False(File.Exists(_testFilePath));
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Command)]
        [PriorityTraits(Enums.TraitPriority.High)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void EditFileCommand_ShouldEditAndUndoRestoreOriginalContent()
        {
            var createCommand = new CreateFileCommand(_fileReceiver, _testFilePath);
            var editCommand = new EditFileCommand(_fileReceiver, _testFilePath, "New Content");

            _fileInvoker.ExecuteCommand(createCommand);
            _fileInvoker.ExecuteCommand(editCommand);

            Assert.Equal("New Content", File.ReadAllText(_testFilePath));

            _fileInvoker.UndoLastCommand();
            Assert.Equal(string.Empty, File.ReadAllText(_testFilePath));
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Command)]
        [PriorityTraits(Enums.TraitPriority.High)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void DeleteFileCommand_ShouldDeleteAndUndoRestoreFile()
        {
            var createCommand = new CreateFileCommand(_fileReceiver, _testFilePath);
            var deleteCommand = new DeleteFileCommand(_fileReceiver, _testFilePath);

            _fileInvoker.ExecuteCommand(createCommand);
            _fileInvoker.ExecuteCommand(deleteCommand);

            Assert.False(File.Exists(_testFilePath));

            _fileInvoker.UndoLastCommand();
            Assert.True(File.Exists(_testFilePath));
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Command)]
        [PriorityTraits(Enums.TraitPriority.Medium)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Error)]
        public void CreateFileCommand_ShouldFail_WhenPathDoesNotExist()
        {
            var command = new CreateFileCommand(_fileReceiver, _nonExistentPath);

            // Verifica se uma exceção é lançada ao tentar criar um arquivo em um diretório inexistente
            Assert.Throws<DirectoryNotFoundException>(() => _fileInvoker.ExecuteCommand(command));
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Command)]
        [PriorityTraits(Enums.TraitPriority.Medium)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Error)]
        public void EditFileCommand_ShouldFail_WhenFileDoesNotExist()
        {
            var editCommand = new EditFileCommand(_fileReceiver, _nonExistentTestFilePath, "New Content");

            // Verifica se uma FileNotFoundException é lançada ao tentar editar um arquivo inexistente
            Assert.Throws<FileNotFoundException>(() => _fileInvoker.ExecuteCommand(editCommand));
        }



        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Command)]
        [PriorityTraits(Enums.TraitPriority.Medium)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Error)]
        public void DeleteFileCommand_ShouldNotThrow_WhenFileAlreadyDeleted()
        {
            var createCommand = new CreateFileCommand(_fileReceiver, _testFilePath);
            var deleteCommand = new DeleteFileCommand(_fileReceiver, _testFilePath);

            // Executa a criação e exclusão do arquivo
            _fileInvoker.ExecuteCommand(createCommand);
            _fileInvoker.ExecuteCommand(deleteCommand);

            // Verifica se o arquivo já não existe
            Assert.False(File.Exists(_testFilePath));

            // Executa a exclusão novamente e espera que não lance exceção
            _fileInvoker.ExecuteCommand(deleteCommand);
        }


        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Command)]
        [PriorityTraits(Enums.TraitPriority.Medium)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Error)]
        public void CreateFileCommand_ShouldFail_WhenPathIsSystemProtected()
        {
            // Use um caminho protegido ou uma unidade onde não há permissões de gravação (exemplo: raiz do sistema no Windows)
            var protectedPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "testFile.txt");
            var command = new CreateFileCommand(_fileReceiver, protectedPath);

            // Verifica se uma UnauthorizedAccessException é lançada ao tentar criar um arquivo em um local protegido
            Assert.Throws<UnauthorizedAccessException>(() => _fileInvoker.ExecuteCommand(command));
        }
    }
}
