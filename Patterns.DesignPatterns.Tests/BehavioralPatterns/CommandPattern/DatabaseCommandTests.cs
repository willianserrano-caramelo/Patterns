using Serilog;
using Moq;
using Patterns.DesignPatterns.BehavioralPatterns.CommandPattern;
using Patterns.DesignPatterns.BehavioralPatterns.CommandPattern.Commands;
using Patterns.DesignPatterns.Tests.Attributes;
namespace Patterns.DesignPatterns.Tests.BehavioralPatterns.CommandPattern
{
    public class DatabaseCommandTests
    {
        private readonly DatabaseReceiver _databaseReceiver;
        private readonly DatabaseInvoker _databaseInvoker;

        public DatabaseCommandTests()
        {
            _databaseReceiver = new DatabaseReceiver(new Mock<ILogger>().Object);
            _databaseInvoker = new DatabaseInvoker();
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Command)]
        [PriorityTraits(Enums.TraitPriority.High)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void CreateRecordCommand_ShouldCreateAndUndoDeleteRecord()
        {
            var command = new CreateRecordCommand(_databaseReceiver, 1, "Test Data");

            _databaseInvoker.ExecuteCommand(command);
            Assert.Equal("Test Data", _databaseReceiver.ReadRecord(1));

            _databaseInvoker.UndoLastCommand();
            Assert.Null(_databaseReceiver.ReadRecord(1));
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Command)]
        [PriorityTraits(Enums.TraitPriority.High)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void UpdateRecordCommand_ShouldUpdateAndUndoRestoreOriginalData()
        {
            var createCommand = new CreateRecordCommand(_databaseReceiver, 2, "Original Data");
            var updateCommand = new UpdateRecordCommand(_databaseReceiver, 2, "Updated Data");

            _databaseInvoker.ExecuteCommand(createCommand);
            _databaseInvoker.ExecuteCommand(updateCommand);

            Assert.Equal("Updated Data", _databaseReceiver.ReadRecord(2));

            _databaseInvoker.UndoLastCommand();
            Assert.Equal("Original Data", _databaseReceiver.ReadRecord(2));
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Command)]
        [PriorityTraits(Enums.TraitPriority.High)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void DeleteRecordCommand_ShouldDeleteAndUndoRestoreRecord()
        {
            var createCommand = new CreateRecordCommand(_databaseReceiver, 3, "Data to Delete");
            var deleteCommand = new DeleteRecordCommand(_databaseReceiver, 3);

            _databaseInvoker.ExecuteCommand(createCommand);
            _databaseInvoker.ExecuteCommand(deleteCommand);

            Assert.Null(_databaseReceiver.ReadRecord(3));

            _databaseInvoker.UndoLastCommand();
            Assert.Equal("Data to Delete", _databaseReceiver.ReadRecord(3));
        }
    }

}
