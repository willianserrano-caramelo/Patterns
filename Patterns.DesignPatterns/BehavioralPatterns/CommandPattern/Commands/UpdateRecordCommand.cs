using Patterns.DesignPatterns.BehavioralPatterns.CommandPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.CommandPattern.Commands
{
    public class UpdateRecordCommand : ICommand
    {
        private readonly DatabaseReceiver _receiver;
        private readonly int _id;
        private readonly string _newData;
        private string _previousData;

        public UpdateRecordCommand(DatabaseReceiver receiver, int id, string newData)
        {
            _receiver = receiver;
            _id = id;
            _newData = newData;
        }

        public void Execute()
        {
            _previousData = _receiver.ReadRecord(_id);
            _receiver.UpdateRecord(_id, _newData);
        }

        public void Undo()
        {
            if (_previousData != null)
                _receiver.UpdateRecord(_id, _previousData);
        }
    }
}
