using Patterns.DesignPatterns.BehavioralPatterns.CommandPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.CommandPattern.Commands
{
    public class CreateRecordCommand : ICommand
    {
        private readonly DatabaseReceiver _receiver;
        private readonly int _id;
        private readonly string _data;

        public CreateRecordCommand(DatabaseReceiver receiver, int id, string data)
        {
            _receiver = receiver;
            _id = id;
            _data = data;
        }

        public void Execute() => _receiver.CreateRecord(_id, _data);

        public void Undo() => _receiver.DeleteRecord(_id);
    }
}
