namespace CRUDPersonas.Models.ViewModels
{
    public class ErrorVM
    {
        private Exception _exception;

        public Exception Exception { get { return _exception; } }

        public ErrorVM(Exception exception) { 
            this._exception = exception;
        }
    }
}
