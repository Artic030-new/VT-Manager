using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTManager.Interactive
{
    internal class VTActionCommand : VTCommand
    {

        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public VTActionCommand(Action<object> execute, Func<object, bool> canExecute = null) {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;

        }
        public override bool CanExecute(object par) => _canExecute?.Invoke(par) ?? true;

        public override void Execute(object par) => _execute(par);
    }
}
